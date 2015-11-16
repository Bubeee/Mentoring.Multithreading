using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfTasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                listOfTasks.Add(new Task(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        Console.WriteLine("Task #{0} - {1}", Task.CurrentId, j);
                    }
                }));
            }

            foreach (var task in listOfTasks)
            {
                task.Start();
            }

            Console.ReadLine();
        }
    }
}