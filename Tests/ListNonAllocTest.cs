using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Gilzoide.NonAllocEnumeration.Tests
{
    public class ListNonAllocTest
    {
        [Test]
        public void IList_EnumeratesCorrectly()
        {
            var list = (IList<int>) Enumerable.Range(0, 100).ToList();
            CollectionAssert.AreEqual(list, list.EnumerateNonAlloc());
        }

        [Test]
        public void IReadOnlyList_EnumeratesCorrectly()
        {
            var list = (IReadOnlyList<int>) Enumerable.Range(0, 100).ToList();
            CollectionAssert.AreEqual(list, list.EnumerateNonAlloc());
        }
    }
}
