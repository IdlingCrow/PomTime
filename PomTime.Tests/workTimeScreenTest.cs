using System.Diagnostics;
using System.Windows.Media.Animation;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class workTimeScreenTest
{

    [TestMethod]
    public void IntializationTestForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();

        Button resetButton = screen.getResetButton();
        Button resumeButton = screen.getResumeButton();
        Button PauseButton = screen.getPauseButton();
        Button pauseMusicButton = screen.getPauseMusicButton();

        Assert.IsFalse(resetButton.Visible, "reset button is visible during intilization");
        Assert.IsFalse(resumeButton.Visible, "resume button is visible during intilization");
        Assert.IsTrue(PauseButton.Visible, "pause button is not visible during intilization");
        Assert.AreEqual("▶", pauseMusicButton.Text, "Pause Music button doesn't start out with the ▶ symbol");
    }

    [TestMethod]
    public void pauseButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
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
    public void resetButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
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
    public void resumeButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
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
    public void changeDisplayedTimeForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
        screen.changeDisplayedTime("armadillo");
        
        Assert.AreEqual("armadillo",screen.getDisplayed_timer(), "changeDisplayedTime did not modified the text shown on the userControl");

    }

    [TestMethod]
    public void ChangeThemeForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
        screen.setTheme(Color.FromArgb(0,0,0), Color.FromArgb(255,255,255));
        Color[] colorOfScreen = screen.getBackgroundAndForeGroundTheme();

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfScreen[0], "background color is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfScreen[1], "foreground color is not is not the same as input");
    }

    //WiP
    [TestMethod]
    public void pauseMusicButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();
        bool requestToPauseMusic = false;
        bool requestToResumeMusic = false;
        screen.PauseMusic += (sender, e) => {requestToPauseMusic = true;};
        screen.PlayMusic += (sender, e) => {requestToResumeMusic = true;};


        Button pauseButton = screen.getPauseMusicButton();
    
        if(pauseButton.Text.Equals("▶"))
        {
            pauseButton.PerformClick();
            Assert.AreEqual("⏸", pauseButton.Text, "User does not see ⏸ after pressing the pause music button with the symbol ▶");
            Assert.IsTrue(requestToPauseMusic, "request to PauseMusic event handler is not called after user pressed the ▶ button");
            pauseButton.PerformClick();
            Assert.AreEqual("▶", pauseButton.Text, "User does not see ⏸ after pressing the pause music button with the symbol ⏸");
            Assert.IsTrue(requestToResumeMusic, "request to PlayMusic event handler is not called after user pressed the ⏸ button");
        } 
        else
        {
            pauseButton.PerformClick();
            Assert.AreEqual("▶", pauseButton.Text, "User does not see ⏸ after pressing the pause music button with the symbol ⏸");
            Assert.IsTrue(requestToResumeMusic, "request to PlayMusic event handler is not called after user pressed the ⏸ button");
            pauseButton.PerformClick();
            Assert.AreEqual("⏸", pauseButton.Text, "User does not see ⏸ after pressing the pause music button with the symbol ▶");
            Assert.IsTrue(requestToPauseMusic, "request to PauseMusic event handler is not called after user pressed the ▶ button");
        }
    }

    [TestMethod]
    public void skipMusicButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();

        bool requestToSkipMusic = false;
        screen.SkipMusic += (sender, e) => {requestToSkipMusic = true;};

        Button skipButton = screen.getSkipButton();

        skipButton.PerformClick();
        Assert.IsTrue(requestToSkipMusic, "event handlerSkip music is not raised after skip music button is clicked");
        
    }

    [TestMethod]
    public void backMusicButtonInteractionForWorkScreen()
    {
        WorkTimeScreen screen = new WorkTimeScreen();

        bool requestToPlayPreviousMusic = false;
        screen.backMusic += (sender, e) => {requestToPlayPreviousMusic = true;};

        Button backButton = screen.getPreviousTrackButton();

        backButton.PerformClick();
        Assert.IsTrue(requestToPlayPreviousMusic, "event handlerSkip music is not raised after skip music button is clicked");
        
    }
}
