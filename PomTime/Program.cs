using System;
using System.Diagnostics;
using System.Threading;

namespace prototype
{
    public class pomPrototype
    {
        public static void Main(string[] args)
        {
            int workTime;
            int breakTime;
            int repeat;
            string? stickyNotes = null;

            Console.Write("Please enter work time: ");
            workTime = getInputTimeInMiliseconds();
            Console.Write("Please enter break time: ");
            breakTime = getInputTimeInMiliseconds();
            Console.Write("Please enter how many repeats: ");
            repeat = getRepeatTime();

            Stopwatch timer = new Stopwatch();

            for(int i = 0; i < repeat; i++)
            {
                if(i < repeat - 1)
                {
                    workTimeMethod(workTime, stickyNotes, timer, false);
                } else
                {
                    workTimeMethod(workTime, stickyNotes, timer, true);
                }

                if(i < repeat - 1)
                {
                    stickyNotes = breakTimeMethod(breakTime, timer);
                } 

            } 
        }

        public static void workTimeMethod(int workTime, string ? stickyNotes, Stopwatch timer, bool lastSession) {
            Console.WriteLine("time to get to work");
            if (stickyNotes != null && !lastSession)
            {
                Console.WriteLine($"here is the notes you left for yourself: {stickyNotes}");
            }
            timer.Start();
            while(timer.ElapsedMilliseconds < workTime)
            {
                Console.WriteLine($"{timer.ElapsedMilliseconds / 1000} seconds has pass");
                Thread.Sleep(1000);
            }
            timer.Stop();
            timer.Reset();
            Console.WriteLine("WorkTime has comes to an end");
        }

        public static String breakTimeMethod(int breakTime, Stopwatch timer)
        {
            int activityStopTime = breakTime - (breakTime % 16000);
            Console.Write("Please write down what you are thinking: ");
            string stickyNotes = Console.ReadLine() ?? "";
            Console.WriteLine("Time to go to break time, we are doing box breathing");
            timer.Start();
            while(timer.ElapsedMilliseconds < activityStopTime)
            {
                Console.WriteLine("breath in");
                Thread.Sleep(4000);
                Console.WriteLine("hold");
                Thread.Sleep(4000);
                Console.WriteLine("breath out");
                Thread.Sleep(4000);
                Console.WriteLine("hold");
                Thread.Sleep(4000);
            }
            Console.WriteLine($"that is the end of your guided break, enjoy the last {(breakTime - timer.ElapsedMilliseconds) / 1000} seconds");

            while(timer.ElapsedMilliseconds < breakTime)
            {
                Console.WriteLine($"{timer.ElapsedMilliseconds / 1000} seconds has pass");
                Thread.Sleep(1000);
            }
            timer.Stop();
            timer.Reset();

            return stickyNotes;
        }

        public static int getInputTimeInMiliseconds()
        {
            return Convert.ToInt32(Console.ReadLine()) * 1000;
        }

        public static int getRepeatTime()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}


