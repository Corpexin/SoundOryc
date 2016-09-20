using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundOryc.Desktop.Model;
using System.Net;
using System.Web;
using HtmlAgilityPack;


namespace SoundOryc.Desktop.Services
{
    public class Mp3With
    {
        internal static  ObservableCollection<MediaData> search(string query)
        {
            ObservableCollection<MediaData> result = new ObservableCollection<MediaData>();
            if (String.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("Argument " + nameof(query) + " is null or whitespace.");
            UriBuilder uriBuilder = new UriBuilder("http://mp3with.co/search/");
            var parser = HttpUtility.ParseQueryString(string.Empty);
            parser["q"] = query;
            uriBuilder.Query = parser.ToString();
            string rawHtml = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    rawHtml = client.DownloadString(uriBuilder.Uri);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(rawHtml);
                    //List<Song> output = new List<Song>();
                    int cont = 1;
                    foreach (HtmlNode node in doc.DocumentNode.SelectSingleNode("//ul[@class=\"songs\"]").SelectNodes("li"))
                    {
                        result.Add(new Song("" + node.Attributes["data-mp3"].Value, "" + cont, node.ChildNodes[1].ChildNodes.First(n => n.Name == "strong" && !n.Attributes.Contains("class")).InnerHtml.Trim(), node.ChildNodes[1].ChildNodes.First(n => n.GetAttributeValue("class", "none") == "artist").InnerHtml.Trim(), "", "http://mp3with.co" + node.Attributes["data-mp3"].Value, Song.Source.Mp3WithMe));
                        cont++;
                    }
                }
                catch (WebException)
                {
                    result.Add(new Song(0, "", "No matches found...", "", "", "", Song.Source.NetEase));
                }
            }


            return result;
        }

       

    }
}
