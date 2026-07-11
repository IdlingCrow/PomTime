using System;
using System.Diagnostics;
using System.Threading;
using prototype;

namespace PomTime.Tests;

[TestClass]
public sealed class Test2
{

    [TestMethod]
    [DoNotParallelize]
    public void TestMethod3()
    {
        Console.SetIn(new StringReader("15"));
        int millisecondsTime = pomPrototype.getInputTimeInMiliseconds();
        Assert.AreEqual(15000, millisecondsTime, $"Expected: 15000 \t Got:{millisecondsTime}");
    }


    [TestMethod]
    [DoNotParallelize]
    public void TestMethod4()
    {
        Stopwatch timer = new Stopwatch();

        Console.SetIn(new StringReader("This is the notes I left for myself"));

        string message = pomPrototype.breakTimeMethod(16 * 1000, timer);

        Assert.AreEqual("This is the notes I left for myself", message, $"actual string: {message}");

    }

    [TestMethod]
    [DoNotParallelize]
    public void TestMethod5()
    {
        Console.SetIn(new StringReader("3"));
        int session = pomPrototype.getRepeatTime();
        int expected = 3;
        Assert.AreEqual(expected, session, $"Expected: {expected} \t Got:{session}");
    }
}
