using PomTimeApp.view;

namespace PomTime.Tests;

[TestClass]
public sealed class StickyNotesTest
{

    [TestMethod]
    public void IntilalizatoinOfNotesForStickyNotes()
    {
        stickyNotes stickyNotes = new stickyNotes();

        int expectedXLocation = (Screen.PrimaryScreen?.Bounds.Width ?? 0) / 6;
        int expectedYLocation = (Screen.PrimaryScreen?.Bounds.Height ?? 0) / 25;

        Assert.AreEqual(expectedXLocation, stickyNotes.Location.X, "StickyNotes itialization X location is not at the correct spot");
        Assert.AreEqual(expectedYLocation, stickyNotes.Location.Y, "StickyNotes itialization Y location is not at the correct spot");
    }

    [TestMethod]
    public void OpeningNotesForStickyNotes()
    {
        stickyNotes stickyNotesWithMinimize = new stickyNotes();
        stickyNotes stickyNotesNormal = new stickyNotes();

        stickyNotesWithMinimize.WindowState = FormWindowState.Minimized;

        stickyNotesWithMinimize.openNotes();
        stickyNotesNormal.openNotes();

        Assert.AreEqual(FormWindowState.Normal, stickyNotesWithMinimize.WindowState, "openNotes did not make stickyNotes return to a normal state if it is minimize");
        Assert.IsTrue(stickyNotesWithMinimize.Visible, "stickyNotes is not visible after calling openNotes when the screen is minimize");
        Assert.IsTrue(stickyNotesNormal.Visible, "stickyNotes is not visible after calling openNotes");
    }

    [TestMethod]
    public void ClosingNotesForStickyNotes()
    {
        stickyNotes stickyNote = new stickyNotes();
        stickyNote.openNotes();
        stickyNote.Close();

        Assert.IsFalse(stickyNote.IsDisposed, "stickyNotes got destroyed after the user press close");
        Assert.IsFalse(stickyNote.Visible, "stickyNotes is still visible after the user pressed close");
    }

    [TestMethod]
    public void resetNotesForStickyNotes()
    {
        stickyNotes stickyNote = new stickyNotes();
        stickyNote.openNotes();
        TextBox reminderDescription = stickyNote.GetUserNotesSquare();
        reminderDescription.Text = "Hello";
        stickyNote.resetNotes();
        Assert.AreEqual(string.Empty, reminderDescription.Text, "there is still written content in stickyNotes after calling resetNotes");
    }
}