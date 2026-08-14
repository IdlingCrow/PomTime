using PomTimeApp;
using System.IO;
using PomTimeApp.Properties;

namespace PomTime.Tests;

[TestClass]
public sealed class startingUITest
{

    [TestMethod]
    public void correctInput()
    {

    }

    [TestMethod]
    public void changingUi()
    {
        StartingUI newUi = new StartingUI();

        newUi.switchToBreakScreen();
        Assert.AreEqual("Break", newUi.getScreenState(), "incorrect screen for break time");

        newUi.switchToWorkScreen();
        Assert.AreEqual("Work", newUi.getScreenState(), "incorrect screen for work time");

        newUi.switchToSettingUpScreen();
        Assert.AreEqual("Setting up", newUi.getScreenState(), "incorrect screen for setting up");

    }

    [TestMethod]
    public void testingInvoke()
    {
        StartingUI newUi = new StartingUI();
        bool boolButtonWasClicked = false;
        newUi.performClick();

        newUi.userPressedStart += (sender, e) => boolButtonWasClicked = true;
        Assert.IsFalse(boolButtonWasClicked, "nothing should happend yet");

        newUi.performClick();
        Assert.IsTrue(boolButtonWasClicked, "start button was not detected");

    }
}
