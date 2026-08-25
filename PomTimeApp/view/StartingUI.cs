using PomTimeApp.view;
using System.Diagnostics;

namespace PomTimeApp;

// this class is what most of the other view have to talk
// to in order to talk to the control
public partial class StartingUI : Form
{
    //Used to keep track of the location
    //for the small work screen
    Point workTimeFormLocation;

    //used to keep track of where the normal
    //size screen for the break, settingUp
    // and setting screen is
    Point regularFormLocation;

    //keep track of what page/screen
    //the user is currently in
    screenState currScreen;

    // use to store the size of if the
    // screen cannot resize at the current moment
    Size? pendingSize;

    //use to keep track of the curren screen size
    Size currentScreenSize;

    //use to keep track of the size of all the screen
    Dictionary<UserControl, Size> sizeOfUserControl = new();

    //intilizing all the pages
    private breakTimeScreen breakTimeScreen = new breakTimeScreen();
    private WorkTimeScreen workTimeScreen = new WorkTimeScreen();
    private settingUpScreen settingUpScreen = new settingUpScreen();
    private settingScreen settingScreen = new settingScreen();

    //Event for the setting up screen to talk to 
    //controller
    public EventHandler? userPressedStart;

    //Event for the work and break screen to talk to 
    //controller
    public EventHandler? userPressedPause;
    public EventHandler? userPressedResume;
    public EventHandler? userPressedReset;

    //Event exclusively for the work screen to talk to 
    //controller
    public EventHandler? resumeMusic;
    public EventHandler? pauseMusic;
    public EventHandler? skipMusic;
    public EventHandler? playPreviousMusic;

    //Event for the setting screens to talk to 
    //controller
    public EventHandler? theme1Pressed;
    public EventHandler? theme2Pressed;
    public EventHandler? theme3Pressed;
    public EventHandler? manageMusicPressed;
    public EventHandler? manageBreakPressed;


    //WHAT IS IT DOING?:
    //Record all the screen size of all the pages.
    //================================================
    //Set the default position of the normal window 
    //to be in the center of the screen
    //================================================
    //Set the work screen to be around the top right
    //of the screen
    //================================================
    //Prevent the user from resizing and maximizing
    //Wired up all of the event handler from the four
    //screen(user control)
    public StartingUI()
    {
        sizeOfUserControl[settingScreen] = settingScreen.Size;
        sizeOfUserControl[settingUpScreen] = settingUpScreen.Size;
        sizeOfUserControl[workTimeScreen] = workTimeScreen.Size;
        sizeOfUserControl[breakTimeScreen] = breakTimeScreen.Size;
        currentScreenSize = sizeOfUserControl[settingUpScreen];

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

    //send this message to controller
    private void ManageMusicPressed(object? sender, EventArgs e) {
        manageMusicPressed?.Invoke(sender, e);
    }

    //send this message to controller
    private void changeToTheme1(object? sender, EventArgs e)
    {
        theme1Pressed?.Invoke(sender, e);
    }

    //send this message to controller
    private void changeToTheme2(object? sender, EventArgs e)
    {
        theme2Pressed?.Invoke(sender, e);
    }

    //send this message to controller
    private void changeToTheme3(object? sender, EventArgs e)
    {
        theme3Pressed?.Invoke(sender, e);
    }

    //switches the userControl to the settingUpScreen
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

    //this mtheod is use to wired the eventhandler settingUpScreen.userPressedSetting 
    //to switchToSettingsScreen();
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



    // Input: one of the view that is classified as
    // a user control
    // Output: None
    // Purpose: Changes what the application is
    // presenting to one of the other view
    private void switchScreen(UserControl control)
    {
        Size originalSize = sizeOfUserControl[control];
        currentScreenSize = originalSize;

        //Debug.WriteLine($"[switchScreen] control={control.Name}, originalSize={originalSize}, WindowState={WindowState}");

        Controls.Clear();
        control.Dock = DockStyle.Fill;
        Controls.Add(control);

        if (!IsHandleCreated || WindowState == FormWindowState.Normal)
        {
            ClientSize = originalSize;
            //Debug.WriteLine($"[switchScreen] Applied immediately: ClientSize={ClientSize}");
        }
        else
        {
            pendingSize = originalSize;
            //Debug.WriteLine($"[switchScreen] Applied immediately: ClientSize={ClientSize}");
        }
    }

    // basically make it so the window won't resize
    // until the window is normal(ie, window is not maximize or minimize)
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        //Debug.WriteLine($"[OnResize] WindowState={WindowState}, Location={Location}, Bounds={Bounds}, ClientSize={ClientSize}");

        if (WindowState == FormWindowState.Normal)
        {
            if (!IsHandleCreated)
            {
                // No handle yet — safe to apply directly, no reentrancy risk pre-handle
                if (pendingSize.HasValue)
                {
                    ClientSize = pendingSize.Value;
                    pendingSize = null;
                }
                else if (ClientSize != currentScreenSize)
                {
                    ClientSize = currentScreenSize;
                }
                return;
            }

            if (pendingSize.HasValue)
            {
                Size size = pendingSize.Value;
                pendingSize = null;
                BeginInvoke(new Action(() => { ClientSize = size; }));
            }
            else if (ClientSize != currentScreenSize)
            {
                Size size = currentScreenSize;
                BeginInvoke(new Action(() => { ClientSize = size; }));
            }
        }

        //Debug.WriteLine($"[OnResize] AFTER: Location={Location}, Bounds={Bounds}, ClientSize={ClientSize}");
    }

