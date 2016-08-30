using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace SoundOryc.Desktop.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public const string IsQOpenedPropertyName = "isQOpened";

        private bool _isQOpened = false;

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


        public MainViewModel()
        {
            Messenger.Default.Register<bool>(this, "Hello!", message =>
            {
                isQOpened = message;
            });
        }

    }
}