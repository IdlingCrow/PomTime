namespace PomTime.Tests;

using Microsoft.Testing.Platform.Extensions.Messages;
using PomTime;
using PomTimeApp;
using System.Diagnostics;

[TestClass]
public sealed class controllerTest
{


    [TestMethod]
    public void uiManipulationTest()
    {
        StartingUI testUI = new StartingUI();
        TimeModel testTimer = new TimeModel(0, 0, 0, 0);
        Controller testController = new Controller(testUI, testTimer);

        testController.SessionComplete();
        Assert.AreEqual("Setting up", testUI.getBreakOrWorkTimeDispalyed(), $"function sessionComplete suppose to show 'testing complete' on UI  showed {testUI.getBreakOrWorkTimeDispalyed()}");

        testController.enableOneMinutesWarning(this, EventArgs.Empty);
        Assert.AreNotEqual(String.Empty, testUI.getOneMinutesWarner(), $"function enableOneMinutesWarning didn't add the text");

        testController.disableOneMinutesWarning();
        Assert.AreEqual(String.Empty, testUI.getOneMinutesWarner(), $"function disableOneMinutesWarning didn't remove the text");

        testController.changeBreakTime(10, 10);
        testController.decreaseByASecond(this, EventArgs.Empty);
        Assert.AreEqual("10:09", testUI.getDisplayed_timer(), $"time is supposed to showed 10:09 afeter calling decrease on 10:09 instead it showed {testUI.getDisplayed_timer()}");

        testController.changeBreakTime(10, 0);
        testController.decreaseByASecond(this, EventArgs.Empty);
        Assert.AreEqual("09:59", testUI.getDisplayed_timer(), $"time is supposed to showed 10:00 afeter calling decrease on 9:59 instead it showed {testUI.getDisplayed_timer()}");

        testController.changeBreakTime(0, 0);
        testController.decreaseByASecond(this, EventArgs.Empty);
        Assert.AreEqual("00:00", testUI.getDisplayed_timer(), $"time is supposed to showed 00:00 afeter calling decrease on 00:00 instead it showed {testUI.getDisplayed_timer()}");

    }
    [TestMethod]
    public void testUIActualInput()
    {
        StartingUI testUI = new StartingUI();
        TimeModel testTimer = new TimeModel(0, 0, 0, 0);
        Controller testController = new Controller(testUI, testTimer);
        Stopwatch stopWatch = new Stopwatch();

        testUI.performClickWithInput(0, 5, 0, 5, 1);
        stopWatch.Start();

        Assert.AreEqual("Work", testUI.getBreakOrWorkTimeDispalyed(), $"the title is {testUI.getBreakOrWorkTimeDispalyed()} instead of work");
        while(stopWatch.ElapsedMilliseconds < 7000)
        {
            System.Windows.Forms.Application.DoEvents();
        }
        Assert.AreEqual("Break", testUI.getBreakOrWorkTimeDispalyed(), $"the title is {testUI.getBreakOrWorkTimeDispalyed()} instead of break");
        while(stopWatch.ElapsedMilliseconds < 13000)
        {
            System.Windows.Forms.Application.DoEvents();
        }
        Assert.AreEqual("Setting up", testUI.getBreakOrWorkTimeDispalyed(), $"the title is {testUI.getBreakOrWorkTimeDispalyed()} instead of setting up");
    }

}