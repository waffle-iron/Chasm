#region License

// Copyright (c) K2 Workflow (SourceCode Technology Holdings Inc.). All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

#endregion

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SourceCode.Chasm
{
    /// <summary>
    /// Represents a way to compare different <see cref="Sha1"/> values.
    /// </summary>
    public abstract class Sha1Comparer : IEqualityComparer<Sha1>, IComparer<Sha1>
    {
        #region Constants

        /// <summary>
        /// Gets a <see cref="Sha1Comparer"/> that compares all fields of a <see cref="Sha1"/> value.
        /// </summary>
        public static Sha1Comparer Default { get; } = new DefaultComparer();

        #endregion

        #region Constructors

        protected Sha1Comparer()
        { }

        #endregion

        #region IComparer

        /// <inheritdoc/>
        public abstract int Compare(Sha1 x, Sha1 y);

        #endregion

        #region IEqualityComparer

        /// <inheritdoc/>
        public abstract bool Equals(Sha1 x, Sha1 y);

        /// <inheritdoc/>
        public abstract int GetHashCode(Sha1 obj);

        #endregion

        #region Concrete

        private sealed class DefaultComparer : Sha1Comparer
        {
            #region Constructors

            internal DefaultComparer()
            { }

            #endregion

            #region Methods

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int Compare(Sha1 x, Sha1 y)
            {
                // CLR returns [-1, 0, +1] for ulong/uint comparisons (vs arbitrary neg/pos values)

                var cmp = x.Blit0.CompareTo(y.Blit0);
                if (cmp != 0) return cmp;

                cmp = x.Blit1.CompareTo(y.Blit1);
                if (cmp != 0) return cmp;

                cmp = x.Blit2.CompareTo(y.Blit2);
                return cmp;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override bool Equals(Sha1 x, Sha1 y)
                => x.Blit0 == y.Blit0
                && x.Blit1 == y.Blit1
                && x.Blit2 == y.Blit2;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override int GetHashCode(Sha1 obj)
            {
                var hc = 17L;

                unchecked
                {
                    hc = (hc * 23) + (long)obj.Blit0;
                    hc = (hc * 23) + (long)obj.Blit1;
                    hc = (hc * 23) + obj.Blit2;
                }

                return ((int)(hc >> 32)) ^ (int)hc;
            }

            #endregion
        }

        #endregion
    }
}
