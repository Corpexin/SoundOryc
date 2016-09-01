using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;


namespace SoundOryc.Desktop.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
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
                Messenger.Default.Send(QueueOpened, "queueOpen");
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

        public PlayerViewModel()
        {
           
        }
    }
}
