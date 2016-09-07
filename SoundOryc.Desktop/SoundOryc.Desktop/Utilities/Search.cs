using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.ViewModel;
using System.Collections.ObjectModel;
using SoundOryc.Desktop.Services;

namespace SoundOryc.Desktop.Utilities
{
    public class Search
    {
        public const int TYPE_SONG = 1;
        public const int TYPE_ARTIST = 100;

        internal async static Task<ObservableCollection<MediaData>> search(string message, bool isNetease, int page, int type)
        {
            if (type == TYPE_SONG)
            {
                return await Task.Run(() => getSongs(message, isNetease, page));
            }
            else if (type == TYPE_ARTIST)
            {
                return await Task.Run(() => getArtists(message, page));
            }
            else
            {
                return await Task.Run(() => getAlbums(message, page));
            }           
        }

        private static ObservableCollection<MediaData> getSongs(string message, bool isNetease, int page)
        {
            ObservableCollection<MediaData> songs;
            if (isNetease)
            {
                songs = Netease.searchSongs(message, 1, page);
            }
            else
            {
                songs = Mp3With.search(message);
            }
            return songs;
        }

        //not implemented yet
        private static ObservableCollection<MediaData> getArtists(string message, int page)
        {
            ObservableCollection<MediaData> artists;

            artists = Netease.searchArtists(message, 1, page);
           
            return artists;
        }

        private static ObservableCollection<MediaData> getAlbums(string message, int page)
        {
            ObservableCollection<MediaData> albums;

            albums = Netease.searchAlbums(message, 1, page);
            
            return albums;
        }
    }
}