    //allows the control to get the input work minutes
    public int getWorkMinutes()
    {
        int workMinutes = settingUpScreen.getWorkMinutes();
        return workMinutes;
    }

    //allows the control to get the input work seconds
    public int getWorkSeconds()
    {
        int workSeconds = settingUpScreen.getWorkSeconds();
        return workSeconds;
    }

    //allows the control to get the input break minutes
    public int getBreakMinutes()
    {
        int breakMinutes = settingUpScreen.getBreakMinutes();
        return breakMinutes;
    }

    //allows the control to get the input break seconds
    public int getBreakSeconds()
    {
        int breakSeconds = settingUpScreen.getBreakSeconds();
        return breakSeconds;
    }

    //allows the control to get the input nubmer of session
    public int getSession()
    {
        int session = settingUpScreen.getSession();
        return session;
    }

    // used to allow the controller
    // to be able to manipulate the
    // workScreen Pause/Resume
    // button appearance
    public void setButtonToPauseMusic()
    {
        workTimeScreen.setButtonToPauseMusic();
    }

    //allows workScreen userControl to communicate
    //to the controller that the user has pressed
    //the skip button
    public void handleSkipMusic(object? sender, EventArgs e)
    {
        skipMusic?.Invoke(this, e);
    }

    //allows workScreen userControl to communicate
    //to the controller that the user has pressed
    //the play previous button
    public void handlePlayPreviousMusic(object? sender, EventArgs e)
    {
        playPreviousMusic?.Invoke(this, e);
    }

    //allows workScreen userControl to communicate
    //to the controller that the user has pressed
    //the play/pause button when the music was pause
    public void userPressedResumeMusic(object? sender, EventArgs e)
    {
        resumeMusic?.Invoke(this, EventArgs.Empty);
    }

    //allows workScreen userControl to communicate
    //to the controller that the user has pressed
    //the play/pause button when the music was playing
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

    //allows the controller to talk to the work
    //screen that there is one minutes left
    //to work time and it should make
    //preperation like pulling up the reminder
    //stickynotes
    public void enableOneMinutesWarning()
    {
        workTimeScreen.enableOneminutesWarning();
    }

