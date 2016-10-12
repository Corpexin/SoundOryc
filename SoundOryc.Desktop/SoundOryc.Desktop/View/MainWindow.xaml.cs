using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Utilities;
using SoundOryc.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoundOryc.Desktop.View
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            FirebaseC.loadFirebase();

            Messenger.Default.Register<string[]>(this, "openInfoDialog", async message =>
            {
                await this.ShowMessageAsync(message[0], message[1]);
            });

            Messenger.Default.Register<bool>(this, "resizeWindow", message =>
            {
                if (message)
                {
                    content.Margin = new Thickness(200, 20, 5, 0);
                }
                else
                {
                    content.Margin = new Thickness(20, 20, 5, 0);
                }
            });

            Messenger.Default.Register<List<Song>>(this, "createNew", async message =>
            {
                if (message.Count != 0)
                {
                    bool correct = true;
                    String result = null;
                    String text = "Write a name for your new playlist!";
                    int cont = 0;

                    while (correct)
                    {
                       result = await this.ShowInputAsync(text, ""); //Dialog for name

                       correct = false;
                       if (result == null)
                            {
                                correct = false;
                            }
                            else
                            {
                                if (result.ToString().Contains("/") || result.ToString() == "" || result.ToString() == null)
                                {
                                    correct = true;
                                    if (cont == 0)
                                    {
                                        text = "Name incorrect. " + text;
                                    }
                                    cont++;
                                }
                                else
                                {
                                    //check if the name already exists in the playlists list
                                    foreach (PlayList pl in playLists)
                                    {
                                        if (result.ToString() == pl.namePl)
                                        {
                                            correct = true;
                                            if (cont == 0)
                                            {
                                                text = "Name already exists. " + text;
                                            }
                                            cont++;
                                        }
                                    }
                                }
                            }


                        }


                        if (result != null && !((String)result).Contains("-")) //exceptions here
                        {
                            ObservableCollection<Song> list = new ObservableCollection<Song>();
                            //create playlist in firebase
                            foreach (Song s in lvSongs.SelectedItems)
                            {
                                list.Add(s);
                            }

                            bool x = await firebase.createPlaylist(list, result, user);

                            if (x)
                            {
                                List<Song> lst = new List<Song>();
                                foreach (Song s in lvSongs.SelectedItems)
                                {
                                    s.numList = null;
                                    lst.Add(s);
                                }
                                //add playlist in local
                                playLists.Add(new PlayList(result, lst));
                                addListToPlaylist();

                                resetContextMenu();
                                loadPlaylistsMenuItems();
                            }
                            else
                            {
                                await this.ShowMessageAsync("", "Ethernet connection lost");
                            }

                        }
                    }
                    else
                    {
                        var result2 = await this.ShowMessageAsync("Need to login", "If you want to create a playlist you first need to register and enter with one account.");
                    }

                }

            }
    }
}
