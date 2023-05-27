using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class ArrayPerformanceTests
    {
        private int[] array;

        [OneTimeSetUp]
        public void SetUp()
        {
            array = Enumerable.Range(1, 100).ToArray();
        }
        
        [Test, Performance]
        public void ArrayEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in array);
            });
        }

        [Test, Performance]
        public void ArrayAsIReadOnlyListEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IReadOnlyList<int>) array));
            });
        }

        [Test, Performance]
        public void ArrayAsIReadOnlyListEnumerationNonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IReadOnlyList<int>) array).EnumerateNonAlloc());
            });
        }

        [Test, Performance]
        public void ArrayAsIListEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IList<int>) array));
            });
        }

        [Test, Performance]
        public void ArrayAsIListEnumerationNonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IList<int>) array).EnumerateNonAlloc());
            });
        }
    }
}