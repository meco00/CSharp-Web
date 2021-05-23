using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProcessingLab
{
    class Program
    {
        static void  Main(string[] args)
        {

            var chronometer = new Chronometer();

           



            while (true)
            {
                var command = Console.ReadLine();


                switch (command)
                {
                    case "start":
                      new Thread(()=> chronometer.Start()).Start();
                       
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                     chronometer.Lap();
                        break;
                    case "laps":
                        Console.WriteLine( chronometer.ToString());
                        break;
                    case "time":
                        Console.WriteLine( chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        return;
                       

                }

            }

        }
    }
}
