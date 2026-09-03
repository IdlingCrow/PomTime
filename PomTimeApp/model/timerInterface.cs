using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PomTimeApp.model
{
    public interface timerInterface
    {
        event ElapsedEventHandler Elapsed;

        void Start();
        void Stop();
    }

    public class realTimer : timerInterface
    {
        private System.Timers.Timer timer;
        public realTimer(double miliseconds)
        {
            timer = new System.Timers.Timer(miliseconds);
        }

        public event ElapsedEventHandler Elapsed
        {
            add => timer.Elapsed += value;
            remove => timer.Elapsed -= value;
        }

        public void Start() { timer.Start(); }

        public void Stop() { timer.Stop(); }
    }

    public class testTimer: timerInterface
    {
        public event ElapsedEventHandler? Elapsed;
        private bool isRunning;

        public testTimer()
        {
            isRunning = false;
        }

        public void elapseTimer(DateTime time = default)
        {
            if (isRunning)
            {
                Elapsed?.Invoke(this, new ElapsedEventArgs(time));
            }
        }

        public void Stop() { isRunning = false; }

        public void Start() { isRunning = true; } 

        public bool isTimerRunning ()
        {
            return isRunning; ;
        }
    }


}
