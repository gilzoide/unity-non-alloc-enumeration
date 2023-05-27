using NUnit.Framework;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests
{
    public class TransformNonAllocTest : TestTransformHierarcy
    {
        [Test]
        public void Transform_EnumeratesCorrectly()
        {
            CollectionAssert.AreEqual(transform, transform.EnumerateNonAlloc());
        }
    }
}
