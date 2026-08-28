using Microsoft.VisualBasic.ApplicationServices;
using PomTimeApp.model;
using PomTimeApp.view;
using System;
using System.Diagnostics;
namespace PomTimeApp;

//This class faccilitate the talking between the model and view
//This class also do a little bit of the logic of the application too
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
    //use to tell what the current
    //music state is 
    private bool musicHasBeenPause;

    //Used to remember what the music state
    //is during work time. Since break
    //time and input screen will have music
    //turn off which will be reflected in
    //musicHasBeenPause
    private bool storedMusicState;
    private stickyNotes reminderNotes;
    private bool isFirstWorkTime;

    //Used to make the program wait for when break time or work
    //time is done before the program go any further
    private TaskCompletionSource<bool>? workTimeCompletionsSource;
	private TaskCompletionSource<bool>? breakTimeCompletionsSource;

    //Purpose reference all the model, connect all of the listener from
    //the view and the model. Create a cancelation token to skip the
    //the waiting for the work time and break time to finished if the user
    //wants to reset and set a few status
	public Controller(StartingUI startingUI, TimeModel timerModel, SoundModel musicModel, stickyNotes reminderNotes, ThemeModel themeModel)
	{
        this.musicModel = musicModel;
        view = startingUI;
		this.timerModel = timerModel;
        this.reminderNotes = reminderNotes;
        this.themeModel = themeModel;
        resetToken = new CancellationTokenSource();

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

        isFirstWorkTime = true;
        timerHasStarted = false;
        musicHasBeenPause = false;
    }

    // a wrapper class so this can be put in the EventHandler of view.userPressedStart
    public async void startCycle(object? sender, EventArgs e) => await startCycleInner();

    // This start the the sessions
    // it dictate which screen is switched 
    // and when based on the input it recived from
    // the view
	private async Task startCycleInner()
	{
        isFirstWorkTime = true;
        if(!timerHasStarted)
        {
            timerHasStarted = true;
            // getting the input form the view
            int breakMinutes = view.getBreakMinutes();
            int breakSeconds = view.getBreakSeconds();
            int workMinutes = view.getWorkMinutes();
            int workSeconds = view.getWorkSeconds();
            int session = view.getSession();

            saveTimePreset(workMinutes, workSeconds, breakMinutes, breakSeconds, session);

            timerModel.changeTime(workMinutes, workSeconds, breakMinutes, breakSeconds);

            resetToken = new CancellationTokenSource();

            //this is used to keep track of whether music should
            //be playing during work time
            storedMusicState = musicHasBeenPause;

            //This whole chunk under try is how the the the program
            //will act when you press start
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
                    if(i < session - 1)
                    {
                        musicHasBeenPause = true;
                        musicModel.playSound();

                        await runBreakTime(breakMinutes, breakSeconds, resetToken.Token);
                    }
                    musicHasBeenPause = storedMusicState;
                }
                SessionComplete();
                musicModel.playDoubleSound();

            } 
            //This chunk under catch is for then the user
            //press reset to exit out to the Input menu
            //(the SettingUpScreen)
            catch (OperationCanceledException)
            {
                timerModel.resetTime();
                SessionComplete();
                musicModel.stopMusic();
                musicHasBeenPause = storedMusicState;
                Debug.WriteLine(musicHasBeenPause);
                disableOneMinutesWarning();
                isFirstWorkTime = true;
            }
            reminderNotes.resetNotes();
            timerHasStarted = false;




        }
    }

    //Tell the music model to open up the msuic folder
    public void manageMusic(object? sender, EventArgs e)
    {
        musicModel.manageMusic();
    }

    //Tell the startingUI to switch the theme number 1
    //reference by the themeModel
    public void changeToTheme1(object? sender, EventArgs e)
    {
        setAndSaveTheme(1);
    }

    //Tell the startingUI to switch the theme number 2
    //reference by the themeModel
    public void changeToTheme2(object? sender, EventArgs e)
    {
        setAndSaveTheme(2);
    }

    //Tell the startingUI to switch the theme number 3
    //reference by the themeModel
    public void changeToTheme3(object? sender, EventArgs e)
    {
        setAndSaveTheme(3);
    }

    //Input: The theme number
    //Purpose: call another function to set theme an save
    //it for the next time the user open this applcation
    private void setAndSaveTheme(int theme)
    {
        view.setTheme(themeModel.selectTheme(theme));
        Properties.Settings.Default.Theme = theme;
        Properties.Settings.Default.Save();
    }

    //Save the current as user default for the next time the user
    //open the application
    private void saveTimePreset(int workMinutes, int workSeconds, int BreakMinutes, int breakSeconds, int sessions)
    {
        Properties.Settings.Default.workMinutes = workMinutes;
        Properties.Settings.Default.workSeconds = workSeconds;
        Properties.Settings.Default.breakMinutes = BreakMinutes;
        Properties.Settings.Default.breakSeconds = breakSeconds;
        Properties.Settings.Default.sessions = sessions;
        Properties.Settings.Default.Save();
    }

    //Tell the refence music model to play the next track
    public void skipMusic(object? sender, EventArgs e)
    {
        musicModel.playNext();
        musicHasBeenPause = false;
        view.setButtonToPauseMusic();
    }

    //Tell the refence music model to play the previous track
    public void playPreviousMusic(object? sender, EventArgs e)
    {
        musicModel.playPreviousMusic();
        musicHasBeenPause = false;
        view.setButtonToPauseMusic();
    }

    //Tell the music model to resume playing music
    //if the music is off
    public void resumeMusic(object? sender, EventArgs e)
    {
        if (!musicModel.isPlayingMusic()) {
            musicModel.playMusic();
        }
        storedMusicState = false;
        musicHasBeenPause = false;
    }

    //Tell the music model to pause the music if the 
    //music have is not pause
    public void pauseMusic(object? sender, EventArgs e)
    {
        if (musicModel.isPlayingMusic())
        {
            musicModel.stopMusic();
        }
        storedMusicState = true;
        musicHasBeenPause = true;
    }

    //this is used the music model to tell the controller
    //that one seconds has pass and the view should decrease
    //the timer displayed by 1 seconds
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

    //Used when the user pressed reset in workScreen
    //and breakScreen which will cancel the await
    //task of startCycleTimer
    public void resetTimer(object? sender, EventArgs e)
    {
        resetToken.Cancel();
    }

    //This is used for the timer Model to tell the view that there
    //is one mintues left
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


    // this is used to open the Form stickyNotes when there is
    // one inutes left in the work time but to also create a
    // task to ensure the the program doesn't continue until
    // the timer model say that work time is over ( in other word
    //workTimeCompletionsSource.Task is done)
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

    // create a task to ensure the the program doesn't continue until
    // the timer model say that break time is over ( in other word
    //workTimeCompletionsSource.Task is done)
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
	
    //tell the view to switch to work screen
    //is usually called when the timer start
    //or at the end of break time if the session
    //is not over
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

    //tell the view to switch to break screen
    // called when work time is over
    //unless it is the last break time 
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

    //Used to tell the await that the task is done this is called
    //by the timer model when break time is done 
    private void breakSessionTimerDone(object? sender, EventArgs e)
	{
        breakTimeCompletionsSource?.SetResult(true);
    }

    //Used to tell the await that the task is done this is called
    //by the timer model when work time is done 
    private void workSessionTimerDone(object? sender, EventArgs e)
    {
        disableOneMinutesWarning();
        workTimeCompletionsSource?.SetResult(true);
    }

    //used to update the timer on break and work screen
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

    //Used to to turn off the one mintues warning after the work time
    //is done
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

    //Used to indicate when the sessions is complete
    //which will switch to the settingUpScreen
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

    //Used to resume the time if the user pause it
    //additionally play the music if the user 
    //haven't stopped it before starting the time
    public void resumeTimer(object? sender, EventArgs e)
    {
        timerModel.startTime();
        if(!musicHasBeenPause)
        {
            resumeMusic(sender, e);
        }
    }

    //Used to stop the timer
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
