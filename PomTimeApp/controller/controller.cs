using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
namespace PomTimeApp;

public class Controller
{
	private StartingUI view;
    private TimeModel timerModel;
    private int minutesInd;
    private int secondsInd;
    private bool timerHasStarted;
    

	private TaskCompletionSource<bool>? workTimeCompletionsSource;
	private TaskCompletionSource<bool>? breakTimeCompletionsSource;
	public Controller(StartingUI startingUI, TimeModel timerModel)
	{
        timerHasStarted = false;
        view = startingUI;
		this.timerModel = timerModel;
		view.userPressedStart += startCycle;
        timerModel.decreaseByASecond += decreaseByASecond;
        timerModel.sendOneMinutesAlert += enableOneMinutesWarning;
		timerModel.breakSessionDone += breakSessionTimerDone;
        timerModel.workSessionDone += workSessionTimerDone;
    }

	public async void startCycle(object? sender, EventArgs e)
	{
        if(!timerHasStarted)
        {
            timerHasStarted = true;
            Debug.WriteLine("got to here");
            int breakMinutes = view.getBreakMinutes();
            int breakSeconds = view.getBreakSeconds();
            int workMinutes = view.getWorkMinutes();
            int workSeconds = view.getWorkSeconds();
            int session = view.getSession();

            timerModel.changeTime(workMinutes, workSeconds, breakMinutes, breakSeconds);

            for (int i = 0; i < session; i++)
            {
                breakTimeCompletionsSource = new TaskCompletionSource<bool>();

                WorkTimeDispalyed();
                await runWorkTime(workMinutes, workSeconds);
                BreakTimeDispalyed();
                await runBreakTime(breakMinutes, breakSeconds);
            }
            SettingUpDispalyed();
            view.changeDisplayedTime("00:00");
            timerHasStarted = false;

        }
    }

	public void decreaseByASecond(object? sender, EventArgs e)
	{
		if(secondsInd == 0 && minutesInd == 0)
		{
			Debug.WriteLine("timer is going past 0");
		} else if (secondsInd == 0){
			secondsInd = 59;
			minutesInd--;
		} else
		{
			secondsInd--;
		}

		if(view.InvokeRequired)
		{
			view.Invoke(() => view.changeDisplayedTime($"{minutesInd:D2}:{secondsInd:D2}"));
		} else
		{
            view.changeDisplayedTime($"{minutesInd:D2}:{secondsInd:D2}");
        }
    }

	public void enableOneMinutesWarning(object? sender, EventArgs e)
	{
		if(view.InvokeRequired)
		{
			view.Invoke(() => view.enableOneMinutesWarning());
		} else
		{
          view.enableOneMinutesWarning();
        }
    }

	private Task runWorkTime(int workMinutes, int workSeconds)
	{
        workTimeCompletionsSource = new TaskCompletionSource<bool>();
        minutesInd = workMinutes;
        secondsInd = workSeconds;
        timerModel.startWorkTime();
		return workTimeCompletionsSource.Task;
    }

	private Task runBreakTime(int breakMinutes, int breakSeconds)
	{
        breakTimeCompletionsSource = new TaskCompletionSource<bool>();
        minutesInd = breakMinutes;
        secondsInd = breakSeconds;
        timerModel.startBreakTime();
		return breakTimeCompletionsSource.Task;
    }
	
	private void WorkTimeDispalyed()
	{
		if(view.InvokeRequired)
		{
			view.Invoke(() => view.changeTitleToWork);
		} else
		{
			view.changeTitleToWork();

        }
	}

    private void BreakTimeDispalyed()
    {
        if (view.InvokeRequired)
        {
            view.Invoke(() => view.changeTitleToBreak);
        }
        else
        {
            view.changeTitleToBreak();

        }
    }

    private void SettingUpDispalyed()
    {
        if (view.InvokeRequired)
        {
            view.Invoke(() => view.changeTitleToSettingUp);
        }
        else
        {
            view.changeTitleToSettingUp();

        }
    }

    private void breakSessionTimerDone(object? sender, EventArgs e)
	{
        breakTimeCompletionsSource?.SetResult(true);
    }

    private void workSessionTimerDone(object? sender, EventArgs e)
    {
        disableOneMinutesWarning();
        workTimeCompletionsSource?.SetResult(true);
    }

    public void disableOneMinutesWarning()
    {
        if (view.InvokeRequired)
        {
            view.Invoke(() => view.disableOneminutesWarning());
        }
        else
        {
            view.disableOneminutesWarning();
        }
    }

}
