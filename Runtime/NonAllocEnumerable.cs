using System.Collections;
using System.Collections.Generic;

namespace Gilzoide.NonAllocEnumeration
{
    public struct NonAllocEnumerable<TEnumerator, T> : IEnumerable<T>
        where TEnumerator : struct, IEnumerator<T>
    {
        public readonly TEnumerator Enumerator;

        public NonAllocEnumerable(TEnumerator enumerator)
        {
            Enumerator = enumerator;
        }

        public TEnumerator GetEnumerator()
        {
            return Enumerator;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
