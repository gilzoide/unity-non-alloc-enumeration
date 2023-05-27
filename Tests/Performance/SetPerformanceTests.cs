using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class SetPerformanceTests
    {
        private HashSet<int> set;

        [OneTimeSetUp]
        public void SetUp()
        {
            set = Enumerable.Range(1, 100).ToHashSet();
        }
        
        [Test, Performance]
        public void SetEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in set);
            });
        }

        [Test, Performance]
        public void ISetEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in ((ISet<int>) set));
            });
        }
    }
}