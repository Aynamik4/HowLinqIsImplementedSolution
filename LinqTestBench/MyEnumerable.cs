using System;
using System.Collections.Generic;

namespace LinqTestBench
{
    public delegate TResult MyFunc<T, TResult>(T t); // This is an equivalent to Func<T, TResult>.

    static class MyEnumerable
    {
        public static IEnumerable<T> Where_Deferred<T>(this IEnumerable<T> collection, MyFunc<T, bool> method)
        {
            foreach (var item in collection)
                if (method(item))
                    yield return item;
        }

        public static IEnumerable<T> Where_NonDeferred<T>(this IEnumerable<T> collection, MyFunc<T, bool> method)
        {
            MyGenericList<T> tmp = new MyGenericList<T>();

            foreach (var item in collection)
                if (method(item))
                    tmp.Add(item);

            return tmp;
        }

        public static int Sum<T>(this IEnumerable<T> collection, Func<T, int> f)
        {
            int sum = 0;

            foreach (var item in collection)
                sum += f(item);

            return sum;
        }
    }
}
