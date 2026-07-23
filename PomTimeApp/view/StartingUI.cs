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
    public StartingUI()
    {
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        InitializeComponent();
        switchScreen(settingUpScreen);
        settingUpScreen.userPressedStart = startBtn_Click;
        currScreen = screenState.settingUp;
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

    public void changeTitleToBreak()
    {
        BreakOrWorkTimeDispalyed.Text = "Break";
    }

    public void changeTitleToWork()
    {
        BreakOrWorkTimeDispalyed.Text = "Work";
    }

    public void changeTitleToSettingUp()
    {
        BreakOrWorkTimeDispalyed.Text = "Setting up";
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

    public void switchToWorkScreen()
    {
        switchScreen(workTimeScreen);
        currScreen = screenState.workTime;
    }

    public void switchToBreakScreen()
    {
        switchScreen(breakTimeScreen);
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

    private void pauseBtn_Click(object sender, EventArgs e)
    {
        this.Controls.Clear();
        ClientSize = workTimeScreen.Size;
        workTimeScreen.Dock = DockStyle.Fill;
        this.Controls.Add(workTimeScreen);
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
