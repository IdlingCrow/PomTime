using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Timers;
using static System.Collections.Specialized.BitVector32;
namespace PomTimeApp;

public class TimeModel
{
	System.Timers.Timer timer;
    int workTime;
	int breakTime;
	int seconds;
	bool oneMinAlert;
	public EventHandler? decreaseByASecond;
	public EventHandler? sendOneMinutesAlert;
	public EventHandler? breakSessionDone;
    public EventHandler? workSessionDone;

    public TimeModel(int workMinutes, int workSeconds, int breakMinutes, int breakSeconds) 
	{
        workTime = (workMinutes * 60) + workSeconds;
		breakTime = breakMinutes * 60 + breakSeconds;
		timer = new System.Timers.Timer(1000);
		oneMinAlert = false;
	}



	public void startWorkTime()
	{
		timer.Elapsed += workTimer;
        seconds = workTime;
        timer.Start();
	}

	private void workTimer(object? sender, ElapsedEventArgs e)
	{
		if(seconds > 0)
		{
			if(seconds <= 60 && !oneMinAlert) {
				sendOneMinutesAlert?.Invoke(this, EventArgs.Empty);
				oneMinAlert = true;
			}
            seconds--;
            decreaseByASecond?.Invoke(this, EventArgs.Empty);
        } else
		{
            oneMinAlert = false;
            timer.Stop();
			workSessionDone?.Invoke(this, EventArgs.Empty);
			timer.Elapsed -= workTimer;
		}
    }

	public void startBreakTime()
	{
		timer.Elapsed += breakTimer;
        seconds = breakTime;
        timer.Start();
	}

	private void breakTimer(object? sender, ElapsedEventArgs e)
	{
		if(seconds > 0)
		{
            seconds--;
            decreaseByASecond?.Invoke(this, EventArgs.Empty);
        } else
		{
			timer.Stop();
			breakSessionDone?.Invoke(this, EventArgs.Empty);
            timer.Elapsed -= breakTimer;
		}
	}

	public void changeTime(int workMinutes, int workSeconds, int breakMinutes, int breakSeconds)
	{
        workTime = (workMinutes * 60) + workSeconds;
        breakTime = breakMinutes * 60 + breakSeconds;
        timer = new System.Timers.Timer(1000);
    }




}
