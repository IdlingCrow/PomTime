using System.Diagnostics;
using System.Timers;
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

    [TestMethod]
    public void workTimeTestForTimeModel()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(1, 1, 0, 0, testTimer);
        bool oneMinutesTrigger = false;
        bool ending = false;
        timeModel.workSessionDone += (sender, e) => {ending = !ending;};
        timeModel.sendOneMinutesAlert += (sender,e) => {oneMinutesTrigger = !oneMinutesTrigger;};
        timeModel.startWorkTime();
        Assert.IsFalse(timeModel.getOneMinAlert(), "one minutes alert is notified before the one minutes mark");
        Assert.IsFalse(oneMinutesTrigger, "One minutes invoke should not be sent out yet");
        testTimer.elapseTimer();
        Debug.WriteLine(timeModel.getSeconds());
        Assert.IsTrue(timeModel.getOneMinAlert(), "one minutes alert is not being set to true at the one mintues mark");
        Assert.IsTrue(oneMinutesTrigger, "One minutes invoke should have been sent out at the one mintues mark");
        Assert.IsFalse(ending, "Time should not invoke work timer done because the set timer of 61 second has not been exceeded");
        for (int i = 0; i < 59; i++)
        {
            testTimer.elapseTimer();
            Assert.IsTrue(timeModel.getOneMinAlert(), "one minutes alert is not being set to true when lower than one minutes");
            Assert.IsTrue(oneMinutesTrigger, "One minutes invoke should not have been sent out more than once");
            Assert.IsFalse(ending, "Time should not invoke work timer done because the set timer of 61 second has not been exceeded");
        }
        testTimer.elapseTimer();
        Assert.IsLessThanOrEqualTo(0, testTimer.getNumerOfListener(), "number of listner should be 0 after the timer ends");
        Assert.IsTrue(ending, "Timer should be done after 61 tick because the time was set to 61");
    }

    [TestMethod]
    public void breakTimeTestForTimeModel()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(0, 0, 0, 2, testTimer);
        bool ending = false;
        timeModel.breakSessionDone += (sender, e) => {ending = !ending;};
        timeModel.startBreakTime();

        Assert.IsFalse(ending, "Time should not invoke work timer done because the set timer of 2 second has not been exceeded");
        Assert.IsGreaterThan(0, testTimer.getNumerOfListener(), "number of listener should be atlest one to watch for when the timer end");
        testTimer.elapseTimer();
        Assert.IsGreaterThan(0, testTimer.getNumerOfListener(), "number of listener should be atlest one to watch for when the timer end");
        Assert.IsFalse(ending, "Time should not invoke work timer done because the set timer of 2 second has not been exceeded");
        testTimer.elapseTimer();
        Assert.IsLessThanOrEqualTo(0, testTimer.getNumerOfListener(), "number of listner should be 0 after the timer ends");
        Assert.IsTrue(ending, "Timer should be invoke worktime done after 61 tick because the time was set to 61");
    }

    [TestMethod]
    public void resetTimeTestForTimeModel()
    {
        testTimer testTimer = new testTimer();
        TimeModel timeModel = new TimeModel(0, 0, 0, 2, testTimer);
        timeModel.startBreakTime();
        timeModel.resetTime();
        Assert.IsLessThanOrEqualTo(0, testTimer.getNumerOfListener(), "there should be no listener after calling resetTime");
        timeModel.startWorkTime();
        timeModel.resetTime();
        Assert.IsLessThanOrEqualTo(0, testTimer.getNumerOfListener(), "there should be no listener after calling resetTime");
    }

    public void testAll()
    {
        intilizationTestFortimeModel();
        startTimeMethodTestForTimeModel();
        changeTimeForTimeModel();
        workTimeTestForTimeModel();
        breakTimeTestForTimeModel();
        resetTimeTestForTimeModel();
    }

}
