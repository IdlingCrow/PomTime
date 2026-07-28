using System;
using System.Collections.Generic;
using System.Text;

namespace PomTimeApp.model;
public class activityModel
{
    Image boxBreathingActivity;
    public activityModel()
    {
        boxBreathingActivity = Image.FromFile(Path.Combine(Application.StartupPath, "model", "breakActivity", "boxBreathing.gif"));
    }

    public Image getBreakActivity()
    {
        return boxBreathingActivity;
    }
}
