using System.Collections;
using PomTimeApp.model;

namespace PomTime.Tests;

[TestClass]
public sealed class activityModelTest
{

    [TestMethod]
    public void getBreakActivityForActivityModel()
    {
        activityModel activityModel = new activityModel();
        string[] activtiesList = activityModel.getBreakActivities();
        Hashtable hashActivtiesList = new Hashtable();

        for(int i = 0; i < activtiesList.Length; i++)
        {
            hashActivtiesList.Add(activtiesList[i], 1);
        }

        activityModel.getBreakActivity();

        Assert.IsTrue(hashActivtiesList.ContainsKey(activityModel.getCurrImageName()), "image does not exist in folder");
    }
}
