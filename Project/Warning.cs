using System;
using System.Diagnostics;
using System.Threading;

namespace TheCenter.Project
{
    public class Warning
    {
        public int Countdown  { get; set; }
        Stopwatch stopwatch; 
        public Warning(int time)
        {
            stopwatch = new Stopwatch();
            Countdown = time;
        }

        public void start()
        {
            stopwatch.Start();
        }

        public void warningBeep()
        {
           for(int y = 0; y < Countdown; y++)
            {
                Console.Beep();    
                
                Thread.Sleep(1000);
            }
        }

        public void stop()
        {
            stopwatch.Stop();
        }

        public int GetSeconds()
        {
            return stopwatch.Elapsed.Seconds;
        }

    }
}