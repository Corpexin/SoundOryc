using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.Model
{
    public class SongInfo
    {
        public string dfsid { get; set; }
        public string bitrate { get; set; }
        public string extension { get; set; }
        public int type { get; set; }

        public SongInfo(string dfsid, string bitrate, string extension, int type)
        {
            this.dfsid = dfsid;
            this.bitrate = bitrate;
            this.type = type;
            this.extension = extension;
        }
    }
}
