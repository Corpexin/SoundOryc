using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Services;
using SoundOryc.Desktop.View;
using System.Collections.ObjectModel;

namespace SoundOryc.Desktop.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public const string IsContentVisiblePropertyName = "isContentVisible";
        public const string IsQOpenedPropertyName = "isQOpened";
        public const string IsSOpenedPropertyName = "isSOpened";
        public const string IsPbRingActivePropertyName = "isPbRingActive";
        private readonly RegisterDialogView _dialogRView = new RegisterDialogView();
        private readonly LoginDialogView _dialogLView = new LoginDialogView();

        private string _dialogResult;
        private bool _isQOpened = false;
        private bool _isSOpened = false;
        private bool _isPbRingActive = false;
        private bool _isContentVisible = false;



        public bool isContentVisible
        {
            get
            {
                return _isContentVisible;
            }

            set
            {
                if (_isContentVisible == value)
                {
                    return;
                }

                _isContentVisible = value;
                RaisePropertyChanged(IsContentVisiblePropertyName);
            }
        }


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



        public bool isPbRingActive
        {
            get
            {
                return _isPbRingActive;
            }

            set
            {
                if (_isPbRingActive == value)
                {
                    return;
                }

                _isPbRingActive = value;
                RaisePropertyChanged(IsPbRingActivePropertyName);
            }
        }
    

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

        private async void ShowLDialog()
        {
            await DialogCoordinator.Instance.ShowMetroDialogAsync(this, _dialogLView);
        }

        private async void ShowRDialog()
        {
            await DialogCoordinator.Instance.ShowMetroDialogAsync(this, _dialogRView);
        }


        //
        private async void ProcessRMessage()
        {
            await DialogCoordinator.Instance.HideMetroDialogAsync(this, _dialogRView);
        }

        private async void ProcessLMessage()
        {
            await DialogCoordinator.Instance.HideMetroDialogAsync(this, _dialogLView);
        }




        public MainViewModel()
        {
            Netease.fillProxies();

            Messenger.Default.Register<bool>(this, "queueOpen", message =>
            {
                isQOpened = message;
            });

            Messenger.Default.Register<bool>(this, "sidebarOpen", message =>
            {
                isSOpened = message;
            });

            Messenger.Default.Register<bool>(this, "openRegister", message =>
            {
                ShowRDialog();
            });

            Messenger.Default.Register<bool>(this, "openLogin", message =>
            {
                ShowLDialog();
            });

            Messenger.Default.Register<bool>(this, "closeRegister", message =>
            {
                ProcessRMessage();
            });

            Messenger.Default.Register<bool>(this, "closeLogin", message =>
            {
                ProcessLMessage();
            });

            Messenger.Default.Register<string>(this, "searchStarted", message =>
            {
                isContentVisible = true;
                isPbRingActive = true;
            });

            Messenger.Default.Register<string>(this, "searchCompleted", message =>
            {
                isContentVisible = false;
                isPbRingActive = false;
            });

        }



    }
}