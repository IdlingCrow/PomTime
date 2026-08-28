using System.Runtime.CompilerServices;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class breakTimeScreenTest
{

    [TestMethod]
    public void IntializationTestForBreakTimeScreenTest()
    {
        breakTimeScreen screen = new breakTimeScreen();

        Button resetButton = screen.getResetButton();
        Button resumeButton = screen.getResumeButton();
        Button PauseButton = screen.getPauseButton();

        Assert.IsFalse(resetButton.Visible, "reset button is visible during intilization");
        Assert.IsFalse(resumeButton.Visible, "resume button is visible during intilization");
        Assert.IsTrue(PauseButton.Visible, "pause button is not visible during intilization");
    }

    [TestMethod]
    public void pauseButtonInteractionForBreakTimeScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        bool pauseBtn_Click = false;

        screen.UserPressedPause += (sender, e) => {pauseBtn_Click = true;};

        Button resetButton = screen.getResetButton();
        Button resumeButton = screen.getResumeButton();
        Button PauseButton = screen.getPauseButton();

        PauseButton.PerformClick();

        Assert.IsTrue(pauseBtn_Click, "pressing a pause button did not invoke that pause button has been pressed");

        Assert.IsTrue(resetButton.Visible, "reset button is not visible after pressing resume");
        Assert.IsTrue(resumeButton.Visible, "resume button is not visible after pressing resume");
        Assert.IsFalse(PauseButton.Visible, "pause button is visible after pressing resume");
    }

    [TestMethod]
    public void resetButtonInteractionForBreakTimeScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        bool resetBtn_Click = false;

        screen.UserPressedReset += (sender, e) => {resetBtn_Click = true;};

        Button resetButton = screen.getResetButton();
        Button resumeButton = screen.getResumeButton();
        Button PauseButton = screen.getPauseButton();

        PauseButton.PerformClick();
        resetButton.PerformClick();

        Assert.IsTrue(resetBtn_Click, "pressing a reset button did not invoke that reset button has been pressed");
        Assert.IsFalse(resetButton.Visible, "reset button is visible after pressing reset");
        Assert.IsFalse(resumeButton.Visible, "resume button is visible after pressing reset");
        Assert.IsTrue(PauseButton.Visible, "pause button is not visible after pressing reset");
    }

    [TestMethod]
    public void resumeButtonInteractionForBreakTimeScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        bool resumeBtn_Click = false;

        screen.UserPressedResume += (sender, e) => {resumeBtn_Click = true;};

        Button resetButton = screen.getResetButton();
        Button resumeButton = screen.getResumeButton();
        Button PauseButton = screen.getPauseButton();

        PauseButton.PerformClick();
        resumeButton.PerformClick();

        Assert.IsTrue(resumeBtn_Click, "pressing a resume button did not invoke that resume button has been pressed");

        Assert.IsFalse(resetButton.Visible, "resume button is visible after pressing resume");
        Assert.IsFalse(resumeButton.Visible, "resume button is visible after pressing resume");
        Assert.IsTrue(PauseButton.Visible, "pause button is not visible after pressing resume");
    }

    [TestMethod]
    public void changeDisplayedTimeForBreakScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        screen.changeDisplayedTime("armadillo");
        
        Assert.AreEqual("armadillo",screen.getDisplayed_timer(), "changeDisplayedTime did not modified the text shown on the userControl");

    }

    [TestMethod]
    public void startAnActivityForBreakScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        screen.startAnActivity();

        Assert.IsNotNull(screen.getBreakActivityImage().Image, "startAnActivity actually give an image");
    }

    [TestMethod]
    public void changeThemeForBreakScreen()
    {
        breakTimeScreen screen = new breakTimeScreen();
        screen.setTheme(Color.FromArgb(0,0,0), Color.FromArgb(255,255,255));
        Color[] colorOfScreen = screen.getBackgroundAndForeGroundTheme();

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfScreen[0], "background color is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfScreen[1], "foreground color is not is not the same as input");
    }
}