using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundOryc.Desktop.Model;
using System.Net;
using System.IO;
using SoundOryc.Desktop.Utilities;
using System.Security.Cryptography;
using GalaSoft.MvvmLight.Messaging;

namespace SoundOryc.Desktop.Services
{
    public class Netease
    {
        public static ObservableCollection<Proxy> proxies = new ObservableCollection<Proxy>();
        public static int contP;
        public static int contS;

        public static void fillProxies()
        {
            Netease.proxies.Add(new Proxy("http://"));
            //Netease.proxies.Add(new Proxy("http://183.95.80.168/"));
            //Netease.proxies.Add(new Proxy("http://111.11.122.7/"));
            //Netease.proxies.Add(new Proxy("http://219.138.27.33/"));
            //Netease.proxies.Add(new Proxy("http://49.117.146.206/"));
            //Netease.proxies.Add(new Proxy("http://49.117.146.208/"));
            //Netease.proxies.Add(new Proxy("http://49.117.146.204/"));
            //Netease.proxies.Add(new Proxy("http://117.135.251.132/"));
        }


        internal static  ObservableCollection<MediaData> searchSongs(string searchText, int type, int page)
        {
            page--;
            ObservableCollection<MediaData> result = null;

            string s = "s=" + searchText + "&type=" + type + "&offset=" + (page * 25) + "&sub=false&limit=25";

            // encode form data
            StringBuilder postString = new StringBuilder();
            byte[] postBytes = Encoding.ASCII.GetBytes(s);


            bool error = true;
            int cont = 0;

            while (error)//loop for trying at least 3 times if error
            {
                // set up request object
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://music.163.com/api/search/get");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                request.Headers.Add(HttpRequestHeader.Cookie, "appver=2.0.2");
                request.Referer = "http://music.163.com";
                request.Timeout = 10000;
                try
                {
                    using (var stream = request.GetRequestStream()) //wasting some time
                    {
                        stream.Write(postBytes, 0, postBytes.Length);
                    }
                    var response = (HttpWebResponse)request.GetResponse();//wasting time infinite
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    result = addToList(responseString.ToString(), type, page); //added to the list the result of json
                    error = false;
                }
                catch (Exception)
                {
                    if (cont == 3)
                    {
                        result =  addToList("Error. Ethernet connection seems not working", -1, page);
                        error = false;
                    }
                    cont++;
                }
            }


            return result;
        }

        internal static ObservableCollection<MediaData> searchAlbums(string message, int v, int page)
        {
            throw new NotImplementedException();
        }

        internal static ObservableCollection<MediaData> searchArtists(string message, int v, int page)
        {
            throw new NotImplementedException();
        }


        //Populates the list with the result of json
        private static ObservableCollection<MediaData> addToList(string result, int type, int page)
        {
            
            ObservableCollection<MediaData> songList = null;
            switch (type)
            {
                case 100://Artists
                    break;
                case 1://Songs
                    songList = JsonEncDec.getCanciones(result.ToString(), page);
                    if (songList == null)
                    {
                        songList = new ObservableCollection<MediaData>();
                        songList.Add(new Song("", "", "", "No matches found...", "", "", Song.Source.NetEase));
                    }
                    break;
                case -1://Error
                    songList = new ObservableCollection<MediaData>();
                    songList.Add(new Song("", "", "", result, "", "", Song.Source.NetEase));
                    break;
            }
            return songList;

            
        }

        internal static async Task<string> getInfoSong(Song song)
        {
            string s =  await Task.Run(() => downloadInfoSong(song));
            if (s != null)
            {
                return s;
            }
            else
            {
                String[] st = new String[2];
                st[0] = "Error. couldn't load song";
                st[1] = "Tried to get the link using every proxy available 2 times. None of them seems to work. Try again or add some more proxies.";
                Messenger.Default.Send(st, "openInfoDialog");
                return s;
            }
            
        }


        private static async Task<string> downloadInfoSong(Song song)
        {
            bool goOut = false;
            contP = 0;
            contS = 0;
            while (!goOut)
            {
                try
                {
                    string url = proxies[contP].uri + "music.163.com/api/song/detail?ids=[" + song.id + "]";
                    string info = await getInfoTask(url);
                    song.infoSong = JsonEncDec.getInfoSong(info);
                    string encriptedKey = encryptSongId(song.infoSong.dfsid);
                    song.uri = "http://p3.music.126.net/" + encriptedKey + "/" + song.infoSong.dfsid + ".mp3";
                    goOut = true;
                }
                catch (Exception)
                {
                    if (contS < proxies.Count * 2) {
                        if (contP <= proxies.Count - 1)
                        {
                            contP++;
                        }
                        else
                        {
                            contP = 0;
                        }
                        contS++;
                    }
                    else
                    {
                        goOut = true;
                        song.uri = null;
                    }

                    
                }
            }

            return song.uri;
        }


        //Encrypts song download id
        public static string encryptSongId(string dfsid)
        {
            string encrypted;
            byte[] byte1 = Encoding.ASCII.GetBytes("3go8&$8*3*3h0k(2)2");
            byte[] byte2 = Encoding.ASCII.GetBytes(dfsid);
            var byte1_len = byte1.Length;

            for (int i = 0; i < byte2.Length; i++)
            {
                byte2[i] = (byte)(byte2[i] ^ byte1[i % byte1_len]);
            }

            MD5 m = MD5.Create();
            encrypted = Convert.ToBase64String(m.ComputeHash(byte2)); //[:-1]??
            encrypted = encrypted.Replace('/', '_');
            encrypted = encrypted.Replace('+', '-');

            return encrypted;
        }


        //Async task with a web request for downloading song information
        private static async Task<string> getInfoTask(string url)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.Method = "GET";
            request.Accept = "application/json";
            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
            var responseStream = responseObject.GetResponseStream();
            var sr = new StreamReader(responseStream);
            string received = await sr.ReadToEndAsync();
            return received;
        }

    }
}
