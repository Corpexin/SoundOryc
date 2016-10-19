using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Utilities;
using SoundOryc.Desktop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundOryc.Desktop.ViewModel
{
    public class SidebarViewModel: ViewModelBase
    {


        public const string playlistsListtPropertyName = "playlistsList";
        private ObservableCollection<PlayList> _playlistsList = new ObservableCollection<PlayList>();
        private PlayList contextPlaylistSelected;
        private User user = null;

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


        public PlayList selectedPlaylist;
        


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


        public RelayCommand<PlayList> deletePlayList
        {
            get
            {
                return new RelayCommand<PlayList>(async (e) =>
                {
                    if (e != null && playlistsList.Contains(e))
                    {
                        //local delete
                        playlistsList.Remove(e);

                        //firebase delete
                        if(!await FirebaseC.deletePlaylist(e, user))
                        {
                            Messenger.Default.Send(new String[] {"Cannot delete playlist in the cloud.", "Check your connection." }, "openInfoDialog");
                        }

                        //content delete

                    }
                });
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
            Messenger.Default.Register<PlayList>(this, "loadPlaylist", message =>
            {
                selectedPlaylist = message;
            });

            Messenger.Default.Register<User>(this, "UserLogged", message =>
            {
                user = message;
                //load playlists
                if (message.playLists != null)
                {
                    playlistsList.Clear();
                    foreach (PlayList pl in message.playLists)
                    {
                        playlistsList.Add(pl);
                    }
                }

                //changes visibility of elements in sidebar
                usernameText = message.email;
                registerVisible = false;
                loginVisible = false;
                usernameVisible = true;
                logoutVisible = true;
                lblPlaylistsVisible = true;

                //add playlists into contextMenu.
                //Messenger.Default.Send(true, "resetContextMenu");
                Messenger.Default.Send(playlistsList, "loadPlaylistsContextMenu");

            });

            Messenger.Default.Register<string>(this, "bindPlaylistToContextMenu", message =>
            {
                foreach (PlayList pl in playlistsList)
                {
                    if (pl.namePl == message)
                    {
                        contextPlaylistSelected = pl;
                        Object[] ar = new Object[3];
                        ar[0] = pl;
                        ar[1] = user;
                        ar[2] = 0;
                        Messenger.Default.Send(ar, "saveSongsFirebase");
                    }
                }
            });

            Messenger.Default.Register<Object[]>(this, "addSongsToContextPlaylists", message =>
            {
                List<Song> songL = (List<Song>)message[0];
                List<int> songP = (List<int>)message[1];

                if(songL.Count == songP.Count) //weak check, but should work
                {
                    for (int i = 0; i < songL.Count; i++)
                    {
                        songL[i].numList = null;
                        songL[i].fbCont = songP[i]; //this is the motherf%#@ key for deleting from firebase correctly
                        contextPlaylistSelected.songs.Add(songL[i]);
                    }
                }
                

            });

            Messenger.Default.Register<List<Song>>(this, "deleteSongsFromPlaylist", message =>
            {
                //delete from firebase. SHOULD CALL PROGRESS DIALOG
                List<int> songIndexList = new List<int>();
                foreach(Song s in selectedPlaylist.songs)
                {
                    if (message.Contains(s))
                    {
                        songIndexList.Add(s.fbCont);
                    }
                }

                deleteSongsFromFirebase(selectedPlaylist, songIndexList, message);

                
            });


            Messenger.Default.Register<Object[]>(this, "checkIfPlaylistExists", message =>
            {
                bool same = false;
                //check if the name already exists in the playlists list
                foreach (PlayList pl in playlistsList)
                {
                    if ((string)message[0] == pl.namePl)
                    {
                        same = true;
                    }
                }

                if (same)
                {
                    message[0] = "Name Contains invalid characters. Re-write name";
                    Messenger.Default.Send(message, "openWritePlaylistNameDialog"); //Reopen Dialog
                }
                else
                {
                    //Create local playlist with songs
                    PlayList pl = new PlayList((string)message[0], (List<Song>)message[1]);
                    playlistsList.Add(pl);
                    Object[] msg = new Object[3];
                    msg[0] = pl;
                    msg[1] = user;
                    msg[2] = 1;
                    Messenger.Default.Send(msg, "saveSongsFirebase");
                }
            });

          Messenger.Default.Register<bool>(this, "reloadContextMenu", message =>
          {
              //add playlists into contextMenu.
              Messenger.Default.Send(true, "resetContextMenu");
              Messenger.Default.Send(playlistsList, "loadPlaylistsContextMenu");
          });
        }

        private async void deleteSongsFromFirebase(PlayList playlist, List<int> songIndexList, List<Song> songs)
        {

            bool x = await FirebaseC.deleteSongs(playlist, songIndexList, user);
            if (x)
            {
                //care async
                foreach (Song s in songs)
                {
                    selectedPlaylist.songs.Remove(s);
                }
                //reOrganize Indexes. hacer cuando se obtengan los indices
                //bool y = await FirebaseC.sortSongs(selectedPlaylist, user);


                //if 0 songs, deletes the playlist from lvplaylists
                /** SEND TO CONTENT TO ASK FOR REMAINING SONGS THEN COMEBACK IF ITS LAST SONG AND DELETE PLAYLIST
                if (searchSongList.Count == 0)
                {
                    continu = false;
                    //delete local
                    playLists.Remove(selectedPlaylist);
                    addListToPlaylist();
                    resetContextMenu();
                    loadPlaylistsMenuItems();
                }**/
            }
            else
            {
                //SEND MAIN
                //await this.ShowMessageAsync("", "Ethernet connection lost");
            }

        }
    }
}
