using PomTimeApp;

namespace PomTime.Tests;

[TestClass]
public sealed class startingUITest
{

    [TestMethod]
    public void correctInput()
    {
        StartingUI newUi = new StartingUI();
        int breakMinutes = newUi.getBreakMinutes();
        int breakSeconds = newUi.getBreakSeconds();
        int workMinutes = newUi.getWorkMinutes();
        int workSeconds = newUi.getWorkSeconds();
        int SessionsInput = newUi.getSession();
        

        Assert.AreEqual(0, breakMinutes, $"Number that was recived was: {breakMinutes}");
        Assert.AreEqual(0, breakSeconds, $"Number that was recived was: {breakSeconds}");
        Assert.AreEqual(0, workMinutes, $"Number that was recived was: {workMinutes}");
        Assert.AreEqual(0, workSeconds, $"Number that was recived was: {workSeconds}");
        Assert.AreEqual(0, SessionsInput, $"Number that was recived was: {SessionsInput}");
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
