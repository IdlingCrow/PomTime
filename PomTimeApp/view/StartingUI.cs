using PomTimeApp.view;
using System.Diagnostics;

namespace PomTimeApp;

// this class is what most of the other view have to talk
// to in order to talk to the control
public partial class StartingUI : Form
{
    Point workTimeFormLocation;
    Point regularFormLocation;
    screenState currScreen;
    private breakTimeScreen breakTimeScreen = new breakTimeScreen();
    private WorkTimeScreen workTimeScreen = new WorkTimeScreen();
    private settingUpScreen settingUpScreen = new settingUpScreen();
    private settingScreen settingScreen = new settingScreen();

    public EventHandler? userPressedStart;
    public EventHandler? userPressedPause;
    public EventHandler? userPressedResume;
    public EventHandler? userPressedReset;
    public EventHandler? resumeMusic;
    public EventHandler? pauseMusic;
    public EventHandler? skipMusic;
    public EventHandler? playPreviousMusic;
    public EventHandler? theme1Pressed;
    public EventHandler? theme2Pressed;
    public EventHandler? theme3Pressed;
    public EventHandler? manageMusicPressed;
    public EventHandler? manageBreakPressed;
    public StartingUI()
    {
        //setting the default location of the app being the center of the screen
        StartPosition = FormStartPosition.CenterScreen;
        regularFormLocation = Location;

        //getting the user screens dimension
        int userScreenWidth = Screen.PrimaryScreen?.Bounds.Width ?? 0;
        int userScreenHeight = Screen.PrimaryScreen?.Bounds.Height ?? 0;

        //setting a default position for the work timer
        workTimeFormLocation = new Point((userScreenWidth - (userScreenWidth / 6)), userScreenHeight / 25);

        //stops user from resizing a screen a maximizing the screen
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        InitializeComponent();
        switchScreen(settingUpScreen);
        currScreen = screenState.settingUp;

        //assigning all of the button pressed event for the setting screen
        settingScreen.backButtonPressed += goingBackToSettingUp;
        settingScreen.userPressedTheme1 += changeToTheme1;
        settingScreen.userPressedTheme2 += changeToTheme2;
        settingScreen.userPressedTheme3 += changeToTheme3;
        settingScreen.userPressedManageMusic += ManageMusicPressed;

        //assigning all of the button pressed event for the input screen
        settingUpScreen.userPressedStart += startBtn_Click;
        settingUpScreen.userPressedSetting += settingButtonClick;

        //assigning all of the button pressed event for the work screen
        workTimeScreen.UserPressedPause += pauseBtn_Click;
        workTimeScreen.UserPressedResume += resumeButtonClick;
        workTimeScreen.UserPressedReset += resetButtonClick;
        workTimeScreen.PauseMusic += userPressedPauseMusic;
        workTimeScreen.PlayMusic += userPressedResumeMusic;
        workTimeScreen.SkipMusic += handleSkipMusic;
        workTimeScreen.backMusic += handlePlayPreviousMusic;

        //assigning all of the button pressed event for the break screen
        breakTimeScreen.UserPressedPause += pauseBtn_Click;
        breakTimeScreen.UserPressedResume += resumeButtonClick;
        breakTimeScreen.UserPressedReset += resetButtonClick;

    }

    private void ManageMusicPressed(object? sender, EventArgs e) {
        manageMusicPressed?.Invoke(sender, e);
    }
    private void changeToTheme1(object? sender, EventArgs e)
    {
        theme1Pressed?.Invoke(sender, e);
    }

    private void changeToTheme2(object? sender, EventArgs e)
    {
        theme2Pressed?.Invoke(sender, e);
    }

    private void changeToTheme3(object? sender, EventArgs e)
    {
        theme3Pressed?.Invoke(sender, e);
    }

    private void goingBackToSettingUp(object? sender, EventArgs e)
    {
        switchScreen(settingUpScreen);
    }
    
