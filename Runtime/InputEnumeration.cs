using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration
{
    public static class InputEnumeration
    {
        public static InputTouchList Touches => new InputTouchList();
        public static InputAccelerationEventList AccelerationEvents => new InputAccelerationEventList();
    }

    public struct InputTouchList : IReadOnlyList<Touch>
    {
        public Touch this[int index] => Input.GetTouch(index);

        public int Count => Input.touchCount;

        public IReadOnlyListEnumerator<InputTouchList, Touch> GetEnumerator()
        {
            return new IReadOnlyListEnumerator<InputTouchList, Touch>(this);
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

    public struct InputAccelerationEventList : IReadOnlyList<AccelerationEvent>
    {
        public AccelerationEvent this[int index] => Input.GetAccelerationEvent(index);

        public int Count => Input.accelerationEventCount;

        public IReadOnlyListEnumerator<InputAccelerationEventList, AccelerationEvent> GetEnumerator()
        {
            return new IReadOnlyListEnumerator<InputAccelerationEventList, AccelerationEvent>(this);
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
