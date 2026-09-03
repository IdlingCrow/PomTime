using PomTimeApp;
using PomTimeApp.model;

namespace PomTime.Tests;

[TestClass]
public sealed class timeModelTest
{

    [TestMethod]
    public void intilizationTestFortimeModel()
    {
        TimeModel timeModel = new TimeModel(5,5,1,5);

        Assert.AreEqual(305, timeModel.getWorkTime(), "Inputing 5 minutes and 5 seconds for the first two argument did not get 305 tick for work time");

        Assert.AreEqual(65, timeModel.getBreakTime(), "Inputing 1 minutes and 5 seconds for the 3rd and 4th argument did not get 65 tick for break time");
    }

    [TestMethod]
    public void startTimeMethodTestForTimeModel()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(5, 5, 5, 5, testTimer);

        timeModel.startTime();
        Assert.IsTrue(testTimer.isTimerRunning(), "timer is not running after using the moethod startTime()");

        timeModel.pauseTime();
        Assert.IsFalse(testTimer.isTimerRunning(), "timer is still running after using the method pauseTime()");
    }

    [TestMethod]
    public void changeTimeForTimeModel()
    {
        TimeModel timeModel = new TimeModel(5, 5, 5, 5);

        timeModel.changeTime(1,2,3,4);

        Assert.AreEqual(62, timeModel.getWorkTime(), "Inputing 1 minutes and 2 seconds for the first two argument of changeTime did not get 62 tick for work time");

        Assert.AreEqual(184, timeModel.getBreakTime(), "Inputing 3 minutes and 4 seconds for the first two argument of changeTime did not get 184 tick for work time");
    }
}
