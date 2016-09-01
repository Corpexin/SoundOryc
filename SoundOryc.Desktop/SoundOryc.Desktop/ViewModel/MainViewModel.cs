using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace SoundOryc.Desktop.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public const string IsQOpenedPropertyName = "isQOpened";
        public const string IsSOpenedPropertyName = "isSOpened";

        private bool _isQOpened = false;
        private bool _isSOpened = false;

        public bool isQOpened
        {
            get
            {
                return _isQOpened;
            }

            set
            {
                if (_isQOpened == value)
                {
                    return;
                }

                _isQOpened = value;
                RaisePropertyChanged(IsQOpenedPropertyName);
            }
        }

        public bool isSOpened
        {
            get
            {
                return _isSOpened;
            }

            set
            {
                if (_isSOpened == value)
                {
                    return;
                }

                _isSOpened = value;
                RaisePropertyChanged(IsSOpenedPropertyName);
            }
        }



        public MainViewModel()
        {
            Messenger.Default.Register<bool>(this, "queueOpen", message =>
            {
                isQOpened = message;
            });

            Messenger.Default.Register<bool>(this, "sidebarOpen", message =>
            {
                isSOpened = message;
            });
        }

    }
}