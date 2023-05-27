using System;
using Unity.PerformanceTesting;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public static class PerformanceTestUtils
    {
        public static void RunEnumeratePerformanceTest(this Action method)
        {
            Measure.Method(method)
                .IterationsPerMeasurement(5)
                .MeasurementCount(5)
                .GC()
                .Run();
        }
    }
}
