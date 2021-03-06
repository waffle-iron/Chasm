#region License

// Copyright (c) K2 Workflow (SourceCode Technology Holdings Inc.). All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

#endregion

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SourceCode.Clay;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace SourceCode.Chasm.IO.AzureBlob
{
    partial class AzureBlobChasmRepo // .CommitRef
    {
        #region Read

        public override async ValueTask<CommitRef?> ReadCommitRefAsync(string branch, string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(branch)) throw new ArgumentNullException(nameof(branch));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var (found, commitId, _, _) = await ReadCommitRefImplAsync(branch, name, cancellationToken).ConfigureAwait(false);

            // NotFound
            if (!found) return null;

            // Found
            var commitRef = new CommitRef(name, commitId);
            return commitRef;
        }

        #endregion

        #region Write

        public override async Task WriteCommitRefAsync(CommitId? previousCommitId, string branch, CommitRef commitRef, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(branch)) throw new ArgumentNullException(nameof(branch));
            if (commitRef == CommitRef.Empty) throw new ArgumentNullException(nameof(commitRef));

            // Load existing commit ref in order to use its etag
            var (found, existingCommitId, ifMatchCondition, blobRef) = await ReadCommitRefImplAsync(branch, commitRef.Name, cancellationToken).ConfigureAwait(false);

            // Optimistic concurrency check
            if (found)
            {
                // We found a previous commit but the caller didn't say to expect one
                if (!previousCommitId.HasValue)
                    throw BuildConcurrencyException(branch, commitRef.Name, null); // TODO: May need a different error

                // Semantics follow Interlocked.Exchange (compare then exchange)
                if (existingCommitId != previousCommitId.Value)
                {
                    throw BuildConcurrencyException(branch, commitRef.Name, null);
                }

                // Idempotent
                if (existingCommitId == commitRef.CommitId) // We already know that the name matches
                    return;
            }
            // The caller expected a previous commit, but we didn't find one
            else if (previousCommitId.HasValue)
            {
                throw BuildConcurrencyException(branch, commitRef.Name, null); // TODO: May need a different error
            }

            try
            {
                // Required to create blob before appending to it
                await blobRef.CreateOrReplaceAsync(ifMatchCondition, default, default, cancellationToken).ConfigureAwait(false); // Note etag access condition

                // CommitIds are not compressed
                using (var session = Serializer.Serialize(commitRef.CommitId))
                using (var output = new MemoryStream())
                {
                    var seg = session.Result;
                    output.Write(seg.Array, seg.Offset, seg.Count);
                    output.Position = 0;

                    // Append blob. Following seems to be the only safe multi-writer method available
                    // http://stackoverflow.com/questions/32530126/azure-cloudappendblob-errors-with-concurrent-access
                    await blobRef.AppendBlockAsync(output).ConfigureAwait(false);
                }
            }
            catch (StorageException se) when (se.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Conflict)
            {
                throw BuildConcurrencyException(branch, commitRef.Name, se);
            }
        }

        #endregion

        #region Helpers

        private async ValueTask<(bool found, CommitId, AccessCondition, CloudAppendBlob)> ReadCommitRefImplAsync(string branch, string name, CancellationToken cancellationToken)
        {
            // Callers have already validated parameters

            var refsContainer = _refsContainer.Value;
            var blobName = DeriveCommitRefBlobName(branch, name);
            var blobRef = refsContainer.GetAppendBlobReference(blobName);

            try
            {
                using (var output = new MemoryStream())
                {
                    // TODO: Perf: Use a stream instead of a preceding call to fetch the buffer length
                    // Or use blobRef.DownloadToByteArrayAsync() since we already know expected length of data (Sha1.ByteLen)
                    // Keep in mind Azure and/or specific IChasmSerializer may add some overhead: it looks like emperical byte length is 40-52 bytes
                    await blobRef.DownloadToStreamAsync(output, default, default, default, cancellationToken).ConfigureAwait(false);

                    // Grab the etag - we need it for optimistic concurrency control
                    var ifMatchCondition = AccessCondition.GenerateIfMatchCondition(blobRef.Properties.ETag);

                    if (output.Length < Sha1.ByteLen)
                        throw new SerializationException($"{nameof(CommitRef)} '{name}' expected to have byte length {Sha1.ByteLen} but has length {output.Length}");

                    // CommitIds are not compressed
                    var commitId = Serializer.DeserializeCommitId(output.ToArray()); // TODO: Perf

                    // Found
                    return (true, commitId, ifMatchCondition, blobRef);
                }
            }
            catch (StorageException se) when (se.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
            {
                // Try-catch is cheaper than a separate (latent) exists check
                se.Suppress();
            }

            // NotFound
            return (false, default, default, blobRef);

            // Local functions
            string DeriveCommitRefBlobName(string branchName, string commitName)
            {
                var refName = $"{branchName}.{commitName}.commit";
                refName = Uri.EscapeUriString(refName);

                return refName;
            }
        }

        #endregion
    }
}
