using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Exceptions;
using FireSharp.Config;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Response;
using SoundOryc.Desktop.Model;
using System.Collections.ObjectModel;
using System.Security;
using System.Runtime.InteropServices;

namespace SoundOryc.Desktop.Utilities
{
    public static class FirebaseC
    {
        
        private static FirebaseClient _client;
        private static FirebaseAuthProvider authProvider;

        public static void loadFirebase()
        {
            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = Passwords.FirebaseSecret, //if you get error here, create class Passwords with these elements. They are string containing sensible data. Custom with your own, or ask me if colaborator.
                BasePath = Passwords.BasePath //if you get error here, create class Passwords with these elements. They are string containing sensible data. Custom with your own, or ask me if colaborator. 
            };

            _client = new FirebaseClient(config);
            authProvider = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(Passwords.FirebaseApiKey)); //if you get error here, create class Passwords with these elements. They are string containing sensible data. Custom with your own, or ask me if colaborator.

        }


        public static async Task<bool> createUser(string email, SecureString password)
        {
            bool success;
            try
            {
                FirebaseAuthLink auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, SecureStringToString(password));
                success = true;
            }
            catch (Exception) //if authentification goes wrong =(
            {
                success = false;
            }

            return success;

        }


        public static async void getUser(string UID)
        {
            FirebaseResponse response = await _client.GetAsync("users/" + UID);
        }


        public static async Task<int> checkIfUserExists(string username)
        {
            int userExists;
            try
            {
                FirebaseResponse response = await _client.GetAsync("users/" + username);
                if (response.Body == "null")
                    userExists = 1; //user doesnt exists
                else
                    userExists = 2; //user already exists
            }
            catch (FirebaseException)
            {
                userExists = 0; //ethernet error connection
            }

            return userExists;
        }

        public static async Task<Model.User> login(string email, SecureString password)
        {
            Model.User user = null;


            try
            {
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(email, SecureStringToString(password)); 
                

                try 
                {
                    FirebaseResponse response = await _client.GetAsync("users/" + auth.User.LocalId); 

                    if (!(response.Body == "null"))
                    {
                        List<PlayList> listOfPlayLists = JsonEncDec.decodeUserInfo(response.Body); 
                        if (listOfPlayLists != null)
                        {
                            user = new Model.User(auth.User.LocalId, email, password, listOfPlayLists);
                        }
                        else
                        {
                            user = new Model.User(auth.User.LocalId, email, password, null);
                        }
                    }
                    else
                    {
                        //User exists but without any playlists added yet.
                        user = new Model.User(auth.User.LocalId, email, password, null);
                    }
                }
                catch (FirebaseException)
                {
                    //bad auth, ethernet conn? or something..
                    user = null;

                }

            }
            catch (Exception)
            {
                //bad auth, ethernet conn? or something..
                user = null;
            }


            return user;
        }



        public static async Task<bool> saveSong(List<Song> songs, PlayList pl, Model.User user)
        {
            bool x = true;

            int position = pl.songs.Max(t => t.fbCont) + 1; //this code is very professional

            foreach (Song song in songs)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("idSong", song.id);
                values.Add("artistName", song.artistName);
                values.Add("songName", song.songName);
                values.Add("source", "" + song.source);

                if (song.uri == null)
                {
                    values.Add("uri", "empty");
                }
                else
                {
                    values.Add("uri", song.uri);
                }

                values.Add("duration", song.duration); //no duration with mp3with =(
                try
                {
                    var response = await _client.SetAsync("users/" + user.UID + "/" + pl.namePl + "/" + position + "/", values);
                }
                catch (FirebaseException)
                {
                    x = false;
                }
                position++;
            }
            return x;
        }

        public static async Task<bool> createPlaylist(ObservableCollection<Song> songs, string result, Model.User user)
        {
            bool x = true;
            int cont = 0;
            ObservableCollection<Song> songAux = new ObservableCollection<Song>();

            if (user == null)
            {
                x = false;
            }
            else
            {
                foreach (Song s in songs)
                {
                    songAux.Add(s);
                }
                foreach (Song song in songAux)
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();
                    values.Add("idSong", song.id);
                    values.Add("artistName", song.artistName);
                    values.Add("songName", song.songName);
                    values.Add("source", "" + song.source);
                    if (song.source == Song.Source.NetEase)
                    {
                        values.Add("uri", "empty");
                    }
                    else
                    {
                        values.Add("uri", song.uri);
                    }
                    values.Add("duration", song.duration); //no duration with mp3with =(
                    try
                    {
                        var response = await _client.SetAsync("users/" + user.UID + "/" + result + "/" + cont + "/", values);
                    }
                    catch (FirebaseException)
                    {
                        x = false;
                    }
                    cont++;
                }
            }

            return x;

        }


        public static async Task<bool> deletePlaylist(PlayList selectedItem, Model.User user)
        {
            bool x;
            try
            {
                var response = await _client.DeleteAsync("users/" + user.UID + "/" + selectedItem.namePl + "/");
                x = true;
            }
            catch (FirebaseException)
            {
                x = false;
            }
            return x;
        }


        static String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        internal static async Task<bool> deleteSongs(PlayList playlist, List<int> songIndexList, Model.User user)
        {
            bool x;
            try
            {
                foreach (int i in songIndexList)
                {
                    var response = await _client.DeleteAsync("users/" + user.UID + "/" + playlist.namePl + "/" +i+ "/");
                }

                x = true;
            }
            catch (FirebaseException)
            {
                x = false;
            }
            return x;
        }

        
    }
}
