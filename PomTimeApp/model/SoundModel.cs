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
    int currSong;
    bool playingMusic;
    public SoundModel()
    {
        ring = new SoundPlayer(Properties.Resources.ring);
        musicPath = System.IO.Path.Combine(Application.StartupPath, "model", "music");
        musics = System.IO.Directory.GetFiles(musicPath, "*.mp3");
        music = new MediaPlayer();
        currSong = 0;

        //volume set to 0 for a bug with media player
        //that cause a blip if media player call open
        //during initalization
        music.Volume = 0;
        music.Open(new Uri(musics[currSong]));

        playingMusic = false;
        music.MediaEnded += (s, e) =>
        {
            if(playingMusic)
            {
                playNext();
            }
        };
    }

    public void playSound()
    {
        ring.Play();
    }

    public void playMusic()
    {
        music.Volume = 0.5;
        music.Play();
        playingMusic = true;
    }

    public void manageMusic()
    {
        Debug.WriteLine("message Recived");
        Process.Start(new ProcessStartInfo
        {
            FileName = musicPath,
            UseShellExecute = true
        });
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

    public void playNext()
    {
        if(currSong + 1 >= musics.Length)
        {
            currSong = 0;
        } else
        {
            currSong++;
        }
        music.Open(new Uri(musics[currSong]));
        playMusic();

    }

    public void playPreviousMusic()
    {
        if (currSong - 1 < 0)
        {
            currSong = musics.Length - 1;
        }
        else
        {
            currSong--;
        }
        music.Open(new Uri(musics[currSong]));
        playMusic();
    }
}