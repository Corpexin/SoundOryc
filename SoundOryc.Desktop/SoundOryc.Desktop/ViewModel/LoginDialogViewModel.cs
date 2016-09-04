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
    public class LoginDialogViewModel : ViewModelBase
    {

        private RelayCommand _closeLoginDialog;
        public RelayCommand closeLoginDialog
        {
            get
            {
                return _closeLoginDialog
                       ?? (_closeLoginDialog = new RelayCommand(SendMessage));
            }
        }
        private void SendMessage()
        {
            Messenger.Default.Send(true, "closeLogin");
        }

        public LoginDialogViewModel()
        {

        }

    }
}
