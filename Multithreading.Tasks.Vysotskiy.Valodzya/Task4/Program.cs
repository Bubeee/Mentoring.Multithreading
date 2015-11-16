using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(RecurtionThreads);
            thread.Start(10);
            thread.Join();
            Console.ReadLine();
        }

        static void RecurtionThreads(object state)
        {
            var currentState = (int) state;
            Console.WriteLine("Thread number {0}, state is: {1}", Thread.CurrentThread.ManagedThreadId, currentState);
            currentState--;
            if (currentState > 0)
            {
                var thread = new Thread(RecurtionThreads);
                thread.Start(currentState);
                thread.Join();
            }
        }
    }
}