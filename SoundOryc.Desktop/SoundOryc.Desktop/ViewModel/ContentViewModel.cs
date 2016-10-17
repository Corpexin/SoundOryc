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
        private bool isUserLogged=false;
        public const string IsContentVisiblePropertyName = "isContentVisible";
        private bool _isContentVisible = false;

        public const string IsContextmenuVisibleePropertyName = "isContextmenuVisible";
        private bool _isContextmenuVisible = false;

        public const string IsAddPlaylistMIVisiblePropertyName = "isAddPlaylistMIVisible";
        private bool _isAddPlaylistMIVisible = false;

        public const string IsDeleteSongMIVisibleePropertyName = "isDeleteSongMIVisible";
        private bool _isDeleteSongMIVisible = false;

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

        public bool isContextmenuVisible
        {
            get
            {
                return _isContextmenuVisible;
            }

            set
            {
                if (_isContextmenuVisible == value)
                {
                    return;
                }

                _isContextmenuVisible = value;
                RaisePropertyChanged(IsContextmenuVisibleePropertyName);
            }
        }

        public bool isAddPlaylistMIVisible
        {
            get
            {
                return _isAddPlaylistMIVisible;
            }

            set
            {
                if (_isAddPlaylistMIVisible == value)
                {
                    return;
                }

                _isAddPlaylistMIVisible = value;
                RaisePropertyChanged(IsAddPlaylistMIVisiblePropertyName);
            }
        }

        public bool isDeleteSongMIVisible
        {
            get
            {
                return _isDeleteSongMIVisible;
            }

            set
            {
                if (_isDeleteSongMIVisible == value)
                {
                    return;
                }

                _isDeleteSongMIVisible = value;
                RaisePropertyChanged(IsDeleteSongMIVisibleePropertyName);
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
                    if (selectedItems.Count != 0)
                    {
                        Messenger.Default.Send(selectedItems, "addSongToQueue");
                    }
                });
            }
        }

        public RelayCommand<MouseButtonEventArgs> addQueueAlone
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>((e) => {
                    if(selectedItems.Count != 0)
                    {
                        Messenger.Default.Send(selectedItems, "addSongToQueue");
                    }
                });
            }
        }

        public RelayCommand<Song> deleteSongFromPlayList
        {
            get
            {
                return new RelayCommand<Song>((e) => {
                    if (selectedItems.Count != 0)
                    {
                        List<Song> aux = new List<Song>();
                        foreach(Song s in selectedItems)
                        {
                            aux.Add(s);
                        }
                        foreach (Song s in aux)
                        {
                            songsList.Remove(s);
                        }
                       
                        Messenger.Default.Send(aux, "deleteSongsFromPlaylist");
                    }
                });
            }
        }


        public RelayCommand<Song> createNew
        {
            get
            {
                return new RelayCommand<Song>((e) => {
                    if (selectedItems.Count != 0)
                    {
                        //Open write name dialog
                        Object[] msg = new Object[2];
                        msg[0] = "Write a name for your new playlist!";
                        msg[1] = selectedItems;
                        Messenger.Default.Send(msg, "openWritePlaylistNameDialog");
                    }
                });
            }
        }


        public ContentViewModel()
        {
            Messenger.Default.Register<ObservableCollection<MediaData>>(this, "fillContentList",  message =>
            {

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
                isContextmenuVisible = true;
                if (isUserLogged)
                {
                    isAddPlaylistMIVisible = true;
                }
                isDeleteSongMIVisible = false;
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

            //SHOULD CALL PROGRESS DIALOG
            Messenger.Default.Register<Object[]>(this, "saveSongsFirebase", async message =>
            {
                Object[] r = new Object[2];

                List<Song> auxL = new List<Song>();

                
                foreach (Song s in selectedItems)
                {
                    s.numList = null;
                    auxL.Add(s);
                }
                List<int> resultList = await FirebaseC.saveSong(auxL, (PlayList)message[0], (User)message[1]);
                if (resultList.Count != 0)
                {
                    switch((int)message[2])
                    {
                        case 0: //case songs added through context menu
                            r[0] = auxL;
                            r[1] = resultList;
                            Messenger.Default.Send(r, "addSongsToContextPlaylists");
                            break;
                        case 1://case songs added through "create new" button
                               //add songs locally and add playlist to context menu
                               //add playlists into contextMenu.
                            Messenger.Default.Send(true, "reloadContextMenu");
                            break;
                    }
                                  
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
                isContextmenuVisible = true;
                isContentVisibleUp = false;
                isAddPlaylistMIVisible = false;
                isDeleteSongMIVisible = true;
                playlistName = message.namePl;
                isContentPlaylistVisible = true;
                List<Song> aux = new List<Song>();
                foreach(Song s in message.songs)
                {
                    Song s2 = new Song(s.fbCont, s.id, s.songName, s.artistName, s.duration, s.uri, s.source);
                    s2.numList = null;
                    aux.Add(s2);
                }
                message.songs = aux;
                songsList.Clear();
                foreach (Song s in aux)
                {
                    songsList.Add(s);
                }
            });

            Messenger.Default.Register<User>(this, "UserLogged", message =>
            {
                isAddPlaylistMIVisible = true;
                isUserLogged = true;
            });

          
        }


    }
}
