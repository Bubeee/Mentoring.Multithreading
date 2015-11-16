using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        public static Semaphore Semaphore { get; set; }
        static void Main(string[] args)
        {
            Semaphore = new Semaphore(1, 1);

            ThreadPool.QueueUserWorkItem(RecurtionThreads, 10);
            Semaphore.WaitOne();
            Console.ReadLine();
        }

        static void RecurtionThreads(object state)
        {
            var currentState = (int)state;
            Console.WriteLine("Thread number {0}, state is: {1}", Thread.CurrentThread.ManagedThreadId, currentState);
            currentState--;
            if (currentState > 0)
            {
                ThreadPool.QueueUserWorkItem(RecurtionThreads, currentState);
                Semaphore.WaitOne();
            }

            Semaphore.Release();
        }
    }
}