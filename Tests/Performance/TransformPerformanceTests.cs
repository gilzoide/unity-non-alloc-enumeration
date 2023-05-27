using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class TransformPerformanceTests
    {
        private Transform transform;

        [OneTimeSetUp]
        public void SetUp()
        {
            transform = new GameObject("root").transform;
            for (int i = 0; i < 10; i++)
            {
                new GameObject("Child " + i.ToString()).transform.SetParent(transform);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(transform.gameObject);
        }
        
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