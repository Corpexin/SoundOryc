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
    public class RegisterDialogViewModel: ViewModelBase
    {
         
        private RelayCommand _closeRegisterDialog;
        public RelayCommand closeRegisterDialog
        {
            get
            {
                return _closeRegisterDialog
                       ?? (_closeRegisterDialog = new RelayCommand(SendMessage));
            }
        }
        private void SendMessage()
        {
            Messenger.Default.Send(true, "closeRegister");
        }

        public RegisterDialogViewModel()
        {

        }
    }
}
