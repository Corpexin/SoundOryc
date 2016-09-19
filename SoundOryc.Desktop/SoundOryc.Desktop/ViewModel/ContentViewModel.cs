using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Services;
using SoundOryc.Desktop.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SoundOryc.Desktop.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        public const string IsContentVisiblePropertyName = "isContentVisible";
        private bool _isContentVisible = false;

        public const string IsContentVisibleUpPropertyName = "isContentVisibleUp";
        private bool _isContentVisibleUp = false;

        public const string IsContentPlaylistVisiblePropertyName = "isContentPlaylistVisible";
        private bool _isContentPlaylistVisible = false;

        public const string songsEnabledPropertyName = "songsEnabled";
        private bool _songsEnabled = false;

        public const string artistsEnabledPropertyName = "artistsEnabled";
        private bool _artistsEnabled = true;

        public const string albumsEnabledPropertyName = "albumsEnabled";
        private bool _albumsEnabled = true;

        public const string lblPageContentPropertyName = "lblPageContent";
        private string _lblPageContent = "1";

        public const string playlistNamePropertyName = "playlistName";
        private string _playlistName = "";

        private List<Song> selectedItems = new List<Song>();


        public const string songsListPropertyName = "songsList";
        private ObservableCollection<Song> _songsList = new ObservableCollection<Song>();
        






        public bool isContentVisible
        {
            get
            {
                return _isContentVisible;
            }

            set
            {
                if (_isContentVisible == value)
                {
                    return;
                }

                _isContentVisible = value;
                RaisePropertyChanged(IsContentVisiblePropertyName);
            }
        }

        public bool isContentVisibleUp
        {
            get
            {
                return _isContentVisibleUp;
            }

            set
            {
                if (_isContentVisibleUp == value)
                {
                    return;
                }

                _isContentVisibleUp = value;
                RaisePropertyChanged(IsContentVisibleUpPropertyName);
            }
        }

        public bool isContentPlaylistVisible
        {
            get
            {
                return _isContentPlaylistVisible;
            }

            set
            {
                if (_isContentPlaylistVisible == value)
                {
                    return;
                }

                _isContentPlaylistVisible = value;
                RaisePropertyChanged(IsContentPlaylistVisiblePropertyName);
            }
        }

        public bool songsEnabled
        {
            get
            {
                return _songsEnabled;
            }

            private set
            {
                if (_songsEnabled == value)
                {
                    return;
                }

                _songsEnabled = value;
                RaisePropertyChanged(songsEnabledPropertyName);
            }
        }

        public bool artistsEnabled
        {
            get
            {
                return _artistsEnabled;
            }

            private set
            {
                if (_artistsEnabled == value)
                {
                    return;
                }

                _artistsEnabled = value;
                RaisePropertyChanged(artistsEnabledPropertyName);
            }
        }

        public bool albumsEnabled
        {
            get
            {
                return _albumsEnabled;
            }

            private set
            {
                if (_albumsEnabled == value)
                {
                    return;
                }

                _albumsEnabled = value;
                RaisePropertyChanged(albumsEnabledPropertyName);
            }
        }

        public string lblPageContent
        {
            get
            {
                return _lblPageContent;
            }

            private set
            {
                if (_lblPageContent == value)
                {
                    return;
                }

                _lblPageContent = value;
                RaisePropertyChanged(lblPageContentPropertyName);
            }
        }


        public string playlistName
        {
            get
            {
                return _playlistName;
            }

            private set
            {
                if (_playlistName == value)
                {
                    return;
                }

                _playlistName = value;
                RaisePropertyChanged(playlistNamePropertyName);
            }
        }


        public ObservableCollection<Song> songsList
        {
            get
            {
                return _songsList;
            }

            private set
            {
                if (_songsList == value)
                {
                    return;
                }

                _songsList = value;
                RaisePropertyChanged(songsListPropertyName);
            }
        }




        public RelayCommand songsClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (songsEnabled)
                    {
                        songsEnabled = false;
                        artistsEnabled = true;
                        albumsEnabled = true;
                    }
                    else
                    {
                        songsEnabled = true;
                        artistsEnabled = false;
                        albumsEnabled = false;
                    }
                });
            }
        }


        public RelayCommand artistsClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (artistsEnabled)
                    {
                        artistsEnabled = false;
                        albumsEnabled = true;
                        songsEnabled = true;
                    }
                    else
                    {
                        artistsEnabled = true;
                        albumsEnabled = false;
                        songsEnabled = false;
                    }
                });
            }
        }


        public RelayCommand albumsClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (albumsEnabled)
                    {
                        albumsEnabled = false;
                        songsEnabled = true;
                        artistsEnabled = true;
                    }
                    else
                    {
                        albumsEnabled = true;
                        songsEnabled = false;
                        artistsEnabled = false;
                    }
                });
            }
        }




        public RelayCommand<IList> SelectionChangedCommand { get; private set; }



        public RelayCommand<Song> addQueue
        {
            get
            {
                return new RelayCommand<Song>((e) => {
                        Messenger.Default.Send(selectedItems, "addSongToQueue");
                });
            }
        }

        public RelayCommand addPlaylist
        {
            get
            {
                return new RelayCommand(() => {
                    
                });
            }
        }

        public RelayCommand createNew
        {
            get
            {
                return new RelayCommand(() => {
                    
                });
            }
        }

        public RelayCommand<Song> RemoveItem
        {
            get
            {
                return new RelayCommand<Song>((e) => {
                    isContentVisible = false;
                });
            }
        }


        public ContentViewModel()
        {
            Messenger.Default.Register<ObservableCollection<MediaData>>(this, "fillContentList",  message =>
            {
                isContentVisible = false;
                isContentPlaylistVisible = false;
                isContentVisibleUp = false;
                songsList.Clear();
                lblPageContent = "1";
                foreach (Song s in message)
                {
                    songsList.Add(s);
                }

                Messenger.Default.Send("", "searchCompleted");
                isContentVisible = true;
                isContentVisibleUp = true;
            });


            SelectionChangedCommand = new RelayCommand<IList>(items =>
            {
                if (items != null)
                {
                    selectedItems.Clear();
                    foreach(Song s in items)
                    {
                        selectedItems.Add(s);
                    }
                }
            });


            Messenger.Default.Register<Object[]>(this, "saveSongsFirebase", async message =>
            {
                List<Song> auxL = new List<Song>();

                foreach (Song s in selectedItems)
                {
                    s.numList = null;
                    auxL.Add(s);
                }
                bool x = await FirebaseC.saveSong(auxL, (PlayList)message[0], (User)message[1]);
                if (x)
                {
                    Messenger.Default.Send(auxL, "addSongsToPlaylists");
                }
                else
                {
                    string[] ms = new string[2];
                    ms[1] = "Ethernet connection lost";
                    Messenger.Default.Send(ms, "openInfoDialog");
                }
            });


            Messenger.Default.Register<PlayList>(this, "loadPlaylist", message =>
            {
                isContentVisibleUp = false;
                playlistName = message.namePl;
                isContentPlaylistVisible = true;
                songsList.Clear();
                foreach (Song s in message.songs)
                {
                    s.numList = null;
                    songsList.Add(s);
                }
            });


        }


    }
}
