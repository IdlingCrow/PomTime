using System.Windows.Media;
using System.Media;
using System.Diagnostics;
using System.IO;
namespace PomTimeApp;
/// <summary>
/// Used to control music and any sound effect
/// </summary>
public class SoundModel
{

    private int timesRingCalledPlay;

    private int timeMusicCalledPause;

    private int timeMusicCalledPlay;
    SoundPlayer ring;
    MediaPlayer music;

    //Used to store a path to the music folder
    string musicPath;

    //Used to actually parse the file into its audio file
    string[] musics;

    //used to know which song in musics is crrently in the media player
    int currSong;

    //Used to identify if the we should move on to the next piece of music
    //because the mediaPlayer stop
    bool playingMusic;

    //Put a name to the commonly used sound effect, create a path to the music
    //folder, parse the audio file from that folder, Open a song and set
    //up what to do when the audio file reaches its ends
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

    //Used to play the ring sound effect
    public void playSound()
    {
        ring.Play();
        timesRingCalledPlay++;
    }

    //Used to start or resume the music
    public void playMusic()
    {
        music.Volume = 0.5;
        music.Play();
        timeMusicCalledPlay++;
        playingMusic = true;
    }

    //Used to open the music folder
    //in file explorer so the user can put
    //in their own music
    public void manageMusic()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = musicPath,
            UseShellExecute = true
        });
    }

    //Used to stop the music
    public void stopMusic()
    {
        playingMusic = false;
        music.Pause();
        timeMusicCalledPause++;
    }

    //Used to indicate the end of a session
    //it just plays double of the ring dound
    public async Task playDoubleSound()
    {
        playSound();
        await Task.Delay(700);
        playSound();
    }

    //Check if music is playing
    public bool isPlayingMusic()
    {
        return playingMusic;
    }

    //Used to switch to the next track
    public void playNext()
    {
        refreshList();
        if (currSong + 1 >= musics.Length)
        {
            currSong = 0;
        } else
        {
            currSong++;
        }
        music.Open(new Uri(musics[currSong]));
        playMusic();

    }

    //Used to switch to the previous track
    public void playPreviousMusic()
    {
        refreshList();
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

    //used to look at the folder again to see if
    //anything has changed and adjust accordingly
    public void refreshList()
    {
        musics = Directory.GetFiles(musicPath, "*.mp3");
    }

    //code for testPurpose
    internal string[] getMusicList()
    {
        return musics;
    }

    internal string getCurrentMusic()
    {
        return music.Source.LocalPath;
    }

    internal int getTimesRingCalledPlay()
    {
        return timesRingCalledPlay;
    }

    internal int getTimeMusicCalledPlay()
    {
        return timeMusicCalledPlay;
    }

    internal int getTimeMusicCalledPause()
    {
        return timeMusicCalledPause;
    }
}
