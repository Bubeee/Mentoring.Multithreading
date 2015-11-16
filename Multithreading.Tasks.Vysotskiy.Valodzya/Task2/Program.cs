using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        //public static Semaphore Semaphore { get; set; }
        static void Main(string[] args)
        {
            //Semaphore = new Semaphore(0, 1);
            var random = new Random();

            Task.Run(() =>
            {
                var array = new[]
                {
                    random.Next(30), random.Next(30), random.Next(30),
                    random.Next(30), random.Next(30), random.Next(30),
                    random.Next(30), random.Next(30), random.Next(30),
                    random.Next(30)
                };

                Console.WriteLine("Initial array:");
                foreach (var i in array)
                {
                    Console.Write("{0} ", i);
                }

                Console.WriteLine();
                return array;
            }).ContinueWith(task1 =>
            {
                var multiplier = random.Next(30);
                var array = task1.Result;

                Console.WriteLine("Multiplier = " + multiplier);
                Parallel.For(0, array.Length, index => { array[index] *= multiplier; });

                Console.WriteLine("Resulting array:");
                //Parallel.ForEach(array, i => Console.Write("{0} ", i));
                foreach (var i in array)
                {
                    Console.Write("{0} ", i);
                }

                //Semaphore.Release();

                Console.WriteLine();

                return array;
            }).ContinueWith(task2 =>
            {
                var array = task2.Result;
                //Semaphore.WaitOne();
                Array.Sort(array);
                //Semaphore.Release();
                Console.WriteLine("Sorted array:");
                //Parallel.ForEach(array, i => Console.Write("{0} ", i));
                foreach (var i in array)
                {
                    Console.Write("{0} ", i);
                }

                return array;
            }).ContinueWith(task3 => Console.WriteLine("Average value:" + task3.Result.Average())).Wait();

            Console.ReadLine();
        }
    }
}