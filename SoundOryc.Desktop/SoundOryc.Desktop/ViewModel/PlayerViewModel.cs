using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;


namespace SoundOryc.Desktop.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        public const string queueOpenedPropertyName = "QueueOpened";
        private bool _queueOpened = false;

        
        public const string selectedPlayModeOptionPropertyName = "selectedPlayModeOption";
        private string _selectedPlayModeOption = "rall";


        public const string isVolumeMutedPropertyName = "IsVolumeMuted";
        private bool _isVolumeMuted = true;

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



        public PlayerViewModel()
        {
           
        }
    }
}
