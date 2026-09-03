using PomTimeApp.model;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Timers;
using static System.Collections.Specialized.BitVector32;
namespace PomTimeApp;

/// <summary>
/// This is where the timer aspect actually is kept and any time senstive event have to go through this
/// </summary>
public class TimeModel
{
    timerInterface timer;
    int workTime;
	int breakTime;
	int seconds;
	bool oneMinAlert;

	//use to talk to the controller that
	//one second has passed
	public EventHandler? decreaseByASecond;

	//Used to talk to the controller
	//that ther is only one minutes left
	public EventHandler? sendOneMinutesAlert;

	//used to talk to the controller
	//that break time has ended
	public EventHandler? breakSessionDone;

    //used to talk to the controller
    //that work time has ended
    public EventHandler? workSessionDone;

	//Purpose: convert workMinutes into work seconds and store it, and do the same for break minutes
	//then create a timer that tick every one seconds
    public TimeModel(int workMinutes, int workSeconds, int breakMinutes, int breakSeconds, timerInterface? inputtedTimer = null) 
	{
        workTime = (workMinutes * 60) + workSeconds;
		breakTime = breakMinutes * 60 + breakSeconds;
		timer = inputtedTimer ?? new realTimer(1000);
		oneMinAlert = false;
	}

	//Used to start the timer or resume the timer
	public void startTime()
	{
		timer.Start();
	}

	//Purpose: used to complete reset timer.
	public void resetTime()
	{
        timer.Elapsed -= workTimer;
		timer.Elapsed -= breakTimer;
		oneMinAlert = false;
        timer.Stop();
    }

	//Purpose: used to temporary pause the timer
	public void pauseTime()
	{
		timer.Stop();
	}

	//Purpose: use to indicate the start of work
	//time and have the timer listen by the worktimer
	//function
	public void startWorkTime()
	{
		timer.Elapsed += workTimer;
        seconds = workTime;
        timer.Start();
	}

    //Pupose: used by timer during work time this will trigger everysecond. When the timer
    //is more than 0 seconds decrease second by 1, tell the controller
    //that this have decrease by a second through decreaseByASecond
    //if there is one mintues left indicate to the controller that 
    //there is one minutes left. Otherwise stop the timer remove
    //workTimer from timer and tell the controller that the work
    //time is done through workSessionDone
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

    //Purpose: use to indicate the start of break
    //time and have the timer listen by the breakimer
    //function
    public void startBreakTime()
	{
		timer.Elapsed += breakTimer;
        seconds = breakTime;
        timer.Start();
	}

    //Purpose: used by the timer to track the break time
    //trigger every 1 seconds. If seconsds is more than 0
    //decrease seconds by 1 and indicate to the controller
    //one seconds has passed through decreaseByASecond
	//if seconds is less or equal to 0. stop the tiemr 
	//remove this function from the timer listener and 
	//tell the controller that the timer is done
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

	//Input: the inptted user Break minutes and seconds;
	//work minutes and seconds; and user number of session
	//Purpose: used at the beginning before any timer has started
	//to set the user time
	public void changeTime(int workMinutes, int workSeconds, int breakMinutes, int breakSeconds)
	{
        workTime = (workMinutes * 60) + workSeconds;
        breakTime = breakMinutes * 60 + breakSeconds;
    }

	//Get the total seconds of work time that was inputed
	public int getWorkTime()
	{
		return workTime;
	}

    //Get the total seconds of break time that was inputed
    public int getBreakTime()
	{
		return breakTime;
	}



}
