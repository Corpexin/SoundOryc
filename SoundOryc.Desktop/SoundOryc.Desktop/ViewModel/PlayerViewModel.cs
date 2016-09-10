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
                });
            }
        }

        
        public RelayCommand volumenChange
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (IsVolumeMuted)
                    {
                        IsVolumeMuted = false;
                    }
                    else
                    {
                        IsVolumeMuted = true;
                    }
                });
            }
        }
       

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

        public PlayerViewModel()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(tick);

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
                timer.Start();
            });
           
        }

        private void changeSliderValues()
        {
            
        }

        private void tick(object sender, EventArgs e)
        {
            if(player.timeActualCad == "" || player.timeActualCad == null)
            {
                actualTimeContent = "00:00";
            }
            else
            {
                actualTimeContent = player.timeActualCad;
            }
            totalTimeContent = player.mediaActual.durationString;

            sliderMax = (int)player.mediaActual.duration;
            double percentage = (player.timeActual / player.mediaActual.duration);
            sliderContent = (int)(percentage * sliderMax);
           
            if (player.isStopped)
            {
                timer.Stop();
            }
        }
    }
}
