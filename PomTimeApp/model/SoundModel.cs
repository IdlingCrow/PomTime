using System.Windows.Media;
using System.Media;
using System.Diagnostics;
using System.IO;
namespace PomTimeApp;

public class SoundModel
{
    SoundPlayer ring;
    MediaPlayer music;
    string musicPath;
    string[] musics;
    bool playingMusic;
    public SoundModel()
    {
        ring = new SoundPlayer(Properties.Resources.ring);
        musicPath = System.IO.Path.Combine(Application.StartupPath, "model", "music");
        musics = System.IO.Directory.GetFiles(musicPath, "*.mp3");
        music = new MediaPlayer();
        music.Volume = 0.5;
        music.Open(new Uri(musics[0]));
        playingMusic = false;
        music.MediaEnded += (s, e) =>
        {
            if(playingMusic)
            {
                music.Position = TimeSpan.Zero;
                music.Play();
            }
        };
    }

    public void playSound()
    {
        ring.Play();
    }

    public void playMusic()
    {
        music.Play();
        playingMusic = true;
    }

    public void stopMusic()
    {
        playingMusic = false;
        music.Pause();
    }

    public async void playDoubleSound()
    {
        ring.Play();
        await Task.Delay(700);
        ring.Play();
    }

    public bool isPlayingMusic()
    {
        return playingMusic;
    }
}