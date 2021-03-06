﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.Model
{
    public class Song : MediaData
    {
        public enum Source
        {
            NetEase, Mp3WithMe,
        }

        public string id { get; set; }
        public string numList { get; set; }
        public int fbCont { get; set; }
        public string songName { get; set; }
        public string artistName { get; set; }
        public string duration { get; set; }
        public string uri { get; set; }
        public SongInfo infoSong { get; set; }
        public Song.Source source { get; set; }
        private String downloadImage;

        public Song(string id, string numList, string songName, string artistName, string duration, string uri, Song.Source source)
        {
            this.id = id;
            this.numList = numList;
            this.songName = songName;
            this.artistName = artistName;
            this.duration = duration;
            this.uri = uri;
            this.source = source;
            downloadImage = "";
        }

        public Song()
        {
        }

        public Song(int fbCont, string id, string songName, string artistName, string duration, string uri, Song.Source source)
        {
            this.fbCont = fbCont;
            this.id = id;
            this.songName = songName;
            this.artistName = artistName;
            this.duration = duration;
            this.uri = uri;
            this.source = source;
        }


    }
}
