using System.Diagnostics;
using System.Windows.Media;
using System.Drawing;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class settingUpScreenTest
{

    [TestMethod]
    public void intilaizationTestForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();
        int[] defaultSetting = settingUpScreen.getDefaultBreakWorkAndSession();
        Assert.AreEqual(defaultSetting[0], settingUpScreen.getWorkMinutes(), "Did not get the right default work minutes");
        Assert.AreEqual(defaultSetting[1], settingUpScreen.getWorkSeconds(), "Did not get the right default work seconds");
        Assert.AreEqual(defaultSetting[2], settingUpScreen.getBreakMinutes(), "Did not get the right default break minutes");
        Assert.AreEqual(defaultSetting[3], settingUpScreen.getBreakSeconds(), "Did not get the right default break seconds");
        Assert.AreEqual(defaultSetting[4], settingUpScreen.getSession(), "Did not get the right default Sessions");
    }

    [TestMethod]
    public void inputButtonTestForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();

        Button breakInputButton = settingUpScreen.getBreakInputButton();
        Button WorkInputButton = settingUpScreen.getWorkInputButton();
        Button SessionInputButton = settingUpScreen.getSessionInputButton();

        if(WorkInputButton.Enabled == false)
        {
            WorkInputButton.Enabled = true;
        }
        WorkInputButton.PerformClick();
        Assert.AreEqual(settingUpScreen.getWorkMinutes(), Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "minutes label not displaying the stored Work minutes after pressing Work");
        Assert.AreEqual(settingUpScreen.getWorkSeconds(), Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "Seconds label not displaying the stored Work seconds after pressing Work");
        Assert.AreEqual(":", settingUpScreen.getSessionLabel().Text, "Session label not displaying ':' when pressing the Work button");
        Assert.AreEqual($"{settingUpScreen.getWorkMinutes():D2}:{settingUpScreen.getWorkSeconds():D2}", settingUpScreen.getDisplayed_timer(), "Output of dispalyed timer matches the work input");
        Assert.AreEqual("work", settingUpScreen.getInputState(), "pressing work button doesn't change the inputState");
        Assert.IsFalse(WorkInputButton.Enabled, "pressing the work button did not disable the work button");
        Assert.IsTrue(breakInputButton.Enabled, "pressing the session button did not disable the break button");
        Assert.IsTrue(SessionInputButton.Enabled, "pressing the session button did not disable the session button");

        if(breakInputButton.Enabled == false)
        {
            breakInputButton.Enabled = true;
        }
        breakInputButton.PerformClick();
        
        Assert.AreEqual(settingUpScreen.getBreakMinutes(), Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "minutes label not displaying the stored break minutes after pressing break");
        Assert.AreEqual(settingUpScreen.getBreakSeconds(), Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "Seconds label not displaying the stored break seconds after pressing break");
        Assert.AreEqual(":", settingUpScreen.getSessionLabel().Text, "Session label not displaying ':' when pressing the break button");
        Assert.AreEqual("break", settingUpScreen.getInputState(), "pressing break button doesn't change the inputState");
        Assert.AreEqual($"{settingUpScreen.getBreakMinutes():D2}:{settingUpScreen.getBreakSeconds():D2}", settingUpScreen.getDisplayed_timer(), "Output of dispalyed timer matches the break input");
        Assert.IsFalse(breakInputButton.Enabled, "pressing the break button did not disable the break button");
        Assert.IsTrue(WorkInputButton.Enabled, "pressing the session button did not disable the work button");
        Assert.IsTrue(SessionInputButton.Enabled, "pressing the session button did not disable the session button");

        if(SessionInputButton.Enabled == false)
        {
            SessionInputButton.Enabled = true;
        }
        SessionInputButton.PerformClick();
        Assert.IsFalse(settingUpScreen.getMinutesLabel().Visible, "Minutes label not being hidden after pressing the session button ");
        Assert.IsFalse(settingUpScreen.getSecondsLabel().Visible, "Seconds label not being hidden after pressing the session button ");
        Assert.AreEqual(settingUpScreen.getSession(), Convert.ToInt32(settingUpScreen.getSessionLabel().Text), "Session label not displaying amount of session that is being inputted after pressin the session button");
        Assert.AreEqual($"{settingUpScreen.getSession()}", settingUpScreen.getDisplayed_timer(), "Output of dispalyed sessions matches the internal indicator for sessions input");
        Assert.AreEqual("session", settingUpScreen.getInputState(), "pressing session button doesn't change the inputState");
        Assert.IsFalse(SessionInputButton.Enabled, "pressing the session button did not disable the session button");
        Assert.IsTrue(breakInputButton.Enabled, "pressing the session button did not disable the break button");
        Assert.IsTrue(WorkInputButton.Enabled, "pressing the session button did not disable the work button");

    }

    [TestMethod]
    public void changingInputsTestForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();

        //types of input
        Button breakInputButton = settingUpScreen.getBreakInputButton();
        Button WorkInputButton = settingUpScreen.getWorkInputButton();
        Button SessionInputButton = settingUpScreen.getSessionInputButton();

        //time and session input 
        Button increaseMinutes = settingUpScreen.getIncreaseMinutesButton();
        Button decreaseMinutes = settingUpScreen.getDecreaseMinutesBtn();
        Button increaseSeconds = settingUpScreen.getIncreaseSecondsButton();
        Button decreaseSeconds = settingUpScreen.getDecreaseSecondsButton();
        Button increaseSessions = settingUpScreen.getIncreaseSessionButton();
        Button decreaseSessions = settingUpScreen.getDecreaseSessionButton();

        //work input test
        if(WorkInputButton.Enabled == false)
        {
            WorkInputButton.Enabled = true;
        }
        WorkInputButton.PerformClick();
        //button check only the time input should be shown
        Assert.IsTrue(increaseMinutes.Visible, "Button increaseMinutes is not visible after pressing the Work Button");
        Assert.IsTrue(decreaseMinutes.Visible, "Button decreaseMinutes is not visible after pressing the Work Button");
        Assert.IsTrue(increaseSeconds.Visible, "Button increaseSeconds is not visible after pressing the Work Button");
        Assert.IsTrue(decreaseSeconds.Visible, "Button decreaseSeconds is not visible after pressing the Work Button");
        Assert.IsFalse(increaseSessions.Visible, "Button increaseSessions is visible after pressing the Work Button");
        Assert.IsFalse(decreaseSessions.Visible, "Button decreaseSession is visible after pressing the Work Button");

        //if input is being properly recoreded
        int workMinutes = settingUpScreen.getWorkMinutes();
        increaseMinutes.PerformClick();
        Assert.AreEqual(workMinutes + 1, settingUpScreen.getWorkMinutes(), $"Increasing minutes button click suppose to set value to {workMinutes + 1} but instead got {settingUpScreen.getWorkMinutes()} for work input");
        Assert.AreEqual(workMinutes + 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "Increasing minutes button click suppose to Increase display minutes by one mintues not properly reflected for work minutes");

        workMinutes = settingUpScreen.getWorkMinutes();
        decreaseMinutes.PerformClick();
        Assert.AreEqual(workMinutes - 1, settingUpScreen.getWorkMinutes(), $"decrease minutes button click suppose to set value to {workMinutes + 1} but instead got {settingUpScreen.getWorkMinutes()} for work input");
        Assert.AreEqual(workMinutes - 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "decrease minutes button click suppose to decrease display minutes by one mintues not properly reflected for work Minutes");

        int workSeconds = settingUpScreen.getWorkSeconds();
        increaseSeconds.PerformClick();
        Assert.AreEqual(workSeconds + 1, settingUpScreen.getWorkSeconds(), $"Increasing seconds button click suppose to set value to {workSeconds + 1} but instead got {settingUpScreen.getWorkSeconds()} for work input");
        Assert.AreEqual(workSeconds + 1, Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "Increasing seconds button click suppose to Increase display seconds by one second not properly reflected for work seconds");

        workSeconds = settingUpScreen.getWorkSeconds();
        decreaseSeconds.PerformClick();
        Assert.AreEqual(workSeconds - 1, settingUpScreen.getWorkSeconds(), $"decrease seconds button click suppose to set value to {workSeconds + 1} but instead got {settingUpScreen.getWorkSeconds()} for work input");
        Assert.AreEqual(workSeconds - 1, Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "decrease seconds button click suppose to decrease display seconds by one second not properly reflected for for work seconds");

        //break input test
        if(breakInputButton.Enabled == false)
        {
            breakInputButton.Enabled = true;
        }
        breakInputButton.PerformClick();

        //button check only the time input should be shown
        Assert.IsTrue(increaseMinutes.Visible, "Button increaseMinutes is not visible after pressing the Break Button");
        Assert.IsTrue(decreaseMinutes.Visible, "Button decreaseMinutes is not visible after pressing the Break Button");
        Assert.IsTrue(increaseSeconds.Visible, "Button increaseSeconds is not visible after pressing the Break Button");
        Assert.IsTrue(decreaseSeconds.Visible, "Button decreaseSeconds is not visible after pressing the Break Button");
        Assert.IsFalse(increaseSessions.Visible, "Button increaseSessions is visible after pressing the Break Button");
        Assert.IsFalse(decreaseSessions.Visible, "Button decreaseSession is visible after pressing the Break Button");

        //if input is being properly recoreded
        int breakMinutes = settingUpScreen.getBreakMinutes();
        increaseMinutes.PerformClick();
        Assert.AreEqual(breakMinutes + 1, settingUpScreen.getBreakMinutes(), $"Increasing minutes button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakMinutes()} for break input");
        Assert.AreEqual(breakMinutes + 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "Increasing minutes button click suppose to Increase display minutes by one mintues not properly reflected for break minutes");

        breakMinutes = settingUpScreen.getBreakMinutes();
        decreaseMinutes.PerformClick();
        Assert.AreEqual(breakMinutes - 1, settingUpScreen.getBreakMinutes(), $"decrease minutes button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakMinutes()} for break input");
        Assert.AreEqual(breakMinutes - 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "decrease minutes button click suppose to decrease display minutes by one mintues not properly reflected for for break minutes");

        int breakSeconds = settingUpScreen.getBreakSeconds();
        increaseSeconds.PerformClick();
        Assert.AreEqual(breakSeconds + 1, settingUpScreen.getBreakSeconds(), $"Increasing seconds button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakSeconds()} for break input");
        Assert.AreEqual(breakSeconds + 1, Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "Increasing seconds button click suppose to Increase display seconds by one second not properly reflected for break seconds");

        breakSeconds = settingUpScreen.getBreakSeconds();
        decreaseSeconds.PerformClick();
        Assert.AreEqual(breakSeconds - 1, settingUpScreen.getBreakSeconds(), $"decrease seconds button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakSeconds()} for break input");
        Assert.AreEqual(breakSeconds - 1, Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "decrease seconds button click suppose to decrease display seconds by one second not properly reflected for for break seconds");

        //sessions input test
        if(SessionInputButton.Enabled == false)
        {
            SessionInputButton.Enabled = true;
        }
        SessionInputButton.PerformClick();
        
        //button check only the session input should be shown
        Assert.IsFalse(increaseMinutes.Visible, "Button increaseMinutes is not visible after pressing the Session Button");
        Assert.IsFalse(decreaseMinutes.Visible, "Button decreaseMinutes is not visible after pressing the Session Button");
        Assert.IsFalse(increaseSeconds.Visible, "Button increaseSeconds is not visible after pressing the Session Button");
        Assert.IsFalse(decreaseSeconds.Visible, "Button decreaseSeconds is not visible after pressing the Session Button");
        Assert.IsTrue(increaseSessions.Visible, "Button increaseSessions is visible after pressing the Session Button");
        Assert.IsTrue(decreaseSessions.Visible, "Button decreaseSession is visible after pressing the Session Button");

        //if input is being properly recoreded
        int SessionNumber = settingUpScreen.getSession();
        increaseSessions.PerformClick();
        Assert.AreEqual(SessionNumber + 1, settingUpScreen.getSession(), $"Increasing sessions button click suppose to set value to {SessionNumber + 1} but instead got {settingUpScreen.getSession()} for session input");
        Assert.AreEqual(SessionNumber + 1, Convert.ToInt32(settingUpScreen.getSessionLabel().Text), "Increasing sessions button click suppose to Increase display sesions by one not properly reflected for sessions");

        SessionNumber = settingUpScreen.getSession();
        decreaseSessions.PerformClick();
        Assert.AreEqual(SessionNumber - 1, settingUpScreen.getSession(), $"decrease session button click suppose to set value to {SessionNumber + 1} but instead got {settingUpScreen.getSession()} for session input");
        Assert.AreEqual(SessionNumber - 1, Convert.ToInt32(settingUpScreen.getSessionLabel().Text), "decrease sessions button click suppose to decrease display sessions by one not properly reflected for sessions");

        while(settingUpScreen.getSession() > 1)
        {
            decreaseSessions.PerformClick();
        }
        decreaseSessions.PerformClick();
        Assert.AreEqual(1, settingUpScreen.getSession(), $"decrease session button click suppose to not go below 1 but got but instead got {settingUpScreen.getSession()} for session input");
        Assert.AreEqual(1, Convert.ToInt32(settingUpScreen.getSessionLabel().Text), "decrease sessions button click suppose to not decrease display sessions by bellow one not properly reflected for sessions");

    }

    [TestMethod]
    public void startControlForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();
        Button startButton = settingUpScreen.getStartButton();
        bool pressedStart = false;
        settingUpScreen.userPressedStart += (sender,e) => {pressedStart = true;};
        startButton.PerformClick();
        Assert.IsTrue(pressedStart, "start button isn't being registered when it gets clicked");
    }

    [TestMethod]
    public void settingControlForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();
        Button SettingButton = settingUpScreen.getSettingButton();
        bool pressedSetting = false;
        settingUpScreen.userPressedSetting += (sender,e) => {pressedSetting = true;};
        SettingButton.PerformClick();
        Assert.IsTrue(pressedSetting, "start button isn't being registered when it gets clicked");
    }
    
    [TestMethod]
    public void setThemeTestForSettingUpScreen()
    {
        settingUpScreen settingUpScreen = new settingUpScreen();

        System.Drawing.Color backGround = System.Drawing.Color.Black;

        System.Drawing.Color foreGround = System.Drawing.Color.White;

        settingUpScreen.setTheme(backGround, foreGround);

        System.Drawing.Color[] actualBackGroundAndForeGround = settingUpScreen.getBackgroundAndForeGroundTheme();

        Assert.AreEqual(backGround, actualBackGroundAndForeGround[0], "background color is not is not the same as input");
        Assert.AreEqual(foreGround, actualBackGroundAndForeGround[1], "foreground color is not is not the same as input");


    }
}
