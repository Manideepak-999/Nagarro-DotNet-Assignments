using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class ExtClass
    {

        public delegate bool Condition<T>(T n);

        // 1. CustomAll - Should work as All operation of Linq, with custom logic passed as delegate
        public static bool CustomAll<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.All(condition);
        }

        // 2. CustomAny - Should work as Any operation of Linq, with custom logic passed as delegate
        public static bool CustomAny<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.Any(condition);
        }

        // 3. CustomMax - Should work as Max operation of Linq, with custom logic passed as delegate
        public static TResult CustomMax<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Max(function);
        }

        // 4. CustomMin - Should work as Min operation of Linq, with custom logic passed as delegate
        public static TResult CustomMin<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Min(function);
        }

        // 5. CustomWhere - Should work as Where operation of Linq, with custom logic passed as delegate
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.Where(condition);
        }

        // 6. CustomSelect - Should work as Select operation of Linq, with custom logic passed as delegate
        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Select(function);
        }
    }

    class MainClass
    {
        public static void Print<T>(IEnumerable<T> list)
        {
            foreach (T el in list)
                Console.Write(el + "  ");
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            IEnumerable<int> list = new List<int>() { 1, 2, 1, 4, 3, 1, 5, 4, 2 };

            Console.WriteLine(list.CustomAll(n => n > 0));
            Console.WriteLine(list.CustomAny(n => n == 3));
            Console.WriteLine(list.CustomMax(n => 2 * n));
            Console.WriteLine(list.CustomMin(n => 2 * n));

            IEnumerable<int> whereEnum = list.CustomWhere(n => n % 2 == 1);
            Print(whereEnum);
            IEnumerable<double> selectEnum = list.CustomSelect(n => 0.5 * n);
            Print(selectEnum);
        }
    }
}