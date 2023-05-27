using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class TransformPerformanceTests : TestTransformHierarcy
    {
        [Test, Performance]
        public void TransformEnumeration()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform);
            });
        }

        [Test, Performance]
        public void TransformEnumerationNonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.EnumerateNonAlloc());
            });
        }
    }
}