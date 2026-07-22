using System.Diagnostics;

namespace PomTimeApp;

public partial class StartingUI : Form
{

    public EventHandler? userPressedStart;
    public StartingUI()
    {
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        InitializeComponent();
    }

    public int getWorkMinutes()
    {
        int workMinutes = Convert.ToInt32(WorkTimeMinutesInput.Text);
        return workMinutes;
    }
    public int getWorkSeconds()
    {
        int workSeconds = Convert.ToInt32(WorkTimeSecondsInput.Text);
        return workSeconds;
    }

    public int getBreakMinutes()
    {
        int breakMinutes = Convert.ToInt32(BreakTimeMinutesInput.Text);
        return breakMinutes;
    }

    public int getBreakSeconds()
    {
        int breakSeconds = Convert.ToInt32(BreakTimeSecondsInput.Text);
        return breakSeconds;
    }

    public int getSession()
    {
        int session = Convert.ToInt32(SessionsInput.Text);
        return session;
    }

    public void changeTitleToBreak()
    {
        BreakOrWorkTimeDispalyed.Text = "Break";
    }

    public void changeTitleToWork()
    {
        BreakOrWorkTimeDispalyed.Text = "Work";
    }

    public void changeTitleToSettingUp()
    {
        BreakOrWorkTimeDispalyed.Text = "Setting up";
    }

    public void changeDisplayedTime(string time)
    {
        Displayed_Timer.Text = time;
    }

    public void enableOneMinutesWarning()
    {
        oneMinutesWarner.Text = "there is one minutes left until break time";
    }

    public void disableOneminutesWarning()
    {
        oneMinutesWarner.Text = string.Empty;
    }

    private void startBtn_Click(object sender, EventArgs e)
    {
        userPressedStart?.Invoke(this, EventArgs.Empty);
    }

    public void switchToWorkScreen()
    {
        this.BackColor = Color.GhostWhite;
    }

    public void switchToBreakScreen()
    {
        this.BackColor = Color.CadetBlue;
    }

    public void switchToSettingUpScreen()
    {
        this.BackColor = Color.White;
    }

    //these function is exculsively created for test purposes
    public string getBreakOrWorkTimeDispalyed()
    {
        string result = BreakOrWorkTimeDispalyed.Text;
        return result;
    }

    public string getOneMinutesWarner()
    {
        return oneMinutesWarner.Text;
    }

    public string getDisplayed_timer()
    {
        return Displayed_Timer.Text;
    }

    public Color getBackColor()
    {
        return this.BackColor;
    }

    public void performClick()
    {
        this.startBtn_Click(this, EventArgs.Empty);
    }

    public void performClickWithInput(int workTimeMinutes, int workTimeSeconds, int breakTimeMinutes, int breakTimeSeconds, int sessions)
    {
        this.WorkTimeMinutesInput.Text = Convert.ToString(workTimeMinutes);
        this.WorkTimeSecondsInput.Text = Convert.ToString(workTimeSeconds);
        this.BreakTimeMinutesInput.Text = Convert.ToString(breakTimeMinutes);
        this.BreakTimeSecondsInput.Text = Convert.ToString(breakTimeSeconds);
        this.SessionsInput.Text = Convert.ToString(sessions);
        this.startBtn_Click(this, EventArgs.Empty);
    }

}
