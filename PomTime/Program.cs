using System;
using System.Diagnostics;
using System.Threading;

namespace prototype
{
    public class pomPrototype
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("It will measure the time between start and stop or when you press the enter key");
            // Stop timing
            while(stopwatch.ElapsedMilliseconds < 5000)
            {
                if(Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Backspace)
                {
                    break;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"I have slept for {stopwatch.ElapsedMilliseconds} miliseconds");
        }
    }
}


