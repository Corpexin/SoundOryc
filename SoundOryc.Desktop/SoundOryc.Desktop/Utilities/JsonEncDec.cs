using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundOryc.Desktop.Model;
using Newtonsoft.Json.Linq;

namespace SoundOryc.Desktop.Utilities
{
    public class JsonEncDec
    {
        public static bool highQuality = true;

        internal static ObservableCollection<MediaData> getCanciones(string json, int page)
        {
            ObservableCollection<MediaData> listaCanciones;
            int numCancion = 1;
            string numc;
            Array listaArtistas;
            string nombreArtistas = "";
            JToken id;
            JToken nombre;
            JToken artistas;
            JToken duration;
            Array listaJOCanc;
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["result"];
            page++;
            if (page == 1)
            {
                numCancion = 1;
            }
            else
            {
                page--;
                numCancion = 25 * page;
            }
            try
            {
                listaJOCanc = jUser["songs"].ToArray();
                listaCanciones = new ObservableCollection<MediaData>();

                foreach (JObject jO in listaJOCanc)
                {
                    if (numCancion < 10)
                        numc = "0" + numCancion;
                    else
                        numc = "" + numCancion;
                    id = jO.GetValue("id");
                    nombre = jO.GetValue("name");
                    duration = jO.GetValue("duration");
                    artistas = jO["artists"];
                    listaArtistas = artistas.ToArray();
                    foreach (JObject art in listaArtistas)
                    {
                        nombreArtistas = nombreArtistas + art.GetValue("name") + " / ";
                    }
                    nombreArtistas = nombreArtistas.Substring(0, nombreArtistas.Length - 2);

                    TimeSpan t = TimeSpan.FromMilliseconds(Double.Parse(duration.ToString()));
                    string answer = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

                    listaCanciones.Add(new Song(id.ToString(), numc, nombre.ToString(), nombreArtistas, answer, null, Song.Source.NetEase));
                    numCancion++;
                    nombreArtistas = "";
                }
            }
            catch (Exception)
            {
                listaCanciones = null;
            }


            return listaCanciones;
        }

        internal static SongInfo getInfoSong(string info)
        {
            SongInfo result = null;
            JObject jObject = JObject.Parse(info);
            int tipo = 1;
            JToken jUser = null;
            //Comprobacion de las calidades de la cancion
            if (highQuality)
            {
                //Better quality. More slow
                if (!jObject["songs"][0]["hMusic"].HasValues)
                    if (!jObject["songs"][0]["mMusic"].HasValues)
                        if (!jObject["songs"][0]["bMusic"].HasValues)
                            if (!jObject["songs"][0]["lMusic"].HasValues)
                                if (!jObject["songs"][0]["audition"].HasValues)
                                    jUser = null;
                                else
                                    jUser = jObject["songs"][0]["audition"];
                            else
                                jUser = jObject["songs"][0]["lMusic"];
                        else
                            jUser = jObject["songs"][0]["bMusic"];
                    else
                        jUser = jObject["songs"][0]["mMusic"];
                else
                    jUser = jObject["songs"][0]["hMusic"];
            }
            else
            {
                //Worse quality. More speed
                if (!jObject["songs"][0]["lMusic"].HasValues)
                    if (!jObject["songs"][0]["bMusic"].HasValues)
                        if (!jObject["songs"][0]["mMusic"].HasValues)
                            if (!jObject["songs"][0]["hMusic"].HasValues)
                                if (!jObject["songs"][0]["audition"].HasValues)
                                    jUser = null;
                                else
                                    jUser = jObject["songs"][0]["audition"];
                            else
                                jUser = jObject["songs"][0]["hMusic"];
                        else
                            jUser = jObject["songs"][0]["mMusic"];
                    else
                        jUser = jObject["songs"][0]["bMusic"];
                else
                    jUser = jObject["songs"][0]["lMusic"];

            }

            if (jUser != null)
                result = new SongInfo((string)jUser["dfsId"].ToString(), (string)(string)jUser["bitrate"].ToString(), (string)jUser["extension"].ToString(), tipo);

            return result;
        }

        internal static List<PlayList> decodeUserInfo(string json)
        {
            Song.Source src;

            JObject jObject = JObject.Parse(json);

            //get the playLists list
            List<PlayList> listOfPlaylist = new List<PlayList>();

            foreach (JToken playList in jObject.Children())
            {
                List<Song> songs = new List<Song>();
                foreach (JToken songEnc in playList.Children().Children())
                {

                    if (songEnc.HasValues)
                    {
                        if (songEnc["source"].ToString() == "NetEase")
                        {
                            src = Song.Source.NetEase;
                        }
                        else
                        {
                            src = Song.Source.Mp3WithMe;
                        }
                        Song s = new Song(songEnc["idSong"].ToString(), songEnc["songName"].ToString(), songEnc["artistName"].ToString(), songEnc["duration"].ToString(), songEnc["uri"].ToString(), src);
                        songs.Add(s);
                    }


                }

                PlayList playListDec = new PlayList(((JProperty)playList).Name, songs); //TODO: controlar que el nombre son solo letras o numeros
                listOfPlaylist.Add(playListDec);
            }


            return listOfPlaylist;
        }
    }
}
