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
        TimeModel timer = new TimeModel(0, 0, 0, 0);
        Controller controller = new Controller(startingUI, timer);

        Application.Run(startingUI);
    }    
}