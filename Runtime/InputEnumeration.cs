using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration
{
    public struct InputTouches : IReadOnlyList<Touch>
    {
        public static InputTouches EnumerateNonAlloc()
        {
            return new InputTouches();
        }

        public Touch this[int index] => Input.GetTouch(index);

        public int Count => Input.touchCount;

        public IReadOnlyListEnumerator<InputTouches, Touch> GetEnumerator()
        {
            return new IReadOnlyListEnumerator<InputTouches, Touch>(this);
        }

        IEnumerator<Touch> IEnumerable<Touch>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public struct InputAccelerationEvents : IReadOnlyList<AccelerationEvent>
    {
        public static InputAccelerationEvents EnumerateNonAlloc()
        {
            return new InputAccelerationEvents();
        }

        public AccelerationEvent this[int index] => Input.GetAccelerationEvent(index);

        public int Count => Input.accelerationEventCount;

        public IReadOnlyListEnumerator<InputAccelerationEvents, AccelerationEvent> GetEnumerator()
        {
            return new IReadOnlyListEnumerator<InputAccelerationEvents, AccelerationEvent>(this);
        }

        IEnumerator<AccelerationEvent> IEnumerable<AccelerationEvent>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
