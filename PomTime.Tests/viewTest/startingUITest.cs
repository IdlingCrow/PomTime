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
}