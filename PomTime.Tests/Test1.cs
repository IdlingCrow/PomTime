using System;
using System.Diagnostics;
using System.Threading;
using PomTimeApp;

namespace PomTime.Tests;

[TestClass]
public sealed class Test1
{

    [TestMethod]
    public void correctInput()
    {
        StartingUI newUi = new StartingUI();
        int breakMinutes = newUi.getBreakMinutes();
        int breakSeconds = newUi.getBreakSeconds();
        int workMinutes = newUi.getWorkMinutes();
        int workSeconds = newUi.getWorkSeconds();
        
        Assert.AreEqual(0, breakMinutes, $"Number that was recived was: {breakMinutes}");
        Assert.AreEqual(0, breakSeconds, $"Number that was recived was: {breakSeconds}");
        Assert.AreEqual(0, workMinutes, $"Number that was recived was: {workMinutes}");
        Assert.AreEqual(0, workSeconds, $"Number that was recived was: {workSeconds}");
    }
}
