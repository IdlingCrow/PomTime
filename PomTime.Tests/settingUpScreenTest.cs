using System.Windows.Media;
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
        Assert.AreEqual("work", settingUpScreen.getInputState(), "pressing work button doesn't change the inputState");
        Assert.IsFalse(WorkInputButton.Enabled, "pressing the work button did not disable the work button");

        if(breakInputButton.Enabled == false)
        {
            breakInputButton.Enabled = true;
        }
        breakInputButton.PerformClick();
        
        Assert.AreEqual(settingUpScreen.getBreakMinutes(), Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "minutes label not displaying the stored break minutes after pressing break");
        Assert.AreEqual(settingUpScreen.getBreakSeconds(), Convert.ToInt32(settingUpScreen.getSecondsLabel().Text), "Seconds label not displaying the stored break seconds after pressing break");
        Assert.AreEqual(":", settingUpScreen.getSessionLabel().Text, "Session label not displaying ':' when pressing the break button");
        Assert.AreEqual("break", settingUpScreen.getInputState(), "pressing break button doesn't change the inputState");
        Assert.IsFalse(breakInputButton.Enabled, "pressing the break button did not disable the break button");

        if(SessionInputButton.Enabled == false)
        {
            SessionInputButton.Enabled = true;
        }
        SessionInputButton.PerformClick();
        Assert.IsFalse(settingUpScreen.getMinutesLabel().Visible, "Minutes label not being hidden after pressing the session button ");
        Assert.IsFalse(settingUpScreen.getSecondsLabel().Visible, "Seconds label not being hidden after pressing the session button ");
        Assert.AreEqual(settingUpScreen.getSession(), Convert.ToInt32(settingUpScreen.getSessionLabel().Text), "Session label not displaying amount of session that is being inputted after pressin the session button");
        Assert.AreEqual("session", settingUpScreen.getInputState(), "pressing session button doesn't change the inputState");
        Assert.IsFalse(SessionInputButton.Enabled, "pressing the session button did not disable the session button");

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
        Button decreaseSession = settingUpScreen.getDecreaseSessionButton();

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
        Assert.IsFalse(decreaseSession.Visible, "Button decreaseSession is visible after pressing the Work Button");

        //if input is being properly recoreded
        int workMinutes = settingUpScreen.getWorkMinutes();
        increaseMinutes.PerformClick();
        Assert.AreEqual(workMinutes + 1, settingUpScreen.getWorkMinutes(), $"Increasing minutes button click suppose to set value to {workMinutes + 1} but instead got {settingUpScreen.getWorkMinutes()}");
        Assert.AreEqual(workMinutes + 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "Increasing minutes button click suppose to Increase display minutes by one mintues not properly reflected for work minutes");

        workMinutes = settingUpScreen.getWorkMinutes();
        decreaseMinutes.PerformClick();
        Assert.AreEqual(workMinutes - 1, settingUpScreen.getWorkMinutes(), $"decrease minutes button click suppose to set value to {workMinutes + 1} but instead got {settingUpScreen.getWorkMinutes()}");
        Assert.AreEqual(workMinutes - 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "decrease minutes button click suppose to decrease display minutes by one mintues not properly reflected for work seconds");

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
        Assert.IsFalse(decreaseSession.Visible, "Button decreaseSession is visible after pressing the Break Button");

        //if input is being properly recoreded
        int breakMinutes = settingUpScreen.getBreakMinutes();
        increaseMinutes.PerformClick();
        Assert.AreEqual(breakMinutes + 1, settingUpScreen.getBreakMinutes(), $"Increasing minutes button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakMinutes()}");
        Assert.AreEqual(breakMinutes + 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "Increasing minutes button click suppose to Increase display minutes by one mintues not properly reflected for break minutes");

        breakMinutes = settingUpScreen.getBreakMinutes();
        decreaseMinutes.PerformClick();
        Assert.AreEqual(breakMinutes - 1, settingUpScreen.getBreakMinutes(), $"decrease minutes button click suppose to set value to {breakMinutes + 1} but instead got {settingUpScreen.getBreakMinutes()}");
        Assert.AreEqual(breakMinutes - 1, Convert.ToInt32(settingUpScreen.getMinutesLabel().Text), "decrease minutes button click suppose to decrease display minutes by one mintues not properly reflected for for break seconds");
    }
    
}
