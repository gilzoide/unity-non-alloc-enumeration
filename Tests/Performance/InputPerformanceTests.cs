using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class InputPerformanceTests
    {
        [Test, Performance]
        public void Touches()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in Input.touches);
            });
        }

        [Test, Performance]
        public void Touches_NonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in InputTouches.EnumerateNonAlloc());
            });
        }

        [Test, Performance]
        public void AccelerationEvents()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in Input.accelerationEvents);
            });
        }

        [Test, Performance]
        public void AccelerationEvents_NonAlloc()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in InputAccelerationEvents.EnumerateNonAlloc());
            });
        }
    }
}