    //tell the workTime screen that work time has
    //ended
    public void disableOneminutesWarning()
    {
        workTimeScreen.disableOneminutesWarning();
    }

    //allows the the setting up screen to comunicate to the
    //with the controller that the user want to start
    //the session
    public void startBtn_Click(object? sender, EventArgs e)
    {
        userPressedStart?.Invoke(this, EventArgs.Empty);
    }

    //allows the workscreen and the breakcreen to to communicate
    //with the controller that the user wants to pause the time
    public void resumeButtonClick(object? sender, EventArgs e)
    {
        userPressedResume?.Invoke(this, EventArgs.Empty);
    }

    //swiches to work screen set the the timer to 
    //be on the top right or where the user put it
    //and store the location of where the user put
    //the normal screen
    public void switchToWorkScreen()
    {
        switchToWorkTimeFormLocation();
        switchScreen(workTimeScreen);
        MaximizeBox = false;
        WindowState = FormWindowState.Normal;
        currScreen = screenState.workTime;
    }

    //swich the break screen ask the screen to
    //show a picture of what acitivy to do 
    //from the break actitivy folder.
    //maximized the screen. and store the location
    //of where the user puts the work screen
    public void switchToBreakScreen()
    {
        Debug.WriteLine("breakScreen");
        switchToRegularFormLocation();
        switchScreen(breakTimeScreen);
        WindowState = FormWindowState.Maximized;
        breakTimeScreen.startAnActivity();
        MaximizeBox = true;
        currScreen = screenState.breakTime;
    }

    //store the where the user puts the dead
    //the break screen. switch to setting up screen
    //and make the window state be normal
    public void switchToSettingUpScreen()
    {
        switchToRegularFormLocation();
        switchScreen(settingUpScreen);
        WindowState = FormWindowState.Normal;
        MaximizeBox = false;
        currScreen = screenState.settingUp;
    }

    //store the where the user puts the dead
    //the break screen. switch to settings screen
    //and make the window state be normal
    public void switchToSettingsScreen()
    {
        switchToRegularFormLocation();
        switchScreen(settingScreen);
        WindowState = FormWindowState.Normal;
        MaximizeBox = false;
        currScreen = screenState.settings;
    }

    //This is used to to save the current position
    //of the workTimeScreen or the regular screen
    //before moving the current application to 
    //the saved location for the workTimeScreen
    private void switchToWorkTimeFormLocation()
    {
        Point currentLocation = (WindowState == FormWindowState.Minimized) ? RestoreBounds.Location : Location;

        if (currScreen == screenState.workTime)
        {
            workTimeFormLocation = currentLocation;
        }
        else if (currScreen != screenState.breakTime)
        {
            regularFormLocation = currentLocation;
        }
        Location = workTimeFormLocation;
    }

    //This is used to to save the current position
    //of the workTimeScreen or the regular screen
    //before moving the current application to 
    //the saved location for aplication
    private void switchToRegularFormLocation()
    {
        Point currentLocation = (WindowState == FormWindowState.Minimized) ? RestoreBounds.Location: Location;
        if (currScreen == screenState.workTime)
        {
            workTimeFormLocation = currentLocation;
        } 
        else if (currScreen != screenState.breakTime)
        {
            regularFormLocation = currentLocation;
        }
        Location = regularFormLocation;
    }

    //allows the controller to minimize the box
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

    //allows the break and work screen to communicate that 
    //the user wants to pause the time
    private void pauseBtn_Click(object? sender, EventArgs e)
    {
        userPressedPause?.Invoke(this, EventArgs.Empty);
    }

    //allows the break and work screen to communicate that 
    //the user wants to reset the time and go back to the 
    //setting up screen
    public void resetButtonClick(object? sender, EventArgs e)
    {
        userPressedReset?.Invoke(this, EventArgs.Empty);
    }

    //allows the user to access this form screen state
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

    //allow people to get the displayed time
    //in the current screen
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