    // Input: 2 Color in a array
    // output: none
    // purpose: notify all the other winform the switch
    // its current two color theme to the input two
    // color theme
    public void setTheme(Color[] themeColor)
    {
        if(themeColor.Length != 2)
        {
            throw new ArgumentException("setTheme needed array with two colors");
        }
        workTimeScreen.setTheme(themeColor[0], themeColor[1]);
        breakTimeScreen.setTheme(themeColor[0], themeColor[1]);
        settingUpScreen.setTheme(themeColor[0], themeColor[1]);
        settingScreen.setTheme(themeColor[0], themeColor[1]);

    }

    public void settingButtonClick(object? sender, EventArgs e)
    {
        switchToSettingsScreen();
    }

    // essentially this is varible for redabilty, I used this to
    // keep track of the screen state
    private enum screenState
    {
        workTime,
        breakTime,
        settingUp,
        settings
    }

    public void setButtonToPauseMusic()
    {
        workTimeScreen.setButtonToPauseMusic();
    }

    public void handleSkipMusic(object? sender, EventArgs e)
    {
        skipMusic?.Invoke(this, e);
    }

    public void handlePlayPreviousMusic(object? sender, EventArgs e)
    {
        playPreviousMusic?.Invoke(this, e);
    }

    // Input: one of the view that is classified as
    // a user control
    // Output: None
    // Purpose: Changes what the application is
    // presenting to one of the other view
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
        return session;
    }

    public void userPressedResumeMusic(object? sender, EventArgs e)
    {
        resumeMusic?.Invoke(this, EventArgs.Empty);
    }

    public void userPressedPauseMusic(object? sender, EventArgs e)
    {
        pauseMusic?.Invoke(this, EventArgs.Empty);
    }

    // Input: any string
    // Output: none
    // Purpose: this allows for the controller
    // to project the text that display the time
    // in worKTimeScreen and breakTimeScreen
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
        switchToWorkTimeFormLocation();
        switchScreen(workTimeScreen);
        WindowState = FormWindowState.Normal;
        currScreen = screenState.workTime;
    }

    public void switchToBreakScreen()
    {
        switchToRegularFormLocation();
        switchScreen(breakTimeScreen);
        WindowState = FormWindowState.Maximized;
        breakTimeScreen.startAnActivity();
        currScreen = screenState.breakTime;
    }

    public void switchToSettingUpScreen()
    {
        switchToRegularFormLocation();
        switchScreen(settingUpScreen);
        WindowState = FormWindowState.Normal;
        currScreen = screenState.settingUp;
    }

    public void switchToSettingsScreen()
    {
        switchToRegularFormLocation();
        switchScreen(settingScreen);
        WindowState = FormWindowState.Normal;
        currScreen = screenState.settings;
    }

    //This is used to to save the current position
    //of the workTimeScreen or the regular screen
    //before moving the current application to 
    //the saved location for the workTimeScreen
    private void switchToWorkTimeFormLocation()
    {
        if(currScreen != screenState.workTime)
        {
            regularFormLocation = Location;
        } else
        {
            workTimeFormLocation = Location;
        }
        Location = workTimeFormLocation;
    }

    //This is used to to save the current position
    //of the workTimeScreen or the regular screen
    //before moving the current application to 
    //the saved location for aplication
    private void switchToRegularFormLocation()
    {
        if (currScreen == screenState.workTime)
        {
            workTimeFormLocation = Location;
        } else
        {
            regularFormLocation = Location;
        }
        Location = regularFormLocation;
    }

    public void deMaximizeBox()
    {
        WindowState = FormWindowState.Normal;
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
        } else if (currScreen == screenState.workTime)
        {
            return workTimeScreen.getTitle();
        } else
        {
            return "settings";
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
        } else if (currScreen == screenState.settingUp)
        {
            return "Setting up";
        } else
        {
            return "settings";
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
