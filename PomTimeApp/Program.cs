using PomTimeApp.model;
using PomTimeApp.view;

namespace PomTimeApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        StartingUI startingUI = new StartingUI();
        SoundModel musicModel = new SoundModel();
        TimeModel timer = new TimeModel(0, 0, 0, 0);
        stickyNotes reminderNotes = new stickyNotes();
        ThemeModel themeModel = new ThemeModel();
        Controller controller = new Controller(startingUI, timer, musicModel, reminderNotes, themeModel);
        startingUI.setTheme(themeModel.selectTheme(Properties.Settings.Default.Theme));

        Application.Run(startingUI);
    }    
}