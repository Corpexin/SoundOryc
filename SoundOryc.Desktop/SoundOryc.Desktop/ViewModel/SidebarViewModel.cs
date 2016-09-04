using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class SidebarViewModel: ViewModelBase
    {

        private readonly RegisterDialogView _dialogRView = new RegisterDialogView();
        private readonly LoginDialogView _dialogLView = new LoginDialogView();

        private string _dialogResult;
        public string DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (_dialogResult == value)
                {
                    return;
                }
                _dialogResult = value;
                RaisePropertyChanged();
            }
        }


        //
        private RelayCommand _openRegister;
        private RelayCommand _openLogin;

        public RelayCommand openRegister
        {
            get
            {
                return _openRegister
                       ?? (_openRegister = new RelayCommand(ShowRDialog));
            }
        }

        public RelayCommand openLogin
        {
            get
            {
                return _openLogin
                       ?? (_openLogin = new RelayCommand(ShowLDialog));
            }
        }


        //
        private async void ShowRDialog()
        {
            await DialogCoordinator.Instance.ShowMetroDialogAsync(this, _dialogRView);
        }

        private async void ShowLDialog()
        {
            await DialogCoordinator.Instance.ShowMetroDialogAsync(this, _dialogLView);
        }


        //
        private async void ProcessRMessage(string messageContents)
        {
            DialogResult = messageContents;
            await DialogCoordinator.Instance.HideMetroDialogAsync(this, _dialogLView);
        }

        private async void ProcessLMessage(string messageContents)
        {
            DialogResult = messageContents;
            await DialogCoordinator.Instance.HideMetroDialogAsync(this, _dialogRView);
        }


        //
        public SidebarViewModel()
        {
            Messenger.Default.Register<string>(this, ProcessRMessage);
            Messenger.Default.Register<string>(this, ProcessLMessage);
        }



      
    }
}
