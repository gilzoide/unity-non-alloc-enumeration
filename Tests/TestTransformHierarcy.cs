using NUnit.Framework;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests
{
    public class TestTransformHierarcy
    {
        public Transform transform { get; private set; }

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
    }
}
