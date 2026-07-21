using System.Security.Cryptography.X509Certificates;
using PomTimeApp;

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
}