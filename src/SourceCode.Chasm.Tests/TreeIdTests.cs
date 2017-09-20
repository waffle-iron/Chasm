﻿using Xunit;

namespace SourceCode.Chasm.Tests
{
    public static class TreeIdTests
    {
        [Trait("Type", "Unit")]
        [Fact(DisplayName = nameof(TreeId_has_empty_sha1))]
        public static void TreeId_has_empty_sha1()
        {
            Assert.Equal(Sha1.Empty, TreeId.Empty.Sha1);
            Assert.Equal(default, TreeId.Empty);
        }

        [Trait("Type", "Unit")]
        [Fact(DisplayName = nameof(TreeId_equality))]
        public static void TreeId_equality()
        {
            var treeId1 = new TreeId(Sha1.Hash("abc"));
            var treeId2 = new TreeId(Sha1.Hash("abc"));
            var treeId3 = new TreeId(Sha1.Hash("def"));

            Assert.Equal(treeId1, treeId2);
            Assert.Equal(treeId1.GetHashCode(), treeId2.GetHashCode());

            Assert.NotEqual(TreeId.Empty, treeId1);
            Assert.NotEqual(TreeId.Empty.GetHashCode(), treeId1.GetHashCode());

            Assert.NotEqual(treeId3, treeId1);
            Assert.NotEqual(treeId3.GetHashCode(), treeId1.GetHashCode());
        }
    }
}
