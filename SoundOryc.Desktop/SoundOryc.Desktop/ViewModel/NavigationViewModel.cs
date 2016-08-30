using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class NavigationViewModel: ViewModelBase
    {

        public RelayCommand SimpleCommand2
        {
            get
            {
                return new RelayCommand(() =>
                {
                    isQOpened = true;
                });
            }
        }


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


        public NavigationViewModel()
        {
            Messenger.Default.Register<bool>(this, "Hello!", message =>
            {
                isQOpened = message;
            });
        }
    }
}
