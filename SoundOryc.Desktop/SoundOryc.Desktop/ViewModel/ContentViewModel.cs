﻿using GalaSoft.MvvmLight;
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
using System.Windows.Input;

namespace SoundOryc.Desktop.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        public const string IsContentVisiblePropertyName = "isContentVisible";
        private bool _isContentVisible = false;

        public const string songsEnabledPropertyName = "songsEnabled";
        private bool _songsEnabled = true;

        public const string artistsEnabledPropertyName = "artistsEnabled";
        private bool _artistsEnabled = true;

        public const string albumsEnabledPropertyName = "albumsEnabled";
        private bool _albumsEnabled = true;

        public const string lblPageContentPropertyName = "lblPageContent";
        private string _lblPageContent = "1";

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

        public RelayCommand<MouseButtonEventArgs> selectSong
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>((e) => {
                    Song item = (Song)((FrameworkElement)e.OriginalSource).DataContext;
                    if (item != null)
                    {
                        Messenger.Default.Send(item, "addSongToQueue");
                        Messenger.Default.Send(item, "playSong");
                    }
                });
            }
        }


        public RelayCommand<IList> SelectionChangedCommand { get; private set; }



        public RelayCommand<MouseButtonEventArgs> addQueue
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>((e) => {
                    //ADD THE LIST SELECTED ITEMS TO QUEUE WITH SEND
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



        public ContentViewModel()
        {
            Messenger.Default.Register<ObservableCollection<MediaData>>(this, "fillContentList",  message =>
            {
                isContentVisible = false;
                songsList.Clear();
                lblPageContent = "1";
                foreach (Song s in message)
                {
                    songsList.Add(s);
                }

                Messenger.Default.Send("", "searchCompleted");
                isContentVisible = true;
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

        }


    }
}
