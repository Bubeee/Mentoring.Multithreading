using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        public static Semaphore Semaphore { get; set; }
        static void Main(string[] args)
        {
            var collection = new List<int>(10);

            Semaphore = new Semaphore(0, 1);

            Task.Run(() => Population(collection));
            Task.Run(() => Print(collection));

            Console.ReadLine();
        }
        private static void Population(ICollection<int> collection)
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var newElement = random.Next(50);
                collection.Add(newElement);
                Console.WriteLine("Current thread id - {0} Added: {1}", Thread.CurrentThread.ManagedThreadId, newElement);
                Semaphore.Release();
                Semaphore.WaitOne();
            }
        }

        private static void Print(List<int> collection)
        {
            for (int i = 0; i < collection.Capacity; i++)
            {
                Semaphore.WaitOne();
                Console.WriteLine("Current thread id - {0} Printed: {1}", Thread.CurrentThread.ManagedThreadId, collection[i]);
                Semaphore.Release();
            }
        }
    }
}