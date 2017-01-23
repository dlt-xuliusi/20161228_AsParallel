using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    public class ThreadPool
    {
        public static void ListWithParallel()
        {
            List<int> list = new List<int>();
            Parallel.For(0, 10000, item =>
            {
                list.Add(item);
            });
            Console.WriteLine("List's count is {0}",list.Count());
            //Console.ReadKey();
        }
        public static void ConcurrentBagWithParallel()
        {
            ConcurrentBag<int> list = new ConcurrentBag<int>();
            Parallel.For(0, 10000, item =>
            {
                list.Add(item);
            });
            Console.WriteLine("ConcurrentBag's count is {0}", list.Count());
            int n = 0;
            foreach (int i in list)
            {
                if (n > 10)
                    break;
                n++;
                Console.WriteLine("Item[{0}]={1}",n,i);
            }
            Console.WriteLine("ConcurrentBag's max item is {0}",list.Max());
            Console.ReadKey();
        }
    }
}
