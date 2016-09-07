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

namespace SoundOryc.Desktop.Services
{
    public class Netease
    {
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
    }
}
