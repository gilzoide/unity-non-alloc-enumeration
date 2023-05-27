using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class DictionaryPerformanceTests
    {
        private Dictionary<int, int> list;

        [OneTimeSetUp]
        public void SetUp()
        {
            list = Enumerable.Range(1, 100).ToDictionary(x => x, x => x);
        }
        
        [Test, Performance]
        public void DictionaryEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in list);
            });
        }

        [Test, Performance]
        public void IReadOnlyDictionaryEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((IReadOnlyDictionary<int, int>) list));
            });
        }
    }
}