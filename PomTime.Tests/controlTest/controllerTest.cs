using PomTimeApp;
using PomTimeApp.model;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class controllerTest
{

    [ClassInitialize]
    public static async Task ClassSetup(TestContext context)
    {
        new startingUITest().RunAll();
        System.Threading.SynchronizationContext.SetSynchronizationContext(null);

        new activityModelTest().getBreakActivityForActivityModel();
        new themeModelTest().selectThemeTestForThemeModel();
        await new musicModelTest().testAll();
        new timeModelTest().testAll();
    }

    [TestMethod]
    public void initializationTestForController()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(25,0,5,0, testTimer);
        stickyNotes stickyNotes = new stickyNotes();
        SoundModel musicModel = new SoundModel();
        ThemeModel themeModel = new ThemeModel();
        StartingUI view = new StartingUI();

        Controller controller = new Controller(view, timeModel, musicModel, stickyNotes, themeModel);

        //checking if all the eventHandler have listner
        checkIfEventHandlerHaveListener(view.userPressedStart, "view.userPressedStart");
        checkIfEventHandlerHaveListener(view.userPressedPause, "view.userPressedPause");
        checkIfEventHandlerHaveListener(view.userPressedResume, "view.userPressedResume");
        checkIfEventHandlerHaveListener(view.userPressedReset, "view.userPressedReset");
        checkIfEventHandlerHaveListener(view.resumeMusic, "view.resumeMusic");
        checkIfEventHandlerHaveListener(view.pauseMusic, "view.pauseMusic");
        checkIfEventHandlerHaveListener(view.skipMusic, "view.skipMusic");
        checkIfEventHandlerHaveListener(view.playPreviousMusic, "view.playPreviousMusic");
        checkIfEventHandlerHaveListener(view.theme1Pressed, "view.theme1Pressed");
        checkIfEventHandlerHaveListener(view.theme2Pressed, "view.theme2Pressed");
        checkIfEventHandlerHaveListener(view.theme3Pressed, "view.theme3Pressed");
        checkIfEventHandlerHaveListener(view.manageMusicPressed, "view.manageMusicPressed");
    }

    [TestMethod]
    public void ChangeThemeForController()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(25,0,5,0, testTimer);
        stickyNotes stickyNotes = new stickyNotes();
        SoundModel musicModel = new SoundModel();
        ThemeModel themeModel = new ThemeModel();
        StartingUI view = new StartingUI();

        Controller controller = new Controller(view, timeModel, musicModel, stickyNotes, themeModel);


    }



    [TestMethod]
    public void transitionControlTestForController()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(25,0,5,0, testTimer);
        stickyNotes stickyNotes = new stickyNotes();
        SoundModel musicModel = new SoundModel();
        ThemeModel themeModel = new ThemeModel();
        StartingUI view = new StartingUI();
        view.Show();

        Controller controller = new Controller(view, timeModel, musicModel, stickyNotes, themeModel);

        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();

        Button startButton = settingUpScreen.getStartButton();

        startButton.PerformClick();

        int[] sessionInfo = controller.getTimePreset();

        Assert.AreEqual("Work", view.getScreenState(), "screen should be switched to work after pressing start");
        Assert.AreEqual($"{sessionInfo[0]:D2}:{sessionInfo[1]:D2}", workTimeScreen.getDisplayed_timer(), "The inputted time should match with the displayed time");
    }

    [TestMethod]
    public void musicControlTestForController()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(25,0,5,0, testTimer);
        stickyNotes stickyNotes = new stickyNotes();
        SoundModel musicModel = new SoundModel();
        ThemeModel themeModel = new ThemeModel();
        StartingUI view = new StartingUI();
        view.Show();

        Controller controller = new Controller(view, timeModel, musicModel, stickyNotes, themeModel);

        settingUpScreen settingUpScreen = view.GetSettingUpScreen();
        WorkTimeScreen workTimeScreen = view.GetWorkTimeScreen();

        Button startButton = settingUpScreen.getStartButton();
        Button pauseButton = workTimeScreen.getPauseMusicButton(); 

        startButton.PerformClick();
        pauseButton.PerformClick();

        Assert.IsFalse(musicModel.isPlayingMusic(), "music is still playing after pressing pause");

        pauseButton.PerformClick();

        Assert.IsTrue(musicModel.isPlayingMusic(), "music should be playing after pressing resume");
        
    }

    public void checkIfEventHandlerHaveListener(EventHandler? targetEvent, string EventHandlerName)
    {
        Assert.IsGreaterThan(0, targetEvent?.GetInvocationList().Length ?? 0, EventHandlerName + " does not have any listener in startingUi");
    }
}
