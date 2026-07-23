using System.Security.Cryptography.X509Certificates;
using PomTimeApp;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace PomTime.Tests;

[TestClass]
public sealed class modelTest
{
    [TestMethod]
    public void timerTestDataRecording()
    {
        TimeModel timer = new TimeModel(60, 60, 50, 50);

        Assert.AreEqual(3050, timer.getBreakTime(), $"break timer is suppose to be 3050 is but is {timer.getBreakTime()}");
        Assert.AreEqual(3660, timer.getWorkTime(), $"work timer is suppose to be 3660 is but is {timer.getWorkTime()}");

        timer.changeTime(0, 50, 0, 60);

        Assert.AreEqual(60, timer.getBreakTime(), $"change break timer is suppose to be 50 is but is {timer.getBreakTime()}");
        Assert.AreEqual(50, timer.getWorkTime(), $"change work timer is suppose to be 60 is but is {timer.getWorkTime()}");
    }

    [TestMethod]
    [DoNotParallelize]
    public void testTimerbreakSessionTimer()
    {
        TimeModel timer = new TimeModel(0, 5, 0, 5);

        Stopwatch stopWatch = new Stopwatch();
        int totalTime = 0;
        int intendedTime = 1000;
        bool breakSessionEnd = false;

        timer.breakSessionDone += (sender, e) => {
            breakSessionEnd = true;
            totalTime += Math.Abs(Convert.ToInt32(stopWatch.ElapsedMilliseconds) - intendedTime);
        };
        timer.decreaseByASecond += (sender, e) =>
        {
            totalTime += Math.Abs(Convert.ToInt32(stopWatch.ElapsedMilliseconds) - intendedTime);
            intendedTime += 1000;
        };

        stopWatch.Start();
        timer.startBreakTime();
        while(!breakSessionEnd && stopWatch.ElapsedMilliseconds < 6500)
        {
        }
        Assert.IsTrue(breakSessionEnd);
        Assert.IsGreaterThan(4000, stopWatch.ElapsedMilliseconds, "timer stop significant earlier at 5 seconds break input");
        Assert.IsLessThan(6500, stopWatch.ElapsedMilliseconds, $"timer did not stop at 5 seconds break input it stop at {stopWatch.ElapsedMilliseconds}");
        Assert.IsLessThan(500, totalTime / 5, "average time is more than 500 seconds apart");

    }

    [TestMethod]
    [DoNotParallelize]
    public void testWorkSessionTimer()
    {
        TimeModel timer = new TimeModel(0, 5, 0, 5);

        Stopwatch stopWatch = new Stopwatch();
        int totalTime = 0;
        int intendedTime = 1000;
        bool workSessionEnd = false;
        bool workSessionOneMinutesAlert = false;

        timer.workSessionDone += (sender, e) => {
            workSessionEnd = true;
            totalTime += Math.Abs(Convert.ToInt32(stopWatch.ElapsedMilliseconds) - intendedTime);
            workSessionEnd = true;
        };
        timer.decreaseByASecond += (sender, e) =>
        {
            totalTime += Math.Abs(Convert.ToInt32(stopWatch.ElapsedMilliseconds) - intendedTime);
            intendedTime += 1000;
        };

        timer.sendOneMinutesAlert += (sender, e) =>
        {
            workSessionOneMinutesAlert = true;
        };

        stopWatch.Start();
        timer.startWorkTime();
        while(!workSessionEnd && stopWatch.ElapsedMilliseconds < 6500)
        {
        }
        Assert.IsTrue(workSessionOneMinutesAlert);
        Assert.IsTrue(workSessionEnd);
        Assert.IsGreaterThan(4000, stopWatch.ElapsedMilliseconds, "timer stop significant earlier at 5 seconds work input");
        Assert.IsLessThan(6500, stopWatch.ElapsedMilliseconds, $"timer did not stop at 5 seconds work input it stop at {stopWatch.ElapsedMilliseconds}");
        Assert.IsLessThan(500, totalTime / 5, "average time is more than 500 seconds apart");



    }

    // these test are here for test coverage
    [TestMethod]
    [DoNotParallelize]
    public void testIfForWorkNoInvoke()
    {
        TimeModel timer = new TimeModel(0, 2, 0, 1);

        Stopwatch stopWatch = new Stopwatch();
        bool workSessionEnd = false;
        bool TimerActivated = false;

        timer.startWorkTime();
        stopWatch.Start();
        while(stopWatch.ElapsedMilliseconds < 4000)
        {
        }

        timer.workSessionDone += (sender, e) => {
            workSessionEnd = true;
        };

        timer.decreaseByASecond += (sender, e) =>
        {
            TimerActivated = true;
        };
        Assert.IsFalse(workSessionEnd);
        Assert.IsFalse(TimerActivated);

    }

    // these test are here for test coverage
    [TestMethod]
    [DoNotParallelize]
    public void testIfForBreakNoInvoke()
    {
        TimeModel timer = new TimeModel(0, 1, 0, 1);

        Stopwatch stopWatch = new Stopwatch();
        bool breakSessionEnd = false;
        bool TimerActivated = false;

        timer.startBreakTime();
        stopWatch.Start();
        while(stopWatch.ElapsedMilliseconds < 4000)
        {
        }

        timer.breakSessionDone += (sender, e) => {
            breakSessionEnd = true;
        };

        timer.decreaseByASecond += (sender, e) =>
        {
            TimerActivated = true;
        };

        Assert.IsFalse(breakSessionEnd);
        Assert.IsFalse(TimerActivated);

    }

    [TestMethod]
    [DoNotParallelize]
    public void testForOneMinutesAlert()
    {
        TimeModel timer = new TimeModel(1, 5, 0, 1);
        Stopwatch stopWatch = new Stopwatch();
        bool oneMinAlert = false;

        timer.sendOneMinutesAlert += (sender, e) =>
        {
            oneMinAlert = true;
        };

        stopWatch.Start();
        timer.startWorkTime();
        Assert.IsFalse(oneMinAlert);

        while(stopWatch.ElapsedMilliseconds < 6500)
        {
        }
        Assert.IsTrue(oneMinAlert);
    }
}