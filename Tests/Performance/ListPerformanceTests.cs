using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class ListPerformanceTests
    {
        private List<int> list;

        [OneTimeSetUp]
        public void SetUp()
        {
            list = Enumerable.Range(1, 100).ToList();
        }
        
        [Test, Performance]
        public void ListEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in list);
            });
        }

        [Test, Performance]
        public void IReadOnlyListEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IReadOnlyList<int>) list));
            });
        }

        [Test, Performance]
        public void IReadOnlyListEnumerationNonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IReadOnlyList<int>) list).EnumerateNonAlloc());
            });
        }

        [Test, Performance]
        public void IListEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IList<int>) list));
            });
        }

        [Test, Performance]
        public void IListEnumerationNonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IList<int>) list).EnumerateNonAlloc());
            });
        }
    }
}