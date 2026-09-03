using PomTimeApp;
using PomTimeApp.model;

namespace PomTime.Tests;

[TestClass]
public sealed class themeModelTest
{

    [TestMethod]
    public void selectThemeTestForThemeModel()
    {
        ThemeModel themeModel = new ThemeModel();

        Assert.AreNotEqual(themeModel.selectTheme(1), themeModel.selectTheme(2), "redudant theme");
        Assert.AreNotEqual(themeModel.selectTheme(3), themeModel.selectTheme(2), "redudant theme");
        Assert.AreNotEqual(themeModel.selectTheme(3), themeModel.selectTheme(1), "redudant theme");
        
    }
}