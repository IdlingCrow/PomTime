using Microsoft.VisualBasic.ApplicationServices;
using PomTimeApp.view;
using System;
using System.Diagnostics;
namespace PomTimeApp;

public class Controller
{
	private StartingUI view;
    private TimeModel timerModel;
    private SoundModel musicModel;
    private int minutesInd;
    private int secondsInd;
    private bool timerHasStarted;
    private CancellationTokenSource resetToken;
    private bool musicHasBeenPause;
    private stickyNotes reminderNotes;

    private TaskCompletionSource<bool>? workTimeCompletionsSource;
	private TaskCompletionSource<bool>? breakTimeCompletionsSource;
	public Controller(StartingUI startingUI, TimeModel timerModel, SoundModel musicModel, stickyNotes reminderNotes)
	{
        timerHasStarted = false;
        view = startingUI;
		this.timerModel = timerModel;
        this.reminderNotes = reminderNotes;
		view.userPressedStart += startCycle;
        view.userPressedPause += pauseTimer;
        view.userPressedResume += resumeTimer;
        view.userPressedReset += resetTimer;
        view.resumeMusic += resumeMusic;
        view.pauseMusic += pauseMusic;

        timerModel.decreaseByASecond += decreaseByASecond;
        timerModel.sendOneMinutesAlert += enableOneMinutesWarning;
		timerModel.breakSessionDone += breakSessionTimerDone;
        timerModel.workSessionDone += workSessionTimerDone;

        this.musicModel = musicModel;
        musicHasBeenPause = false;
    }


    public async void startCycle(object? sender, EventArgs e) => await startCycleInner();
	private async Task startCycleInner()
	{
        if(!timerHasStarted)
        {
            timerHasStarted = true;
            int breakMinutes = view.getBreakMinutes();
            int breakSeconds = view.getBreakSeconds();
            int workMinutes = view.getWorkMinutes();
            int workSeconds = view.getWorkSeconds();
            int session = view.getSession();
            Debug.WriteLine($"recived: {workMinutes}:{workSeconds} work, {breakMinutes}: {breakSeconds} break, {session} session");

            timerModel.changeTime(workMinutes, workSeconds, breakMinutes, breakSeconds);

            resetToken = new CancellationTokenSource();
            
            try
            {
                for (int i = 0; i < session; i++)
                {
                    breakTimeCompletionsSource = new TaskCompletionSource<bool>();

                    musicModel.playSound();
                    if(!musicHasBeenPause)
                    {
                        musicModel.playMusic();
                    }
                    await runWorkTime(workMinutes, workSeconds, resetToken.Token);
                    musicModel.stopMusic();
                    musicModel.playSound();
                    await runBreakTime(breakMinutes, breakSeconds, resetToken.Token);
                }
                SessionComplete();
                musicModel.playDoubleSound();
                timerHasStarted = false;
            } catch (OperationCanceledException)
            {
                timerModel.resetTime();
                SessionComplete();
                musicModel.stopMusic();
                timerHasStarted = false;
            }


        }
    }

    public void resumeMusic(object? sender, EventArgs e)
    {
        if (!musicModel.isPlayingMusic()) {
            musicModel.playMusic();
        }
        musicHasBeenPause = false;
    }

    public void pauseMusic(object? sender, EventArgs e)
    {
        if (musicModel.isPlayingMusic())
        {
            musicModel.stopMusic();
        }
        musicHasBeenPause = true;
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
			view.Invoke(() => updateTimer());
		} else
		{
            updateTimer();
        }
    }

    public void resetTimer(object? sender, EventArgs e)
    {
        Debug.WriteLine($"resetToken called");
        resetToken.Cancel();
    }


    public void enableOneMinutesWarning(object? sender, EventArgs e)
	{
		if(view.InvokeRequired)
		{
			view.Invoke(() => {
                view.enableOneMinutesWarning();
                reminderNotes.openNotes();
            });
		} else
		{
            view.enableOneMinutesWarning();
            reminderNotes.openNotes();
        }
    }

    

	private Task runWorkTime(int workMinutes, int workSeconds, CancellationToken token)
	{
        if (view.InvokeRequired)
        {
            view.Invoke(() => {

                reminderNotes.openNotes();
            });
        }
        else
        {
            reminderNotes.openNotes();
        }
        workTimeCompletionsSource = new TaskCompletionSource<bool>();
        minutesInd = workMinutes;
        secondsInd = workSeconds;
        WorkTimeDispalyed();
        token.Register(() => workTimeCompletionsSource.TrySetCanceled());
        updateTimer();
        timerModel.startWorkTime();
		return workTimeCompletionsSource.Task;
    }

	private Task runBreakTime(int breakMinutes, int breakSeconds, CancellationToken token)
	{
        breakTimeCompletionsSource = new TaskCompletionSource<bool>();
        minutesInd = breakMinutes;
        secondsInd = breakSeconds;
        token.Register(() => breakTimeCompletionsSource.TrySetCanceled());
        BreakTimeDispalyed();
        updateTimer();
        timerModel.startBreakTime();
		return breakTimeCompletionsSource.Task;
    }
	
	private void WorkTimeDispalyed()
	{
        if (view.InvokeRequired)
        {
            view.Invoke(() => 
            { 
                view.switchToWorkScreen();

            }); 
		} else
		{
            view.switchToWorkScreen();
        }


	}

    private void BreakTimeDispalyed()
    {
        if (view.InvokeRequired)
        {
            view.Invoke(() => {
                  view.switchToBreakScreen();
            });
        }
        else
        {
            view.switchToBreakScreen();
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

    private void updateTimer()
    {

        if (view.InvokeRequired)
        {
            view.Invoke(() => view.changeDisplayedTime($"{minutesInd:D2}:{secondsInd:D2}"));
        }
        else
        {
            view.changeDisplayedTime($"{minutesInd:D2}:{secondsInd:D2}");

        }
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

    public void SessionComplete()
    {
        if(view.InvokeRequired)
        {
            view.Invoke(() => view.switchToSettingUpScreen());
        }
        else
        {
            view.switchToSettingUpScreen();
        }
    }

    public void resumeTimer(object? sender, EventArgs e)
    {
        timerModel.startTime();
        musicModel.playMusic();
    }

    public void pauseTimer(object? sender, EventArgs e)
    {
        timerModel.pauseTime();
        musicModel.stopMusic();
    }

    //for test purposes
    public void changeBreakTime(int minutes, int seconds)
    {
        minutesInd = minutes;
        secondsInd = seconds;
    }
    
    

}
