using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace PomTimeApp.model
{
    public interface SoundInterface
    {
        void Play();
    }

    public class SoundWrapper : SoundInterface
    {
        private readonly SoundPlayer player;
        public SoundWrapper()
        {
            player = new SoundPlayer(Properties.Resources.ring);
            player.Load();
        }

        public void Play()
        {
            player.Play();
        }
    }

    public class SoundTest : SoundInterface 
    {

        private int playCount;
        public SoundTest()
        {
            playCount = 0;
        }

        public void Play()
        {
            playCount++;
        }

        public int GetPlayCount() {
            return playCount;
        }
    }
}
