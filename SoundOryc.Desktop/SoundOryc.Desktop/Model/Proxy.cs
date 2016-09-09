using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.Model
{
    [Serializable]
    public class Proxy
    {
        public string uri { get; set; }

        public Proxy(string uri)
        {
            this.uri = uri;
        }
    }
}
