#if UNITY_2018_1_OR_NEWER
using NUnit.Framework;
using Unity.Collections;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class NativeCollectionsPerformanceTests
    {
        private NativeArray<int> nativeArray;

        [OneTimeSetUp]
        public void SetUp()
        {
            nativeArray = new NativeArray<int>(100, Allocator.Persistent);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            nativeArray.Dispose();
        }
        
        [Test, Performance]
        public void NativeArrayEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in nativeArray);
            });
        }

        [Test, Performance]
        public void NativeSliceEnumeration()
        {
            var slice = new NativeSlice<int>(nativeArray);
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in slice);
            });
        }
    }
}
#endif