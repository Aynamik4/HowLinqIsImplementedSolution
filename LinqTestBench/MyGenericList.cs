using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinqTestBench
{
    class MyGenericList<T> : IEnumerable<T>, IEnumerator<T>, IEnumerable, IEnumerator
    {
        T[] items = new T[2];
        int currentLength = 0;
        int forEachCounter = -1;

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public int Count => currentLength;

        public void Add(T t)
        {
            if (currentLength == items.Length)
            {
                T[] tmp = new T[items.Length * 2];
                Array.Copy(items, tmp, items.Length);
                items = tmp;
            }

            items[currentLength++] = t;
        }

        // IEnumerator<T>
        public T Current => items[forEachCounter];

        // IEnumerator<T>
        object IEnumerator.Current => items[forEachCounter];

        public void Dispose() // IEnumerator<T>
        {
            Reset();
        }

        // IEnumerable<T>
        public IEnumerator<T> GetEnumerator() => this;

        public bool MoveNext() // IEnumerator<T>
        {
            return ++forEachCounter < currentLength;
        }

        public void Reset() // IEnumerator<T>
        {
            forEachCounter = -1;
        }

        // IEnumerable<T>
        IEnumerator IEnumerable.GetEnumerator() => this;
    }
}
