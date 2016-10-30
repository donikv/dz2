using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad3
{
    class zad3
    {
        static void Main(string[] args)
        {
            int[] integers = new[] {1, 2, 2, 2, 3, 3, 4, 5};
            //string[] strings = integers.Select(i =>"Broj %d se pojavljuje %d puta",i, integers.Where(a=>a==i).Count());
            string[] strings1 = integers.GroupBy(i => i)
                                        .Select(group =>$"Broj {group.Key} se pojavljuje {group.Count()} puta")
                                        .ToArray();
            foreach (string VARIABLE in strings1)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadKey();
        }
    }
}
