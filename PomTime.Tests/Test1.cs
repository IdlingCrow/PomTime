using System;
using System.Diagnostics;
using System.Threading;
using prototype;

namespace PomTime.Tests;

[TestClass]
public sealed class Test1
{

    [TestMethod]
    public void TestMethod1()
    {
        Stopwatch timer = new Stopwatch();
        Stopwatch TimerTestTooEarly = new Stopwatch();
        Stopwatch TimerTestTooLate = new Stopwatch();

        Console.SetIn(new StringReader("This is the notes I left for myself"));

        TimerTestTooEarly.Start();
        TimerTestTooLate.Start();

        pomPrototype.breakTimeMethod(16 * 1000, timer);
        TimerTestTooEarly.Start();
        TimerTestTooLate.Start();

        Assert.IsGreaterThan(16000, TimerTestTooEarly.ElapsedMilliseconds);
        Assert.IsLessThan(15500, TimerTestTooEarly.ElapsedMilliseconds);

    }
}
