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

        private readonly RegisterDialogView _dialogView = new RegisterDialogView();

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
        private RelayCommand _openRegister;
        public RelayCommand openRegister
        {
            get
            {
                return _openRegister
                       ?? (_openRegister = new RelayCommand(ShowDialog));
            }
        }
        private async void ShowDialog()
        {
            await DialogCoordinator.Instance.ShowMetroDialogAsync(this, _dialogView);
        }

        private async void ProcessMessage(string messageContents)
        {
            DialogResult = messageContents;
            await DialogCoordinator.Instance.HideMetroDialogAsync(this, _dialogView);
        }


        public SidebarViewModel()
        {

            Messenger.Default.Register<string>(this, ProcessMessage);
        }

    }
}
