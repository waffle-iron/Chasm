#region License

// Copyright (c) K2 Workflow (SourceCode Technology Holdings Inc.). All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

#endregion

using System.Collections;
using System.Collections.Generic;

namespace SourceCode.Chasm.Tests
{
    internal sealed class TestVectors : IEnumerable<object[]>
    {
        #region Constants

        // http://www.di-mgt.com.au/sha_testvectors.html

        private readonly List<object[]> _data = new List<object[]>
        {
            // Test Vector 1
            new object[]{ "", "da39a3ee5e6b4b0d3255bfef95601890afd80709" },

            // Test Vector 2
            new object[]{ "abc", "a9993e364706816aba3e25717850c26c9cd0d89d" },

            // Test Vector 3
            new object[]{ "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq", "84983e441c3bd26ebaae4aa1f95129e5e54670f1" },

            // Test Vector 4
            new object[]{ "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu", "a49b2446a02c645bf419f995b67091253a04a259" },

            // Test Vector 5
            new object[]{ new string('a', 1000_000), "34aa973cd4c4daa4f61eeb2bdbad27316534016f" },
        };

        #endregion

        #region Methods

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
