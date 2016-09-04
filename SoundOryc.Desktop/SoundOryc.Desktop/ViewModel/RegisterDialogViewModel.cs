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
        //hacer que el que lo lance sea el mainwindow??, que la sidebar avise a mainwindow y sea esta el que lo lance.. porque vamos...
        private string _dialogRMessage;
        public string DialogRMessage
        {
            get { return _dialogRMessage; }
            set
            {
                if (_dialogRMessage == value)
                {
                    return;
                }
                _dialogRMessage = value;
                RaisePropertyChanged();
            }
        }




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
            Messenger.Default.Send(DialogRMessage);
        }

        public RegisterDialogViewModel()
        {

        }
    }
}
