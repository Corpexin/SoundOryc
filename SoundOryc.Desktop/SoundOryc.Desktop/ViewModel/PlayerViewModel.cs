using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Services;
using SoundOryc.Desktop.Utilities;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SoundOryc.Desktop.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        Player player = new Player();
        DispatcherTimer timer = new DispatcherTimer();

        public const string isPrevBtnEnabledPropertyName = "isPrevBtnEnabled";
        private bool _isPrevBtnEnabled = false;

        public const string isNextBtnEnabledPropertyName = "isNextBtnEnabled";
        private bool _isNextBtnEnabled = false;

        public const string volumeValuePropertyName = "volumeValue";
        private int _volumeValue = 100;

        public const string isSongPausedPropertyName = "isSongPaused";
        private bool _isSongPaused = true;

        public const string actualTimeContentPropertyName = "actualTimeContent";
        private string _actualTimeContent = "00:00";

        public const string totalTimeContentPropertyName = "totalTimeContent";
        private string _totalTimeContent = "00:00";

        public const string queueOpenedPropertyName = "QueueOpened";
        private bool _queueOpened = false;
        
        public const string selectedPlayModeOptionPropertyName = "selectedPlayModeOption";
        private string _selectedPlayModeOption = "rall";

        public const string isVolumeMutedPropertyName = "IsVolumeMuted";
        private bool _isVolumeMuted = true;

        public const string sliderContentPropertyName = "sliderContent";
        private int _sliderContent = 0;

        public const string sliderMaxPropertyName = "sliderMax";
        private int _sliderMax = 100;

        public const string artistNamePropertyName = "artistName";
        private string _artistName = "";

        public const string songNamePropertyName = "songName";
        private string _songName = "";



        public string songName
        {
            get
            {
                return _songName;
            }

            set
            {
                if (_songName == value)
                {
                    return;
                }

                _songName = value;
                RaisePropertyChanged(songNamePropertyName);
            }
        }

        public string artistName
        {
            get
            {
                return _artistName;
            }

            set
            {
                if (_artistName == value)
                {
                    return;
                }

                _artistName = value;
                RaisePropertyChanged(artistNamePropertyName);
            }
        }

        public bool isPrevBtnEnabled
        {
            get
            {
                return _isPrevBtnEnabled;
            }

            set
            {
                if (_isPrevBtnEnabled == value)
                {
                    return;
                }

                _isPrevBtnEnabled = value;
                RaisePropertyChanged(isPrevBtnEnabledPropertyName);
            }
        }


        public bool isNextBtnEnabled
        {
            get
            {
                return _isNextBtnEnabled;
            }

            set
            {
                if (_isNextBtnEnabled == value)
                {
                    return;
                }

                _isNextBtnEnabled = value;
                RaisePropertyChanged(isNextBtnEnabledPropertyName);
            }
        }


        public int volumeValue
        {
            get
            {
                return _volumeValue;
            }

            set
            {
                if (_volumeValue == value)
                {
                    return;
                }

                _volumeValue = value;
                RaisePropertyChanged(volumeValuePropertyName);
                player.volume = value;
            }
        }


        public bool isSongPaused
        {
            get
            {
                return _isSongPaused;
            }

            private set
            {
                if (_isSongPaused == value)
                {
                    return;
                }

                _isSongPaused = value;
                RaisePropertyChanged(isSongPausedPropertyName);
            }
        }


        public string actualTimeContent
        {
            get
            {
                return _actualTimeContent;
            }

            private set
            {
                if (_actualTimeContent == value)
                {
                    return;
                }

                _actualTimeContent = value;
                RaisePropertyChanged(actualTimeContentPropertyName);
            }
        }


        public string totalTimeContent
        {
            get
            {
                return _totalTimeContent;
            }

            private set
            {
                if (_totalTimeContent == value)
                {
                    return;
                }

                _totalTimeContent = value;
                RaisePropertyChanged(totalTimeContentPropertyName);
            }
        }


        public int sliderContent
        {
            get
            {
                return _sliderContent;
            }

            private set
            {
                if (_sliderContent == value)
                {
                    return;
                }

                _sliderContent = value;

                RaisePropertyChanged(sliderContentPropertyName);
            }
        }


        public int sliderMax
        {
            get
            {
                return _sliderMax;
            }

            private set
            {
                if (_sliderMax == value)
                {
                    return;
                }

                _sliderMax = value;

                RaisePropertyChanged(sliderMaxPropertyName);
            }
        }

        public bool QueueOpened
        {
            get
            {
                return _queueOpened;
            }

            private set
            {
                if (_queueOpened == value)
                {
                    return;
                }

                _queueOpened = value;

                RaisePropertyChanged(queueOpenedPropertyName);
                Messenger.Default.Send(QueueOpened, "queueOpen");
            }
        }

        public string selectedPlayModeOption
        {
            get
            {
                return _selectedPlayModeOption;
            }

            private set
            {
                if (_selectedPlayModeOption == value)
                {
                    return;
                }

                _selectedPlayModeOption = value;

                RaisePropertyChanged(selectedPlayModeOptionPropertyName);
            }
        }

        public bool IsVolumeMuted
        {
            get
            {
                return _isVolumeMuted;
            }

            private set
            {
                if (_isVolumeMuted == value)
                {
                    return;
                }

                _isVolumeMuted = value;

                RaisePropertyChanged(isVolumeMutedPropertyName);
            }
        }


        //plays previous song if posible
        public RelayCommand prevSong
        {
            get
            {
                return new RelayCommand(() =>
                {
                    timer.Stop();
                    Messenger.Default.Send("", "prevSongAvailable");

                });
            }
        }

        //plays next song if possible
        public RelayCommand nextSong
        {
            get
            {
                return new RelayCommand(() =>
                {
                    timer.Stop();
                    Messenger.Default.Send("", "nextSongAvailable");
                });
            }
        }

        //Open/close queue window
        public RelayCommand openCloseQueue
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (QueueOpened)
                    {
                        QueueOpened = false;
                    }
                    else
                    {
                        QueueOpened = true;
                    }
                });
            }
        }

        
        //changes the reproduction mode Repeat All/Repeat one/Shuffle
        public RelayCommand changePlayMode
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (selectedPlayModeOption == "rall")
                    {
                        selectedPlayModeOption = "rone";
                    }
                    else if(selectedPlayModeOption == "rone")
                    {
                        selectedPlayModeOption = "shuffle";
                    }
                    else
                    {
                        selectedPlayModeOption = "rall";
                    }
                    Messenger.Default.Send(selectedPlayModeOption, "changePlayMode");
                
                });
            }
        }       

        //changes the reproduction time to the one clicked in slider (should be in code behind probably)
        public RelayCommand<MouseButtonEventArgs> sliderClick
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>((e) =>
                {
                    if (player != null)
                    {
                        player.timeActual = ((Slider)e.Source).Value;
                    }
                        
                });
            }
        }

        //Pause or resume the song
        public RelayCommand pausePlay
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!player.isFinished)
                    {
                        if (isSongPaused)
                        {
                            isSongPaused = false;
                            player.resumeSong();
                        }
                        else
                        {
                            isSongPaused = true;
                            player.pauseSong();
                        }
                    }
                });
            }
        }

        //Mute/Unmute the volume
        public RelayCommand muteUnmuteSong
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (IsVolumeMuted)
                    {
                        IsVolumeMuted = false;
                        player.mute = true;
                    }
                    else
                    {
                        IsVolumeMuted = true;
                        player.mute = false;
                    }
                });
            }
        }


        public PlayerViewModel()
        {
            //creates a delay of 1 second for visual effect on slider
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(tick);

            //receive a song and plays it. 
            Messenger.Default.Register<Song>(this, "playSong", async message =>
            {
                if (message.source == Song.Source.Mp3WithMe)
                {
                    player.playSong(message.uri);
                }
                else
                {
                    player.playSong(await Netease.getInfoSong(message));
                }
                artistName = message.artistName;
                songName = message.songName;
                isSongPaused = false;
                timer.Start();
            });

            //set nextButton enabled/disabled
            Messenger.Default.Register<bool>(this, "nextBtn",  message =>
            {
                isNextBtnEnabled = message;
            });

            //set prevButton enabled/disabled
            Messenger.Default.Register<bool>(this, "prevBtn", message =>
            {
                isPrevBtnEnabled = message;
            });

        }

        //every second this method is executed (only if song is playing)
        private void tick(object sender, EventArgs e)
        {
            //changes song actual time and total time
            if(player.timeActualCad == "" || player.timeActualCad == null)
            {
                actualTimeContent = "00:00";
            }
            else
            {
                actualTimeContent = player.timeActualCad;
            }
            totalTimeContent = player.mediaActual.durationString;

            //change slider values
            sliderMax = (int)player.mediaActual.duration;
            double percentage = (player.timeActual / player.mediaActual.duration);
            sliderContent = (int)(percentage * sliderMax);
           
            //if the player stop playing song, the timer stop executing and check if next song can be played
            if (player.isStopped)
            {
                timer.Stop();
                Messenger.Default.Send("", "nextSongAvailable");
            }
        }
    }
}
