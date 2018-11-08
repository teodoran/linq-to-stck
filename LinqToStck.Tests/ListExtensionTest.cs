using System;
using System.Collections.Generic;
using Xunit;
using LinqToStck;

namespace LinqToStck.Tests
{
    public class ListExtensionTest
    {
        [Fact]
        public void DropShouldRemoveAnElement()
        {
            var stack = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 1, 2 };
            var actual = stack.Drop();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DupShouldDuplicateTopmostElement()
        {
            var stack = new List<int> { 1, 2 };
            var expected = new List<int> { 1, 2, 2 };
            var actual = stack.Dup();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dup2ShouldDuplicate2TopmostElements()
        {
            var stack = new List<int> { 1, 2 };
            var expected = new List<int> { 1, 2, 1, 2 };
            var actual = stack.Dup2();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotShouldRotate3TopmostElements()
        {
            var stack = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 2, 3, 1 };
            var actual = stack.Rot();

            Assert.Equal(expected, actual);
        }
    }
}
