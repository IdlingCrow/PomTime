using System.Diagnostics;
using System.Windows.Media.Animation;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PomTimeApp;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class startingUITest
{

    [ClassInitialize]
    public static void ClassSetup(TestContext context)
    {
        new StickyNotesTest().runAll();
        new workTimeScreenTest().runAll();
        new breakTimeScreenTest().runAll();
        new settingScreenTest().runAll();
        new settingUpScreenTest().runAll();
    }

    [TestMethod]
    public void intilaizationForStartingUI()
    {
        StartingUI view = new StartingUI();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        breakTimeScreen breakTimeScreen = view.GetBreakTimeScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();
        settingScreen settingScreen = view.GetSettingScreen();

        Assert.AreEqual("Setting up", view.getScreenState(), "current screen is not settingUp screen after intialization");

        //check for settingUpScreen Listener
        checkIfEventHandlerHaveListener(settingUpScreen.userPressedStart, "settingUpScreen.userPressedStart");
        checkIfEventHandlerHaveListener(settingUpScreen.userPressedSetting, "settingUpScreen.userPressedSetting");

        //Check for settingScreen Listener
        checkIfEventHandlerHaveListener(settingScreen.userPressedTheme1, "settingScreen.userPressedTheme1");
        checkIfEventHandlerHaveListener(settingScreen.userPressedTheme2, "settingScreen.userPressedTheme2");
        checkIfEventHandlerHaveListener(settingScreen.userPressedTheme3, "settingScreen.userPressedTheme3");
        checkIfEventHandlerHaveListener(settingScreen.backButtonPressed, "settingScreen.backButtonPressed");
        checkIfEventHandlerHaveListener(settingScreen.userPressedManageMusic, "settingScreen.userPressedManageMusic");

        //check for breakTimeScreen listener 
        checkIfEventHandlerHaveListener(breakTimeScreen.UserPressedPause, "breakTimeScreen.UserPressedPause");
        checkIfEventHandlerHaveListener(breakTimeScreen.UserPressedResume, "breakTimeScreen.UserPressedResume");
        checkIfEventHandlerHaveListener(breakTimeScreen.UserPressedReset, "breakTimeScreen.UserPressedReset");

        //check for workTimeScreen listner
        checkIfEventHandlerHaveListener(workTimeScreen.UserPressedPause, "workTimeScreen.UserPressedPause");
        checkIfEventHandlerHaveListener(workTimeScreen.UserPressedReset, "workTimeScreen.UserPressedReset");
        checkIfEventHandlerHaveListener(workTimeScreen.UserPressedResume, "workTimeScreen.UserPressedResume");
    }

    [TestMethod]
    public void switchingBetweenScreenForStartingUI()
    {
        StartingUI view = new StartingUI();

        view.switchToWorkScreen();
        Assert.AreEqual("Work", view.getScreenState(), "current screen is not idicated as work after switchToWorkScreen() was called");
        view.switchToBreakScreen();
        Assert.AreEqual("Break", view.getScreenState(), "current screen is not idicated as break after switchToBreakScreen(); was called");
        view.switchToSettingsScreen();
        Assert.AreEqual("Settings", view.getScreenState(), "current screen is not idicated as settings after switchToSettingsScreen() was called");
        view.switchToSettingUpScreen();
        Assert.AreEqual("Setting up", view.getScreenState(), "current screen is not idicated as settingUp after switchToSettingUpScreen() was called");
    }

    [TestMethod]
    public void SettingUpScreenStartButtonTestForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        Button startButton = settingUpScreen.getStartButton();
        bool startButtonIsPressed = false;
        view.userPressedStart += (sender, e) => {startButtonIsPressed = true;};

        startButton.PerformClick();

        Assert.IsTrue(startButtonIsPressed, "startingUI did not detect start being pressed in settingUp Screen");
    }

    [TestMethod]
    public void SettingUpScreenSettingButtonForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        Button settingButton = settingUpScreen.getSettingButton();

        settingButton.PerformClick();
        Assert.AreEqual("Settings", view.getScreenState(), "current screen is not dectected as settings screen after pressing the cog icon");
    }

    [TestMethod]
    public void settingScreenButtonInteractionForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        Button settingButton = settingUpScreen.getSettingButton();

        settingButton.PerformClick();

        settingScreen settingScreen = view.GetSettingScreen();
        Button theme1_Btn = settingScreen.getTheme1Button();
        Button theme2_Btn = settingScreen.getTheme2Button();
        Button theme3_Btn = settingScreen.getTheme3Button();
        Button manageMusic = settingScreen.getMusicManagementButton();
        Button backButton = settingScreen.getBackButton();
        bool theme1Pressed = false;
        bool theme2Pressed = false;
        bool theme3Pressed = false;
        bool manageMusicClicked = false;

        view.theme1Pressed += (sender,e) => {theme1Pressed = true;};
        view.theme2Pressed += (sender,e) => {theme2Pressed = true;};
        view.theme3Pressed += (sender,e) => {theme3Pressed = true;};
        view.manageMusicPressed += (sender,e) => {manageMusicClicked = true;};

        theme1_Btn.PerformClick();
        theme2_Btn.PerformClick();
        theme3_Btn.PerformClick();
        manageMusic.PerformClick();
        

        Assert.IsTrue(theme1Pressed, "theme 1 button pressed message is not being delivered from startingUI after after pressing 1 in settings screen");
        Assert.IsTrue(theme2Pressed, "theme 2 button pressed message is not being delivered from startingUI after after pressing 1 in settings screen");
        Assert.IsTrue(theme3Pressed, "theme 3 button pressed message is not being delivered from startingUI after pressing 1 in settings screen");
        Assert.IsTrue(manageMusicClicked, "manage music pressed messsage is not being deliverd from startingUI after pressing manage in the music section in setting screen");

        backButton.PerformClick();

        Assert.AreEqual("Setting up", view.getScreenState(), "current window should indicate that it is in settingUp screen after pressing back arrow button in settingUp screen");
    }

    [TestMethod]
    public void WorkTimerControlForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        view.switchToWorkScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();

        Button pauseButton = workTimeScreen.getPauseButton();
        Button resumeButton = workTimeScreen.getResumeButton();
        Button resetButton = workTimeScreen.getResetButton();

        bool pressedPause = false;
        bool pressedResume = false;
        bool pressedReset = false;

        view.userPressedPause += (sender,e) => {pressedPause = true;};
        view.userPressedResume += (sender, e) => {pressedResume = true;};
        view.userPressedReset += (sender, e) => {pressedReset = true;};

        pauseButton.PerformClick();
        resumeButton.PerformClick();
        pauseButton.PerformClick();
        resetButton.PerformClick();

        Assert.IsTrue(pressedPause, "Pressing pause in workscreen does not invoke a the userPressedPause eventHandler");
        Assert.IsTrue(pressedResume, "Pressing resume in workscreen does not invoke a the userPressedResume eventHandler");
        Assert.IsTrue(pressedReset, "Pressing reset in workscreen does not invoke a the userPressedReset eventHandler");
    }

    [TestMethod]
    public void BreakTimerControlForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        view.switchToWorkScreen();
        breakTimeScreen breakTimeScreen = view.GetBreakTimeScreen();

        Button pauseButton = breakTimeScreen.getPauseButton();
        Button resumeButton = breakTimeScreen.getResumeButton();
        Button resetButton = breakTimeScreen.getResetButton();

        bool pressedPause = false;
        bool pressedResume = false;
        bool pressedReset = false;

        view.userPressedPause += (sender,e) => {pressedPause = true;};
        view.userPressedResume += (sender, e) => {pressedResume = true;};
        view.userPressedReset += (sender, e) => {pressedReset = true;};

        pauseButton.PerformClick();
        resumeButton.PerformClick();
        pauseButton.PerformClick();
        resetButton.PerformClick();

        Assert.IsTrue(pressedPause, "Pressing pause in breakScreen does not invoke a the userPressedPause eventHandler");
        Assert.IsTrue(pressedResume, "Pressing resume in breakScreen does not invoke a the userPressedResume eventHandler");
        Assert.IsTrue(pressedReset, "Pressing reset in breakScreen does not invoke a the userPressedReset eventHandler");
    }

    [TestMethod]
    public void WorkMusicControlButtonInteractionForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        view.switchToWorkScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();

        Button pauseMusicButton = workTimeScreen.getPauseMusicButton();
        Button playPreviousButton = workTimeScreen.getPreviousTrackButton();
        Button skipMusicButton = workTimeScreen.getSkipButton();

        bool pauseMusicCalled = false;
        bool playMusicCalled = false;
        bool playPreviousCalled = false;
        bool skipMusicCalled = false;

        view.resumeMusic += (sender, e) => {playMusicCalled = true;};
        view.pauseMusic += (sender, e) => {pauseMusicCalled = true;};
        view.playPreviousMusic += (sender, e) => {playPreviousCalled = true;};
        view.skipMusic += (sender, e) => {skipMusicCalled = true;};



        if(pauseMusicButton.Text.Equals("▶"))
        {
            pauseMusicButton.PerformClick();
            Assert.IsTrue(pauseMusicCalled, "pause music is not called from startingUI after user pressed ▶ on work screen");
            pauseMusicButton.PerformClick();
            Assert.IsTrue(playMusicCalled, "play music is not called from startingUI after user pressed ⏸ on work screen");
        } 
        else
        {
            pauseMusicButton.PerformClick();
            Assert.IsTrue(playMusicCalled, "play music is not called from startingUI after user pressed ⏸ on work screen");
            pauseMusicButton.PerformClick();
            Assert.IsTrue(pauseMusicCalled, "pause music is not called from startingUI after user pressed ▶ on work screen");
        }

        skipMusicButton.PerformClick();
        Assert.IsTrue(skipMusicCalled, "skip music message not called from startingUI after user pressed ▶I");
        playPreviousButton.PerformClick();
        Assert.IsTrue(playPreviousCalled, "play previous music message not called from startingUI after user pressed I◀");
    }

    [TestMethod]
    public void changeThemeForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        breakTimeScreen breakTimeScreen = view.GetBreakTimeScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();
        settingScreen settingScreen = view.GetSettingScreen();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();

        view.setTheme([Color.FromArgb(0,0,0), Color.FromArgb(255,255,255)]);

        Color[] colorOfBreakTimeScreen = breakTimeScreen.getBackgroundAndForeGroundTheme();
        Color[] colorOfWorkTimeScreen = workTimeScreen.getBackgroundAndForeGroundTheme();
        Color[] colorOfSettingScreen = settingScreen.getBackgroundAndForeGroundTheme();
        Color[] colorOfSettingUpScreen = settingUpScreen.getBackgroundAndForeGroundTheme();

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfBreakTimeScreen[0], "background color for breakTimeScreen is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfBreakTimeScreen[1], "foreground color for breakTimeScreen is not is not the same as input");
        
        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfWorkTimeScreen[0], "background color for WorkTimeScreen is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfWorkTimeScreen[1], "foreground color for WorkTimeScreen is not is not the same as input");

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfSettingScreen[0], "background color for settingScreen is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfSettingScreen[1], "foreground color for settingScreen is not is not the same as input");

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfSettingUpScreen[0], "background color for settingUpScreen is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfSettingUpScreen[1], "foreground color for settingUpScreen is not is not the same as input");
    }

    [TestMethod]
    public void GetInputTestForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();

        int workMinutes = settingUpScreen.getWorkMinutes();
        int workSeconds = settingUpScreen.getWorkSeconds();
        int breakMinutes = settingUpScreen.getBreakMinutes();
        int breakSeconds = settingUpScreen.getBreakSeconds();
        int sessions = settingUpScreen.getSession();

        Assert.AreEqual(workMinutes, view.getWorkMinutes(), "startingUI getWorkMinutes is not the same as settingUpScreen getWorkMinutes");
        Assert.AreEqual(workSeconds, view.getWorkSeconds(), "startingUI getWorkSeconds is not the same as settingUpScreen getWorkSeconds");
        Assert.AreEqual(breakMinutes, view.getBreakMinutes(), "startingUI getBreakMinutes is not the same as settingUpScreen getBreakMinutes");
        Assert.AreEqual(breakSeconds, view.getBreakSeconds(), "startingUI getBreakSeconds is not the same as settingUpScreen getBreakSeconds");
        Assert.AreEqual(sessions, view.getSession(), "startingUI getSession is not the same as settingUpScreen getSession");
    }

    [TestMethod]
    public void setButtonToPauseMusicForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();
        breakTimeScreen breakTimeScreen = view.GetBreakTimeScreen();
        Button pauseMusicButton = workTimeScreen.getPauseMusicButton();
        pauseMusicButton.Text = "None";
        view.setButtonToPauseMusic();

        Assert.AreEqual("▶", pauseMusicButton.Text, "did not change ▶ after calling setButtonToPauseMusic from startingUI");
        
    }

    [TestMethod]
    public void changingAndGettingTimeFunctionForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();
        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();
        breakTimeScreen breakTimeScreen = view.GetBreakTimeScreen();

        Button workButton = settingUpScreen.getWorkInputButton();
        workButton.PerformClick();

        Assert.AreEqual(settingUpScreen.getDisplayed_timer(), view.getDisplayed_timer(), "getDisplayed_timer method of startingUI did not get timer label from settingUpScreen when application is on settingUpScreen");

        view.switchToBreakScreen();
        view.changeDisplayedTime("hello1");
        Assert.AreEqual("hello1", breakTimeScreen.getDisplayed_timer(), "breakTime time label by calling changeDisplayedTime is not change after switching to break screen");
        Assert.AreEqual("hello1", view.getDisplayed_timer(), "getDisplayed_timer method of startingUI did not get timer label from breakTimeScreen when application is on break screen");

        view.switchToWorkScreen();
        view.changeDisplayedTime("hello2");
        Assert.AreEqual("hello2", workTimeScreen.getDisplayed_timer(), "workTime time label by calling changeDisplayedTime is not change after switching to work screen");
        Assert.AreEqual("hello2", view.getDisplayed_timer(), "getDisplayed_timer method of startingUI did not get timer label from workTimeScreen when application is on work screen");

    }

    [TestMethod]
    public void deMaximizeBoxTestForStartingUI()
    {
        StartingUI view = new StartingUI();
        view.Show();

        view.WindowState = FormWindowState.Minimized;
        view.deMaximizeBox();

        Assert.AreEqual(FormWindowState.Normal, view.WindowState, "window state is not normal after calling deMaximizeBox");
    }

    public void checkIfEventHandlerHaveListener(EventHandler? targetEvent, string EventHandlerName)
    {
        Assert.IsGreaterThan(0, targetEvent?.GetInvocationList().Length ?? 0, EventHandlerName + " does not have any listener in startingUi");
    }
}