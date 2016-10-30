using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> results1 = new List<int>();
            object lockObject = new object();
            Parallel.For(0, 100, (i) =>
            {    
                Thread.Sleep(1);
                lock (lockObject)
                {
                    results1.Add(i * i);
                }
                
            });
            Console.WriteLine("Bag1 length should be 100. Length is {0} and it took {1}ms", results1.Count, stopwatch.ElapsedMilliseconds);            stopwatch.Restart();            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100, (i) => 
{
                Thread.Sleep(1);
                iterations.Add(i);
            }) ;
            Console.WriteLine("Bag length should be 100. Length is {0} and it took {1}ms",
            iterations.Count,stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();

            Console.ReadKey();

        }
        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName,
            Thread.CurrentThread.ManagedThreadId);
        }
    }
}
