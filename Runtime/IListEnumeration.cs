using System.Collections;
using System.Collections.Generic;

namespace Gilzoide.NonAllocEnumeration
{
    public static class ReadOnlyListExtensions
    {
        public static NonAllocEnumerable<IReadOnlyListEnumerator<IReadOnlyList<T>, T>, T> EnumerateNonAlloc<T>(this IReadOnlyList<T> list)
        {
            return new NonAllocEnumerable<IReadOnlyListEnumerator<IReadOnlyList<T>, T>, T>(new IReadOnlyListEnumerator<IReadOnlyList<T>, T>(list));
        }

        public static NonAllocEnumerable<IListEnumerator<IList<T>, T>, T> EnumerateNonAlloc<T>(this IList<T> list)
        {
            return new NonAllocEnumerable<IListEnumerator<IList<T>, T>, T>(new IListEnumerator<IList<T>, T>(list));
        }
    }

    public struct IReadOnlyListEnumerator<TList, T> : IEnumerator<T>
        where TList : IReadOnlyList<T>
    {
        private TList _list;
        private int _index;

        public IReadOnlyListEnumerator(TList list)
        {
            _list = list;
            _index = -1;
        }

        public T Current => _list[_index];
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            int newIndex = _index + 1;
            if (newIndex >= 0 && newIndex < _list.Count)
            {
                _index = newIndex;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
        }
    }

    public struct IListEnumerator<TList, T> : IEnumerator<T>
        where TList : IList<T>
    {
        private TList _list;
        private int _index;

        public IListEnumerator(TList list)
        {
            _list = list;
            _index = -1;
        }

        public T Current => _list[_index];
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            int newIndex = _index + 1;
            if (newIndex >= 0 && newIndex < _list.Count)
            {
                _index = newIndex;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
