using SoundOryc.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SoundOryc.Desktop.Utilities
{
    public class Player
    {
        //objeto reproductor que realizara todas las acciones
        private readonly WindowsMediaPlayer player;

        //default constructor, creates a new wmp object
        public Player()
        {
            player = new WindowsMediaPlayer();
        }

        //boolean returning if player has finished playing
        public bool isFinished
        {
            get
            {
                return player.playState != WMPPlayState.wmppsPlaying &&
                       player.playState != WMPPlayState.wmppsBuffering &&
                       player.playState != WMPPlayState.wmppsPaused &&
                       player.playState != WMPPlayState.wmppsTransitioning;
            }
        }

        public bool isStopped
        {
            get
            {
                if (player.playState == WMPPlayState.wmppsStopped)
                    return true;
                else
                    return false;

            }
        }

        //volume control (with getter and setter)
        public int volume
        {
            get { return player.settings.volume; }
            set { player.settings.volume = value; }
        }

        //mute control (with getter and setter)
        public bool mute
        {
            get { return player.settings.mute; }
            set { player.settings.mute = value; }
        }

        //return de player status
        public string estatusString
        {
            get { return player.status; }
        }

        //??
        public IWMPMedia mediaActual
        {
            get { return player.currentMedia; }
        }

        //??
        public string timeActualCad
        {
            get { return player.controls.currentPositionString; }
        }

        //??
        public double timeActual
        {
            get { return player.controls.currentPosition; }
            set { player.controls.currentPosition = value; }
        }

        //play a song from an uri
        public void playSong(string uri)
        {
            player.controls.stop();
            player.URL = uri;
        }

        //continue playing a song
        public void resumeSong()
        {
            player.controls.play();
        }

        //pause a song
        public void pauseSong()
        {
            player.controls.pause();
        }

        //stop a song
        public void stopSong()
        {
            player.controls.stop();
        }

        //change to a previous song
        public void previousSong()
        {
            player.controls.previous();
        }

        //change to next song
        public void nextSong()
        {
            player.controls.next();
        }

        //close the player
        public void closePlayer()
        {
            player.close();
        }

    }
}
