using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace PomTimeApp.model;
public class activityModel
{
    string breakActivtiesFolder;
    string[] breakActivities;

    string currImage;
    Image activity;

    private Random randomActvity;

    //Used to get all the image from the break activity folder
    public activityModel()
    {
        String[] imageFormat = {".gif",".jpeg",".png",".jpg", ".bmp"};
        breakActivtiesFolder = Path.Combine(Application.StartupPath, "model", "breakActivity");
        breakActivities = [];
        for(int i = 0; i < imageFormat.Length; i++)
        {
            breakActivities = breakActivities.Concat(Directory.GetFiles(breakActivtiesFolder, $"*{imageFormat[i]}")).ToArray();
        }
        randomActvity = new Random();
        currImage = breakActivities[randomActvity.NextInt64(0, breakActivities.Length)];
        activity = Image.FromFile(currImage);
    }

    //lead the user to the folder and have the user
    //manage the picture
    public void manageActivity()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = breakActivtiesFolder,
            UseShellExecute = true
        });
    }

    //look at the list again to see if there are any changes
    public void refreshList()
    {
        String[] imageFormat = { ".gif", ".jpeg", ".png", ".jpg", ".bmp" };
        breakActivtiesFolder = Path.Combine(Application.StartupPath, "model", "breakActivity");
        breakActivities = [];
        for (int i = 0; i < imageFormat.Length; i++)
        {
            breakActivities = breakActivities.Concat(Directory.GetFiles(breakActivtiesFolder, $"*{imageFormat[i]}")).ToArray();
        }
    }

    //get a random image from the activity folder
    public Image getBreakActivity()
    {
        refreshList();
        currImage = breakActivities[randomActvity.NextInt64(0, breakActivities.Length)];
        activity = Image.FromFile(currImage);
        return activity;
    }

    //internal for test
    internal string[] getBreakActivities()
    {
        return breakActivities;
    }

    internal string getCurrImageName()
    {
        return currImage;
    }


}
