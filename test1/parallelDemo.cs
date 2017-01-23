using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test1
{
    public class parallelDemo
    {
        private Stopwatch stopWatch = new Stopwatch();
        public void run1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 is cost 2 sec");
        }
        public void run2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 2 is cost 3 sec");
        }
        public void ParallelInvokeMethod()
        {
            stopWatch.Start();
            Parallel.Invoke(run1,run2);
            stopWatch.Stop();
            Console.WriteLine("parallel run "+ stopWatch.ElapsedMilliseconds+"ms.");
            stopWatch.Restart();
            run1();
            run2();
            stopWatch.Stop();
            Console.WriteLine("Normal run "+ stopWatch.ElapsedMilliseconds+"ms.");
            Console.ReadKey();
        }
        public void parallelForMethod()
        {
            var obj = new Object();
            long num = 0;
            ConcurrentBag<long> bag = new ConcurrentBag<long>();
            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 60000; j++)
                {
                    //int sum = 0;
                    //sum += i;
                    num++;
                }
            }
            stopWatch.Stop();
            Console.WriteLine("normal run "+stopWatch.ElapsedMilliseconds+"ms.");
            stopWatch.Reset();
            stopWatch.Restart();
            /*
            Parallel.For(0,10000,item =>
            {
            for (int i = 0; i < 60000; i++)
            {
                    //int sum = 0;
                    //sum += i;
                    lock (obj)
                    {
                        num++;
                    }     
            }
        });
        */
            Parallel.For(0, 100, i =>
            {
                Console.WriteLine(i + "\t"); } 
            );
            stopWatch.Stop();
            Console.WriteLine("parallelFor run "+stopWatch.ElapsedMilliseconds+"ms.");
            Console.ReadKey();
       }
        public void parallelBreak()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            stopWatch.Start();
            Parallel.For(0, 1000, (i, state) =>
              {
                  if (bag.Count == 30)
                  {
                      state.Break();
                      return;
                  }
                  bag.Add(i);
              });
            stopWatch.Stop();
            Console.WriteLine("Bag count is "+bag.Count+", "+stopWatch.ElapsedMilliseconds+"ms.");
            Console.ReadKey();
        }
    }
}
