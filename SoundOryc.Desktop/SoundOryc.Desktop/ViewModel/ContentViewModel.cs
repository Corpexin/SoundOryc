using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        public const string songsEnabledPropertyName = "songsEnabled";
        private bool _songsEnabled = true;

        public const string artistsEnabledPropertyName = "artistsEnabled";
        private bool _artistsEnabled = true;

        public const string albumsEnabledPropertyName = "albumsEnabled";
        private bool _albumsEnabled = true;

        public const string lblPageContentPropertyName = "lblPageContent";
        private string _lblPageContent = "1";

        public const string songsListPropertyName = "songsList";
        private ObservableCollection<Song> _songsList = new ObservableCollection<Song>();

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



        public ContentViewModel()
        {
            Messenger.Default.Register<string>(this, "lblPageDefault", message =>
            {
                lblPageContent = message;
            });

            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));
            songsList.Add(new Song("ja", "1", "hola", "paco", "3:03", "www"));

        }

    }
}
