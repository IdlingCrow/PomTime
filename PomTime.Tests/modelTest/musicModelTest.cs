using PomTimeApp;

namespace PomTime.Tests;

[TestClass]
public sealed class musicModelTest
{

    [TestMethod]
    public void playSoundTestForMusicModel()
    {
        SoundModel soundModel = new SoundModel();
        soundModel.playSound();

        Assert.AreEqual(1,soundModel.getTimesRingCalledPlay(), "ring should only play exactly once after calling playSound");
    }

    [TestMethod]
    public async Task playDoubleSoundTestForMusicModel()
    {
        SoundModel soundModel = new SoundModel();
        await soundModel.playDoubleSound();
        Assert.AreEqual(2,soundModel.getTimesRingCalledPlay(), "ring should only play twice after calling playDoubleSound");
    }

    [TestMethod]
    public void playMusicTestForMusicModel()
    {
        SoundModel soundModel = new SoundModel();
        soundModel.playMusic();
        Assert.AreEqual(1, soundModel.getTimeMusicCalledPlay(), "music should be playing");
        Assert.IsTrue(soundModel.isPlayingMusic(), "music should be detected as playing");

    }

    [TestMethod]
    public void stopMusicTestForMusicModel()
    {
        SoundModel soundModel = new SoundModel();
        soundModel.stopMusic();
        Assert.AreEqual(1, soundModel.getTimeMusicCalledPause(), "function should detect to have stopped once after calling stopMusic");
        Assert.IsFalse(soundModel.isPlayingMusic(), "music should not be detected as playing");
    }

    [TestMethod]
    public void musicSkipAndPlayPreviousForMusicModel()
    {
        SoundModel soundModel = new SoundModel();

        string[] musicList = soundModel.getMusicList();

        soundModel.playNext();
        Assert.AreEqual(musicList[1], soundModel.getCurrentMusic(), "Music did not actually go to the next track after calling playNextMusic");

        soundModel.playPreviousMusic();
        Assert.AreEqual(musicList[0], soundModel.getCurrentMusic(), "Music did not actually go to the back after calling playPreviousMusic");

        soundModel.playPreviousMusic();
        Assert.AreEqual(musicList[musicList.Length - 1], soundModel.getCurrentMusic(), "Music track did not loop all the way to the last track after calling playPreviousMusic when at the begginning of the list");

        soundModel.playNext(); 
        Assert.AreEqual(musicList[0], soundModel.getCurrentMusic(), "Music track did not loop back from the last music to the first after calling playNext on the last song of the list");
    }

    
}