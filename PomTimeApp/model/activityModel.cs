using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

    public Image getBreakActivity()
    {
        return boxBreathingActivity;
    }
}
