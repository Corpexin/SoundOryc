using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
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
    /// <summary>
    /// Interaction logic for ContentView.xaml
    /// </summary>
    public partial class ContentView : UserControl
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public ContentView()
        {
            InitializeComponent();
            saveMenuItems();

            Messenger.Default.Register<bool>(this, "resetContextMenu", message =>
            {
                resetContextMenu();
            });

            Messenger.Default.Register<ObservableCollection<PlayList>>(this, "loadPlaylistsContextMenu", message =>
            {
                loadPlaylistsContextMenu(message);
            });
        }

        private void saveMenuItems()
        {
            menuItems.Clear();
            ContextMenu ct = (ContextMenu)this.lvSongs.ContextMenu;
            MenuItem[] a = new MenuItem[ct.Items.Count];
            ct.Items.CopyTo(a, 0);

            foreach (MenuItem mItem in a)
            {
                menuItems.Add(mItem);
            }
        }


        //Method for reseting the listview items context menu
        private void resetContextMenu()
        {
            loadDefaultContextMenu();
            MenuItem addPl = (MenuItem)((ContextMenu)this.lvSongs.ContextMenu).Items[1];
            MenuItem cn = (MenuItem)addPl.Items[0];
            addPl.Items.Clear();
            addPl.Items.Add(cn);
        }

        private void loadDefaultContextMenu()
        {
            ContextMenu menuContext = (ContextMenu)this.lvSongs.ContextMenu;
            menuContext.Items.Clear();
            foreach (MenuItem mItem in menuItems)
            {
                menuContext.Items.Add(mItem);
            }
        }

        //load into context menu the playlists loaded from the account
        private void loadPlaylistsContextMenu(ObservableCollection<PlayList> playlists)
        {
            
            if (playlists.Count != 0)
            {
                //MenuItem addPl = (MenuItem)((ContextMenu)((Setter)this.lvSongs.ItemContainerStyle.Setters[4]).Value).Items[1];
                MenuItem addPl = (MenuItem) lvSongs.ContextMenu.Items[1];

                foreach (PlayList pl in playlists)
                {
                    MenuItem it = new MenuItem();
                    it.Header = pl.namePl;
                    it.Click += new RoutedEventHandler(addPlaylist_Click);
                    addPl.Items.Add(it);
                }
            }
        }


        //Handler for adding a song to a playlist
        private  void addPlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (lvSongs.SelectedItems != null)
            {
                Messenger.Default.Send((string)((MenuItem)sender).Header, "bindPlaylistToContextMenu");
            }
        }



    }
}
