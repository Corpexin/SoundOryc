using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.Model
{
    public class PlayList
    {
        private List<Song> list;
        private object v;


        public PlayList(string namePl, List<Song> songs)
        {
            this.namePl = namePl;
            this.songs = songs;
        }

        public string namePl { get; set; }
        public List<Song> songs { get; set; }
    }
}
