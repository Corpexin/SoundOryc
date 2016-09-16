using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class SidebarViewModel: ViewModelBase
    {


        public const string playlistsListtPropertyName = "playlistsList";
        private ObservableCollection<PlayList> _playlistsList = new ObservableCollection<PlayList>();

        public const string registerVisiblePropertyName = "registerVisible";
        private bool _registerVisible = true;

        public const string loginVisiblePropertyName = "loginVisible";
        private bool _loginVisible = true;

        public const string usernameVisiblePropertyName = "usernameVisible";
        private bool _usernameVisible = false;

        public const string logoutVisiblePropertyName = "logoutVisible";
        private bool _logoutVisible = false;

        public const string lblPlaylistsVisiblePropertyName = "lblPlaylistsVisible";
        private bool _lblPlaylistsVisible = false;

        public const string usernameTextPropertyName = "usernameText";
        private string _usernameText = "";

        


        public bool registerVisible
        {
            get
            {
                return _registerVisible;
            }

            private set
            {
                if (_registerVisible == value)
                {
                    return;
                }

                _registerVisible = value;
                RaisePropertyChanged(registerVisiblePropertyName);
            }
        }

        public bool loginVisible
        {
            get
            {
                return _loginVisible;
            }

            private set
            {
                if (_loginVisible == value)
                {
                    return;
                }

                _loginVisible = value;
                RaisePropertyChanged(loginVisiblePropertyName);
            }
        }

        public bool usernameVisible
        {
            get
            {
                return _usernameVisible;
            }

            private set
            {
                if (_usernameVisible == value)
                {
                    return;
                }

                _usernameVisible = value;
                RaisePropertyChanged(usernameVisiblePropertyName);
            }
        }

        public bool logoutVisible
        {
            get
            {
                return _logoutVisible;
            }

            private set
            {
                if (_logoutVisible == value)
                {
                    return;
                }

                _logoutVisible = value;
                RaisePropertyChanged(logoutVisiblePropertyName);
            }
        }

        public bool lblPlaylistsVisible
        {
            get
            {
                return _lblPlaylistsVisible;
            }

            private set
            {
                if (_lblPlaylistsVisible == value)
                {
                    return;
                }

                _lblPlaylistsVisible = value;
                RaisePropertyChanged(lblPlaylistsVisiblePropertyName);
            }
        }

        public string usernameText
        {
            get
            {
                return _usernameText;
            }

            private set
            {
                if (_usernameText == value)
                {
                    return;
                }

                _usernameText = value;
                RaisePropertyChanged(usernameTextPropertyName);
            }
        }


        public ObservableCollection<PlayList> playlistsList
        {
            get
            {
                return _playlistsList;
            }

            private set
            {
                if (_playlistsList == value)
                {
                    return;
                }

                _playlistsList = value;
                RaisePropertyChanged(playlistsListtPropertyName);
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
        private  void ShowRDialog()
        {
            Messenger.Default.Send(true, "openRegister");
        }

        private  void ShowLDialog()
        {
            Messenger.Default.Send(true, "openLogin");
        }





        //
        public SidebarViewModel()
        {
            Messenger.Default.Register<User>(this, "UserLogged", message =>
            {
                //load playlists
                if (message.playLists != null)
                {
                    playlistsList.Clear();
                    foreach (PlayList pl in message.playLists)
                    {
                        playlistsList.Add(pl);
                    }
                }

                //send to sidebar
                //change button login/register for user name
                usernameText = message.email;
                registerVisible = false;
                loginVisible = false;
                usernameVisible = true;
                logoutVisible = true;
                lblPlaylistsVisible = true;

                //add playlists into contextMenu. NOT YET MY FRIEND. SEND TO CONTENT???
                //resetContextMenu();
                //loadPlaylistsMenuItems();
            });

        }



      
    }
}
