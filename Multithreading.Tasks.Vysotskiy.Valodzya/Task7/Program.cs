using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        private static void Main(string[] args)
        {
            var task = new Task(() =>
            {
                Console.WriteLine("Task 1 rolls out");
                throw new Exception();
            });

            task.ContinueWith(
                task1 => Console.WriteLine("Task {0} nevermind of state, task result is {1}", task1.Id, task1.Status),
                TaskContinuationOptions.None);
            task.ContinueWith(
                task1 => Console.WriteLine("Task {0} failed, task result is {1}", task1.Id, task1.Status),
                TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(
                task1 => Console.WriteLine("Task {0} failed executing continuation syncchronously, task result is {1}", task1.Id, task1.Status),
                TaskContinuationOptions.ExecuteSynchronously);
            task.ContinueWith(
                task1 => Console.WriteLine("Task {0} runned outside the pool, task result is {1}", task1.Id, task1.Status),
                TaskContinuationOptions.OnlyOnCanceled);

            task.Start();

            Console.ReadLine();
        }
    }
}