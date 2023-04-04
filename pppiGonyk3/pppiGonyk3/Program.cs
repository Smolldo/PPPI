using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace pppiGonyk3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Thread 1 запуск потоку
            Console.WriteLine("Thread1");
            Thread workerThread = new Thread(WorkerMethod);
            Console.WriteLine("початок головного потоку");

            workerThread.Start();

            Console.WriteLine("робота головного потоку");

            workerThread.Join();

            Console.WriteLine("завершення головного потоку");


            // Thread 2 Пул потоків
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolDemo), "Task 1");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolDemo), "Task 2");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolDemo), "Task 3");

            Console.WriteLine("Завдання додалися до пулу");


            //Async - Await
            Console.WriteLine();
            Console.WriteLine("async-await");

            string url1 = "https://jsonplaceholder.typicode.com/todos/19";
            string url2 = "https://jsonplaceholder.typicode.com/todos/99";

            Console.WriteLine("Req1");
            string response1 = await GetResponseAsync(url1);
            Console.WriteLine($"Res1 {url1}: {response1}");

            Console.WriteLine("Req2");
            string response2 = await GetResponseAsync(url2);
            Console.WriteLine($"Res2 {url2}: {response2}");

            Console.WriteLine("All requests done");
            Console.ReadKey();



            Console.ReadKey();
        }

        static void ThreadPoolDemo(object task)
        {
            Console.WriteLine($"початок таску: '{task}'");
            Thread.Sleep(1000);
            Console.WriteLine($"завершення таску: '{task}'");
        }

        static void WorkerMethod()
        {
            Console.WriteLine();
            Console.WriteLine("початок робочого потоку");

            Thread.Sleep(3000);

            Console.WriteLine("робочий поток завершений");
        }


        static async Task<string> GetResponseAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
