using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.Model
{
    public class User
    {

        public User(string UID, string email, SecureString password, List<PlayList> playLists)
        {
            this.UID = UID;
            this.email = email;
            this.password = password;
            this.playLists = playLists;
        }

        public string UID { get; set; }
        public string email { get; set; }
        public SecureString password { private get; set; }
        public List<PlayList> playLists { get; set; }
    }
}
