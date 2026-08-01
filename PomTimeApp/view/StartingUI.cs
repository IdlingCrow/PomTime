using PomTimeApp.view;
using System.Diagnostics;

namespace PomTimeApp;


public partial class StartingUI : Form
{
    screenState currScreen;
    private breakTimeScreen breakTimeScreen = new breakTimeScreen();
    private WorkTimeScreen workTimeScreen = new WorkTimeScreen();
    private settingUpScreen settingUpScreen = new settingUpScreen();

    public EventHandler? userPressedStart;
    public EventHandler? userPressedPause;
    public EventHandler? userPressedResume;
    public EventHandler? userPressedReset;
    public EventHandler? resumeMusic;
    public EventHandler? pauseMusic;
    public StartingUI()
    {
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        InitializeComponent();
        switchScreen(settingUpScreen);

        settingUpScreen.userPressedStart = startBtn_Click;
        workTimeScreen.UserPressedPause = pauseBtn_Click;
        workTimeScreen.UserPressedResume = resumeButtonClick;
        workTimeScreen.UserPressedReset = resetButtonClick;
        workTimeScreen.PauseMusic = userPressedPauseMusic;
        workTimeScreen.PlayMusic = userPressedResumeMusic;

        breakTimeScreen.UserPressedPause = pauseBtn_Click;
        breakTimeScreen.UserPressedResume = resumeButtonClick;
        breakTimeScreen.UserPressedReset = resetButtonClick;
        currScreen = screenState.settingUp;
        this.AutoScaleMode = AutoScaleMode.Dpi;
    }

    private enum screenState
    {
        workTime,
        breakTime,
        settingUp
    }

    private void switchScreen(UserControl control)
    {
        Controls.Clear();
        ClientSize = control.Size;
        control.Dock = DockStyle.Fill;
        Controls.Add(control);
    }

    public int getWorkMinutes()
    {
        int workMinutes = settingUpScreen.getWorkMinutes();
        return workMinutes;
    }
    public int getWorkSeconds()
    {
        int workSeconds = settingUpScreen.getWorkSeconds();
        return workSeconds;
    }

    public int getBreakMinutes()
    {
        int breakMinutes = settingUpScreen.getBreakMinutes();
        return breakMinutes;
    }

    public int getBreakSeconds()
    {
        int breakSeconds = settingUpScreen.getBreakSeconds();
        return breakSeconds;
    }

    public int getSession()
    {
        int session = settingUpScreen.getSession();
        Debug.WriteLine($"getting {session} session");
        return session;
    }

    public void userPressedResumeMusic(object? sender, EventArgs e)
    {
        Debug.WriteLine("resume button have been pressed");
        resumeMusic?.Invoke(this, EventArgs.Empty);
    }

    public void userPressedPauseMusic(object? sender, EventArgs e)
    {
        Debug.WriteLine("pause button have been pressed");
        pauseMusic?.Invoke(this, EventArgs.Empty);
    }
    public void changeDisplayedTime(string time)
    {
        if(currScreen == screenState.breakTime)
        {
            breakTimeScreen.changeDisplayedTime(time);
        } else if (currScreen == screenState.workTime)
        {
            workTimeScreen.changeDisplayedTime(time);
        } else
        {
            Debug.WriteLine("cannot change time when in setting up");
        }
    }

    public void enableOneMinutesWarning()
    {
        workTimeScreen.enableOneminutesWarning();
    }

    public void disableOneminutesWarning()
    {
        workTimeScreen.disableOneminutesWarning();
    }

    public void startBtn_Click(object? sender, EventArgs e)
    {
        userPressedStart?.Invoke(this, EventArgs.Empty);
    }
    public void resumeButtonClick(object? sender, EventArgs e)
    {
        userPressedResume?.Invoke(this, EventArgs.Empty);
    }
    public void switchToWorkScreen()
    {
        switchScreen(workTimeScreen);
        currScreen = screenState.workTime;
    }

    public void switchToBreakScreen()
    {
        switchScreen(breakTimeScreen);
        breakTimeScreen.startAnActivity();
        currScreen = screenState.breakTime;
    }

    public void switchToSettingUpScreen()
    {
        switchScreen(settingUpScreen);
        currScreen = screenState.settingUp;
    }

    //these function is exculsively created for test purposes
    public string getBreakOrWorkTimeDispalyed()
    {
        if(currScreen == screenState.settingUp)
        {
            return settingUpScreen.getTitle();
        } else if (currScreen == screenState.breakTime)
        {
            return breakTimeScreen.getTitle();
        } else //if (currScreen == screenState.workTime)
        {
            return workTimeScreen.getTitle();
        }
    }

    public Color getBackColor()
    {
        return this.BackColor;
    }

    public void performClick()
    {
        startBtn_Click(this, EventArgs.Empty);
    }

    public void performClickWithInput(int workTimeMinutes, int workTimeSeconds, int breakTimeMinutes, int breakTimeSeconds, int sessions)
    {
        settingUpScreen.performClickWithInput(workTimeMinutes, workTimeSeconds, breakTimeMinutes, breakTimeSeconds, sessions);
    }

    private void pauseBtn_Click(object? sender, EventArgs e)
    {
        userPressedPause?.Invoke(this, EventArgs.Empty);
    }

    public void resetButtonClick(object? sender, EventArgs e)
    {
        userPressedReset?.Invoke(this, EventArgs.Empty);
    }

    public string getScreenState()
    {
        if(currScreen == screenState.breakTime)
        {
            return "Break";
        } else if (currScreen == screenState.workTime)
        {
            return "Work";
        } else
        {
            return "Setting up";
        }
    }

    public string getOneMinutesWarner()
    {
        return workTimeScreen.getOneMinutesWarner();
    }

    public string getDisplayed_timer()
    {
        if(currScreen == screenState.workTime)
        {
            return workTimeScreen.getDisplayed_timer();
        } else if (currScreen == screenState.breakTime)
        {
            return breakTimeScreen.getDisplayed_timer();
        } else
        {
            return settingUpScreen.getDisplayed_timer();
        }
    }

}
