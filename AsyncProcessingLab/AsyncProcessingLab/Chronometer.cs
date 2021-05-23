using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProcessingLab
{
    public class Chronometer : IChronometer
    {

        private static Stopwatch timer = new Stopwatch();

      

        private List<string> laps;

        public Chronometer()
        {
            laps = new List<string>();
        }

        public string GetTime => $"{timer.Elapsed.Minutes:d2}:{timer.Elapsed.Seconds:d2}:{timer.Elapsed.Milliseconds:d4}";

        public List<string> Laps => laps.AsReadOnly().ToList() ;

        public void Lap()
        {
            laps.Add($"{timer.Elapsed.Minutes:d2}:{timer.Elapsed.Seconds:d2}:{timer.Elapsed.Milliseconds:d4}");

            Console.WriteLine($"{timer.Elapsed.Minutes:d2}:{timer.Elapsed.Seconds:d2}:{timer.Elapsed.Milliseconds:d4}");
        }

        public void Reset()
        {

            timer.Reset();

            laps.Clear();
        }

        public void Start()
        {
            timer.Start();

        }

        public void Stop()
        {
            timer.Stop();
        }

        public override string ToString()
        {
            if (Laps.Count==0)
            {
                return "Laps: no laps";

            }

            var sb = new StringBuilder();

            sb.AppendLine($"Laps:");

            for (int i = 0; i < Laps.Count; i++)
            {
                sb.AppendLine($"{i}. {Laps[i]}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
