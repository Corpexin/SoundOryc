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
        internal static ObservableCollection<Song> getCanciones(string json, int page)
        {
            ObservableCollection<Song> listaCanciones;
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
                listaCanciones = new ObservableCollection<Song>();

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
    }
}
