using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AsyncDemo
{
   public class Program
    {
       public static  async Task Main(string[] args)
        {
            await EleventhDemo();

        }

        private static async Task EleventhDemo()
        {
            var readList = new List<Task<string>>()
            {
                ReadFileAsync("softuni.txt"),
                ReadFileAsync("digital.txt"),
                ReadFileAsync("softuni-about.txt"),
            };




            await Task.WhenAll(readList);


            Parallel.ForEach(readList, element =>
            {
                Console.WriteLine(element.Result);

            });
        }

        public static async Task<string> ReadFileAsync(string fileName)
        {
            byte[] result;
            Console.WriteLine("Reading....");

            using (FileStream reader=File.Open(fileName,FileMode.Open))
            {
                result = new byte[reader.Length];
                await reader.ReadAsync(result, 0, (int)reader.Length);
                Console.WriteLine("File Readed");

            }

           // Console.WriteLine(System.Text.Encoding.UTF8.GetString(result));
           
            

            return System.Text.Encoding.UTF8.GetString(result);
        }

        private static void PrintNumbersInRange(int v1, int v2)
        {
            for (int i = v1; i < v2; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void TenthDemo()
        {
            var list = Enumerable.Range(0, 1000).ToList();

            Parallel.For(0, 1000, i =>
            {
                Console.WriteLine(list[i]);
            });

            Parallel.ForEach(list, element =>
            {
                Console.WriteLine(element);
            });
        }

        private static async Task NinethDemoWebScrapping()
        {
            var downloads = new List<Task<string>>()
            {
                DownloadWebsiteContent("https://softuni.bg/"),
                DownloadWebsiteContent("https://digital.softuni.bg/"),
                DownloadWebsiteContent("https://softuni.bg/about")

            };

            Console.WriteLine("Fetching........");

            var responses = await Task.WhenAll(downloads);

            var fileTasks = new List<Task>()
            {
                File.WriteAllTextAsync("softuni.txt", responses[0]),
                File.WriteAllTextAsync("digital.txt", responses[1]),
                File.WriteAllTextAsync("softuni-about.txt", responses[2]),
            };

            await Task.WhenAll(fileTasks);
        }

        private static async Task<string> DownloadWebsiteContent(string url)
        {
           using var httpClient = new HttpClient();

           using var response= await httpClient.GetAsync(url);

            var html = await response.Content.ReadAsStringAsync();

            return html;
        }

        private static async Task SeventhDemo()
        {
            var list = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var current = i;

                var task = Task.Run(() =>
                {
                    Console.WriteLine(current);

                });

                list.Add(task);
            }

            await Task.WhenAll(list);
        }

        private static Task<int> DoSomeWork()
        {
            return Task.Run(() =>
            {
                return 100;
            });
        }


        private static void SixthDemo()
        {
            var task = Task.Run(() =>
            {

                var sum = 0;

                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                    Thread.Sleep(100);

                    if (sum % 10 == 0)
                    {
                        Console.Write(".");

                    }



                }

                return sum;

            })
                .ContinueWith(task =>
                {
                    var result = task.Result;
                    Console.WriteLine(result);


                });

            task.Wait();
        }

        private static void FifthDemo()
        {
            var sum = 0;

            var task = Task.Run(() =>
            {


                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                    Thread.Sleep(100);

                    if (sum % 10 == 0)
                    {
                        Console.Write(".");

                    }



                }



            });

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "exit")
                {
                    Console.WriteLine("Exited");
                    return;
                }
                else if (line == "show")
                {
                    Console.WriteLine($"Current result {sum}");

                }
            }
        }

        private static void FourthDemo()
        {
            Thread.CurrentThread.Name = "Main";


            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(DoWork);

                thread.Name = $"Thread {i}";

                thread.Start();




            }
        }

        private static void DoWork()
        {
            var name = Thread.CurrentThread.Name;
            new Thread(() =>
            {
                Console.WriteLine($" {Thread.CurrentThread.Name} Child thread");
            }).Start();

            Console.WriteLine(Thread.CurrentThread.Name);
        }


        private static void ThirdDemo()
        {
            var list = Enumerable.Range(0, 10000).ToList();

            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    lock (list)
                    {

                        while (list.Count > 0)
                        {

                            list.RemoveAt(list.Count - 1);

                        }

                    }
                }).Start();

            }
        }

        private static void FirstDemo()
        {
            var evenNumbersTask = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"Even Number : {i} ");

                    }

                }

            });

            var oddNumbersTask = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.WriteLine($"Odd Number : {i} ");

                    }

                }

            });



            Task.WaitAll(evenNumbersTask, oddNumbersTask);
        }

        private static void SecondDemo()
        {

            var thread = new Thread(() =>
            {

                for (int i = 0; i < 100; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(50);
                }

            });

            thread.Start();

            var line = Console.ReadLine();

            if (line == "exit")
            {
                return;

            }

            thread.Join();
        }
    }
}
