using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersCounter
{
    class Program
    {
        static int CountPrimeNumbers = 0;
        static object lockObg = new object();

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            PrintPrimeCount(1, 10000000);
            Console.WriteLine(CountPrimeNumbers);
            Console.WriteLine(sw.Elapsed);

            //Task.Run(PrintPrimeCount);

            //Stopwatch sw2 = Stopwatch.StartNew();
            //List<Task> tasks = new List<Task>();
            //for (int i = 1; i <= 100; i++)
            //{
            //    var task = Task.Run(() => DownLoadAsync(i));
            //    tasks.Add(task);

            //    //HttpClient httpClient = new HttpClient();
            //    //List<Thread> threads = new List<Thread>();
            //    //var thread = new Thread(() =>
            //    //{
            //    //    var url = $"https://vicove.com/vic-{i}";
            //    //    var httpResposnse = httpClient.GetAsync(url).GetAwaiter().GetResult();
            //    //    var vic = httpResposnse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    //    Console.WriteLine(vic.Length);
            //    //});
            //    //thread.Start();
            //    //threads.Add(thread);
            //}

            //Task.WaitAll(tasks.ToArray());

            ////foreach (var thread in threads)
            ////{
            ////    thread.Join();
            ////}

            //Console.WriteLine(sw2.Elapsed);
            //return;

            // Можем да използваме анонимен метод, който да опишем директно тук:
            //Thread tread = new Thread(() =>
            //{
            //    code
            //}); 

            //Stopwatch sw = Stopwatch.StartNew();

            //Thread tread = new Thread(() => PrintPrimeCount(1, 2500000));
            //tread.Start();
            //Thread tread2 = new Thread(() => PrintPrimeCount(2500001, 5000000));
            //tread2.Start();
            //Thread tread3 = new Thread(() => PrintPrimeCount(5000001, 7500000));
            //tread3.Start();
            //Thread tread4 = new Thread(() => PrintPrimeCount(7500001, 10000000));
            //tread4.Start();

            //tread.Join(); // осигурява, че ще се изчака тредът да приключи работа преди да се затвори програмата 
            //tread2.Join(); // също докато не приключи треда да не се продължава изпълнението й надолу
            //tread3.Join();
            //tread4.Join();

            //Console.WriteLine(CountPrimeNumbers);
            //Console.WriteLine(sw.Elapsed);

            //while (true)
            //{
            //    var input = Console.ReadLine();
            //    Console.WriteLine(input.ToUpper());
            //}
        }

        static async Task DownLoadAsync(int i)
        {
            HttpClient httpClient = new HttpClient();
            var url = $"https://vicove.com/vic-{i}";
            var httpResposnse = await httpClient.GetAsync(url);
            var vic = await httpResposnse.Content.ReadAsStringAsync();
            Console.WriteLine(vic.Length);
        }

        static void PrintPrimeCount(int min, int max)
        {
            //for (int i = min; i <= max; i++)
            Parallel.For(min, max + 1, i =>
            {
                {
                    bool isPrime = true;

                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        // monitor - lock използва примитива на ОС Мonitor, lock <=>
                        //Monitor.Enter(lockObg);
                        //CountPrimeNumbers++;
                        //Monitor.Exit(lockObg);

                        lock (lockObg)
                        {
                            CountPrimeNumbers++;
                        }
                    }
                }
            });
        }
    }
}
