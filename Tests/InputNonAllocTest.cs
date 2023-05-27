using NUnit.Framework;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration.Tests
{
    public class InputNonAllocTest
    {
        [Test]
        public void InputTouches_EnumerateCorrectly()
        {
            CollectionAssert.AreEqual(Input.touches, InputTouches.EnumerateNonAlloc());
        }

        [Test]
        public void InputAccelerationEvents_EnumerateCorrectly()
        {
            CollectionAssert.AreEqual(Input.accelerationEvents, InputAccelerationEvents.EnumerateNonAlloc());
        }
    }
}
