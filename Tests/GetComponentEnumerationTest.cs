using NUnit.Framework;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests
{
    public class GetComponentEnumerationTest : TestTransformHierarcy
    {
        [Test]
        public void GetComponents_EnumerateCorrectly()
        {
            CollectionAssert.AreEqual(transform.GetComponents<Transform>(), transform.EnumerateComponents<Transform>());
        }

        [Test]
        public void GetComponentsInChildren_EnumerateCorrectly()
        {
            CollectionAssert.AreEqual(transform.GetComponentsInChildren<Transform>(), transform.EnumerateComponentsInChildren<Transform>());
        }

        [Test]
        public void GetComponentsInParent_EnumerateCorrectly()
        {
            CollectionAssert.AreEqual(transform.GetComponentsInParent<Transform>(), transform.EnumerateComponentsInParent<Transform>());
        }
    }
}
