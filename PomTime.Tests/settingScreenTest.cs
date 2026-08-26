using PomTimeApp;
using System.IO;
using PomTimeApp.Properties;
using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class settingScreenTest
{
    [TestMethod]
    public void theme1ButtonPressForSettingScreen()
    {
        bool buttonHasBeenPressed = false;
        settingScreen settingScreen = new settingScreen();
        Button theme1Button = settingScreen.getTheme1Button();
        Button theme2Button = settingScreen.getTheme2Button();
        Button theme3Button = settingScreen.getTheme3Button();
        settingScreen.userPressedTheme1 += (sender, e) => buttonHasBeenPressed = true;
        if (theme1Button.Enabled == false)
        {
            theme1Button.Enabled = true;
        }
        theme1Button.PerformClick();
        Assert.IsTrue(buttonHasBeenPressed, "button hasn't dectect it has been pressed");
        Assert.IsFalse(theme1Button.Enabled, "button for theme 1 is enable");
        Assert.IsTrue(theme2Button.Enabled, "button for theme 2 is disable");
        Assert.IsTrue(theme3Button.Enabled, "button for theme 3 is disable");
    }

    [TestMethod]
    public void theme2ButtonPressForSettingScreen()
    {
        bool buttonHasBeenPressed = false;
        settingScreen settingScreen = new settingScreen();
        Button theme1Button = settingScreen.getTheme1Button();
        Button theme2Button = settingScreen.getTheme2Button();
        Button theme3Button = settingScreen.getTheme3Button();
        settingScreen.userPressedTheme2 += (sender, e) => buttonHasBeenPressed = true;
        if (theme2Button.Enabled == false)
        {
            theme2Button.Enabled = true;
        }
        theme2Button.PerformClick();
        Assert.IsTrue(buttonHasBeenPressed, "button hasn't dectect it has been pressed");
        Assert.IsTrue(theme1Button.Enabled, "button for theme 1 is disable");
        Assert.IsFalse(theme2Button.Enabled, "button for theme 2 is enable");
        Assert.IsTrue(theme3Button.Enabled, "button for theme 3 is disable");
    }

    [TestMethod]
    public void theme3ButtonPressForSettingScreen()
    {
        bool buttonHasBeenPressed = false;
        settingScreen settingScreen = new settingScreen();
        Button theme1Button = settingScreen.getTheme1Button();
        Button theme2Button = settingScreen.getTheme2Button();
        Button theme3Button = settingScreen.getTheme3Button();
        settingScreen.userPressedTheme3 += (sender, e) => buttonHasBeenPressed = true;
        if (theme3Button.Enabled == false)
        {
            theme3Button.Enabled = true;
        }
        theme3Button.PerformClick();
        Assert.IsTrue(buttonHasBeenPressed, "button hasn't dectect it has been pressed");
        Assert.IsTrue(theme1Button.Enabled, "button for theme 1 is disable");
        Assert.IsTrue(theme2Button.Enabled, "button for theme 2 is disable");
        Assert.IsFalse(theme3Button.Enabled, "button for theme 3 is enable");
    }

    [TestMethod]
    public void musicManagementButton_ClickForSettingScreen()
    {
        bool MusicManagementButtonState = false;
        settingScreen settingScreen = new settingScreen();
        Button musicManagementButton = settingScreen.getMusicManagementButton();
        settingScreen.userPressedManageMusic += (sender, e) => {MusicManagementButtonState = true;};
        musicManagementButton.PerformClick();
        Assert.IsTrue(MusicManagementButtonState, "button hasn't dectect it has been pressed");
    }

    [TestMethod]
    public void changeThemeForSettingScreen()
    {
        settingScreen settingScreen = new settingScreen();
        settingScreen.setTheme(Color.FromArgb(0,0,0), Color.FromArgb(255,255,255));
        Color[] colorOfScreen = settingScreen.getBackgroundAndForeGroundTheme();

        Assert.AreEqual(Color.FromArgb(0,0,0), colorOfScreen[0], "background color is not is not the same as input");
        Assert.AreEqual(Color.FromArgb(255,255,255), colorOfScreen[1], "foreground color is not is not the same as input");
    }
}