using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.NonAllocEnumeration
{
    public static class RectEnumeration
    {
        public static RectCornerEnumerable EnumerateCorners(this Rect rect)
        {
            return new RectCornerEnumerable(rect);
        }
    }

    public struct RectCornerEnumerable : IEnumerable<Vector2>
    {
        public Rect Rect { get; private set; }

        public RectCornerEnumerable(Rect rect)
        {
            Rect = rect;
        }

        public RectCornerEnumerator GetEnumerator()
        {
            return new RectCornerEnumerator(Rect);
        }

        IEnumerator<Vector2> IEnumerable<Vector2>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public struct RectCornerEnumerator : IEnumerator<Vector2>
    {
        public const int CornerCount = 4;
        
        private Vector2 _min;
        private Vector2 _max;

        private int _cornerIndex;

        public RectCornerEnumerator(Rect rect)
        {
            _min = rect.min;
            _max = rect.max;
            _cornerIndex = 0;
        }

        public Vector2 Current
        {
            get
            {
                switch (_cornerIndex)
                {
                    case 0: return new Vector2(_min.x, _min.y);
                    case 1: return new Vector2(_min.x, _max.y);
                    case 2: return new Vector2(_max.x, _max.y);
                    case 3: return new Vector2(_max.x, _min.y);
                    default: return Vector2.zero;
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_cornerIndex < CornerCount)
            {
                _cornerIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _cornerIndex = 0;
        }
    }
}
