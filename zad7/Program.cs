using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            MethodAsync(n);
        }

        public static async Task MethodAsync(int n)
        {
            int k = await FactorialDigitSumAsync(n);
            Console.WriteLine(k);
            Console.ReadKey();
        }

        public static async Task<int> FactorialDigitSumAsync(int n)
        {
            Thread.Sleep(1000);
            int k = 1;
            for (int i = 1; i <= n; i++)
            {
                k *= i;
            }
            Console.WriteLine(k);
            int j = 0;
            while (k != 0)
            {
                int a = k%10;
                j = j + a;
                k = k/10;
            }
            return j;
        }
    }
}
