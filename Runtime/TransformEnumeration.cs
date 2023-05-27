using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration
{
    public static class TransformExtensions
    {
        public static TransformAsList EnumerateNonAlloc(this Transform transform)
        {
            return new TransformAsList(transform);
        }
    }

    public struct TransformAsList : IReadOnlyList<Transform>
    {
        private Transform _transform;

        public TransformAsList(Transform transform)
        {
            _transform = transform;
        }

        public Transform this[int index] => _transform.GetChild(index);

        public int Count => _transform.childCount;

        public IReadOnlyListEnumerator<TransformAsList, Transform> GetEnumerator()
        {
            return new IReadOnlyListEnumerator<TransformAsList, Transform>(this);
        }

        IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
