using System;
using System.Collections.Generic;

namespace LinqTestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericList<string> collection = new MyGenericList<string>();

            collection.Add("Anna");
            collection.Add("Bertil");
            collection.Add("Cecilia");
            collection.Add("David");
            collection.Add("Academy");
            collection.Add("ITHS");
            collection.Add("Newton");
            collection.Add("Bowers & Wilkins");
            collection.Add("Kvarnskogen");

            // Testing foreach
            foreach (var item in collection)
                Console.WriteLine(item);
            Console.WriteLine("-----------------------------------------");

            // Testing for
            for (int i = 0; i < collection.Count; i++)
                Console.WriteLine(collection[i]);
            Console.WriteLine("-----------------------------------------");

            // Testing non deferred version of Where
            var q1 = collection
                .Where_NonDeferred(s => s.Length <= 5);

            foreach (var item in q1)
                Console.WriteLine(item);
            Console.WriteLine("-----------------------------------------");

            // Testing deferred version of Where
            var q2 = collection
                .Where_Deferred(s => s.Length <= 5);

            foreach (var item in q2)
                Console.WriteLine(item);
            Console.WriteLine("-----------------------------------------");

            // Testing Sum
            var q3 = collection
                .Sum(new Func<string, int>(ReturnLength /*s => s.Length*/));

            Console.WriteLine($"Total number of characters: {q3}");
            Console.WriteLine("-----------------------------------------");
        }

        static int ReturnLength(string s) => s.Length;

    }
}
