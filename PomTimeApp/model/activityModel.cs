using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PomTimeApp.model;
public class activityModel
{
    string breakActivtiesFolder;
    string[] breakActivities;
    Image boxBreathingActivity;
    public activityModel()
    {
        String[] imageFormat = {".gif",".jpeg",".png",".jpg", ".bmp"};
        breakActivtiesFolder = Path.Combine(Application.StartupPath, "model", "breakActivity");
        breakActivities = [];
        for(int i = 0; i < imageFormat.Length; i++)
        {
            breakActivities = breakActivities.Concat(Directory.GetFiles(breakActivtiesFolder, $"*{imageFormat[i]}")).ToArray();
        }
        Random randomActvity = new Random();
        boxBreathingActivity = Image.FromFile(breakActivities[randomActvity.NextInt64(0, breakActivities.Length)]);
    }

    public void manageActivity()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = breakActivtiesFolder,
            UseShellExecute = true
        });
    }
    public void refreshList()
    {
        breakActivtiesFolder = Path.Combine(Application.StartupPath, "model", "breakActivity");
    }

    public Image getBreakActivity()
    {
        refreshList();
        return boxBreathingActivity;
    }
}
