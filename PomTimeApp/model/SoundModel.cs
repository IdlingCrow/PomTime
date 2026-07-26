using System.Media;
namespace PomTimeApp;

public class SoundModel
{
    SoundPlayer ring;
    SoundPlayer music;
    public SoundModel()
    {
        ring = new SoundPlayer(Properties.Resources.ring);
        music = new SoundPlayer(Properties.Resources.startingLofiMusic);
    }

    public void playSound()
    {
        ring.Play();
    }

    public void playMusic()
    {
        music.PlayLooping();
    }

    public void stopMusic()
    {
        music.Stop();
    }

    public async void playDoubleSound()
    {
        ring.Play();
        await Task.Delay(700);
        ring.Play();
    }
}