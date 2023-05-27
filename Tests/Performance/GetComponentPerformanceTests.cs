using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests.Performance
{
    public class GetComponentPerformanceTests
    {
        private List<Transform> list = new List<Transform>();
        private Transform transform;

        [OneTimeSetUp]
        public void SetUp()
        {
            transform = new GameObject("root").transform;
            for (int i = 0; i < 10; i++)
            {
                new GameObject("Child " + i.ToString()).transform.SetParent(transform);
            }

            list.Clear();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(transform.gameObject);
        }
        
        [Test, Performance]
        public void GetComponents()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.GetComponents<Transform>());
            });
        }

        [Test, Performance]
        public void GetComponentsInChildren()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.GetComponentInChildren<Transform>());
            });
        }

        [Test, Performance]
        public void GetComponentsInParent()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.GetComponentInParent<Transform>());
            });
        }

        [Test, Performance]
        public void GetComponents_CachedList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                transform.GetComponents(list);
                foreach (var _ in list);
            });
        }

        [Test, Performance]
        public void GetComponentsInChildren_CachedList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                transform.GetComponentsInChildren(list);
                foreach (var _ in list);
            });
        }

        [Test, Performance]
        public void GetComponentsInParent_CachedList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                transform.GetComponentsInParent(true, list);
                foreach (var _ in list);
            });
        }

#if UNITY_2021_1_OR_NEWER
        [Test, Performance]
        public void GetComponents_PooledList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.EnumerateComponents<Transform>());
            });
        }

        [Test, Performance]
        public void GetComponentsInChildren_PooledList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.EnumerateComponentsInChildren<Transform>());
            });
        }

        [Test, Performance]
        public void GetComponentsInParent_PooledList()
        {
            PerformanceTestUtils.RunEnumeratePerformanceTest(() =>
            {
                foreach (var _ in transform.EnumerateComponentsInParent<Transform>());
            });
        }
#endif
    }
}