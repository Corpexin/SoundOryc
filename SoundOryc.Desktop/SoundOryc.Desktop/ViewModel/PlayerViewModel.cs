using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;


namespace SoundOryc.Desktop.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        //public RelayCommand SimpleCommand { get; private set; }
        public RelayCommand SimpleCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    QueueOpened = true;
                });
            }
        }

        public const string queueOpenedPropertyName = "QueueOpened";

        private bool _queueOpened = false;


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
                Messenger.Default.Send(QueueOpened, "Hello!");
            }
        }

 

        /**
        public PlayerViewModel()
        {
            QueueOpened = false;
            SimpleCommand = new RelayCommand(() =>
            {
                QueueOpened = true;
            });
        }
    **/
    }
}
