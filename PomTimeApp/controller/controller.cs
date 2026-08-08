using Microsoft.VisualBasic.ApplicationServices;
using PomTimeApp.model;
using PomTimeApp.view;
using System;
using System.Diagnostics;
namespace PomTimeApp;

public class Controller
{
	private StartingUI view;
    private TimeModel timerModel;
    private SoundModel musicModel;
    private ThemeModel themeModel;
    private int minutesInd;
    private int secondsInd;
    private bool timerHasStarted;
    private CancellationTokenSource resetToken;
    private bool musicHasBeenPause;
    private stickyNotes reminderNotes;
    private bool isFirstWorkTime;

    private TaskCompletionSource<bool>? workTimeCompletionsSource;
	private TaskCompletionSource<bool>? breakTimeCompletionsSource;
	public Controller(StartingUI startingUI, TimeModel timerModel, SoundModel musicModel, stickyNotes reminderNotes, ThemeModel themeModel)
	{

        this.musicModel = musicModel;
        view = startingUI;
		this.timerModel = timerModel;
        this.reminderNotes = reminderNotes;
        this.themeModel = themeModel;
        isFirstWorkTime = true;

		view.userPressedStart += startCycle;
        view.userPressedPause += pauseTimer;
        view.userPressedResume += resumeTimer;
        view.userPressedReset += resetTimer;
        view.resumeMusic += resumeMusic;
        view.pauseMusic += pauseMusic;
        view.skipMusic += skipMusic;
        view.playPreviousMusic += playPreviousMusic;
        view.theme1Pressed += changeToTheme1;
        view.theme2Pressed += changeToTheme2;
        view.theme3Pressed += changeToTheme3;
        view.manageMusicPressed += manageMusic;
        resetToken = new CancellationTokenSource();

        timerModel.decreaseByASecond += decreaseByASecond;
        timerModel.sendOneMinutesAlert += enableOneMinutesWarning;
		timerModel.breakSessionDone += breakSessionTimerDone;
        timerModel.workSessionDone += workSessionTimerDone;

        timerHasStarted = false;
        musicHasBeenPause = false;
    }


    public async void startCycle(object? sender, EventArgs e) => await startCycleInner();

	private async Task startCycleInner()
	{
        isFirstWorkTime = true;
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
            bool storedMusicState = musicHasBeenPause;
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
                    isFirstWorkTime = false;
                    musicModel.stopMusic();
                    storedMusicState = musicHasBeenPause;
                    musicHasBeenPause = true;
                    musicModel.playSound();
                    await runBreakTime(breakMinutes, breakSeconds, resetToken.Token);
                    musicHasBeenPause = storedMusicState;
                }
                SessionComplete();
                musicModel.playDoubleSound();
                timerHasStarted = false;
            } catch (OperationCanceledException)
            {
                timerModel.resetTime();
                SessionComplete();
                musicModel.stopMusic();
                musicHasBeenPause = storedMusicState;
                timerHasStarted = false;
            }


        }
    }

    public void manageMusic(object? sender, EventArgs e)
    {
        musicModel.manageMusic();
    }

    public void changeToTheme1(object? sender, EventArgs e)
    {
        setAndSaveTheme(1);
    }

    public void changeToTheme2(object? sender, EventArgs e)
    {
        setAndSaveTheme(2);
    }

    public void changeToTheme3(object? sender, EventArgs e)
    {
        setAndSaveTheme(3);
    }

    private void setAndSaveTheme(int theme)
    {
        view.setTheme(themeModel.selectTheme(theme));
        Properties.Settings.Default.Theme = theme;
        Properties.Settings.Default.Save();
    }

    public void skipMusic(object? sender, EventArgs e)
    {
        musicModel.playNext();
        musicHasBeenPause = false;
        view.setButtonToPauseMusic();
    }

    public void playPreviousMusic(object? sender, EventArgs e)
    {
        musicModel.playPreviousMusic();
        musicHasBeenPause = false;
        view.setButtonToPauseMusic();
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
        if(!isFirstWorkTime)
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
        if(!musicHasBeenPause)
        {
            resumeMusic(sender, e);
        }
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
