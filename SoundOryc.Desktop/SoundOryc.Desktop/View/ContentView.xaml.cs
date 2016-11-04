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
        private Song draggedSong;
        private bool modoPlayList;

        public ContentView()
        {
            InitializeComponent();
            modoPlayList = false;
            saveMenuItems();

            Messenger.Default.Register<bool>(this, "deleteContextMenu", message =>
            {
                loadDefaultContextMenu();
                ((MenuItem)this.lvSongs.ContextMenu.Items[1]).Items.Clear();
                ((MenuItem)this.lvSongs.ContextMenu.Items[1]).Visibility = Visibility.Collapsed;
            });

            Messenger.Default.Register<bool>(this, "resetContextMenu", message =>
            {
                resetContextMenu();
            });

            Messenger.Default.Register<ObservableCollection<PlayList>>(this, "loadPlaylistsContextMenu", message =>
            {
                loadPlaylistsContextMenu(message);
            });



            Messenger.Default.Register<bool>(this, "hidePlaylists", message =>
            {
                ((MenuItem)this.lvSongs.ContextMenu.Items[1]).Visibility = Visibility.Collapsed;
            });

            Messenger.Default.Register<bool>(this, "showPlaylists", message =>
            {
                ((MenuItem)this.lvSongs.ContextMenu.Items[1]).Visibility = Visibility.Visible;
            });

            Messenger.Default.Register<PlayList>(this, "loadPlaylist", message =>
            {
                modoPlayList = true;
            });


            Messenger.Default.Register<string>(this, "searchStarted", message =>
            {
                modoPlayList = false;
            });



            Messenger.Default.Register<Object[]>(this, "ItemPreviewMouseMove", message =>
            {
                object sender = message[0];
                MouseEventArgs e = (MouseEventArgs)message[1];

                var listboxItem = sender as ListBoxItem;
                if (listboxItem == null)
                    return;
                draggedSong = listboxItem.DataContext as Song;

                if (draggedSong == null)
                    return;
                var data = new DataObject();
                data.SetData(draggedSong);
                // provide some data for DnD in other applications (Word, ...)
                //data.SetData(DataFormats.StringFormat, sourceFileData.ToString());
                if (modoPlayList)
                {
                    DragDropEffects effect = DragDrop.DoDragDrop(listboxItem, data, DragDropEffects.Move | DragDropEffects.Copy);
                }


            });


            Messenger.Default.Register<Object[]>(this, "ItemDrop", message =>
            {
                //TODO: LLAMAR A ABRIR DIALOG
                Messenger.Default.Send(true, "loadingContent");
                object sender = message[0];
                DragEventArgs e = (DragEventArgs)message[1];
                var listBoxItem = sender as ListBoxItem;

                var targetFile = listBoxItem.DataContext as Song;
                if (targetFile != null)
                {
                    int targetIndex = lvSongs.Items.IndexOf(targetFile);
                    int sourceIndex = lvSongs.Items.IndexOf(draggedSong);
                    double y = e.GetPosition(listBoxItem).Y;
                    bool insertAfter = y > listBoxItem.ActualHeight / 2;
                    if (insertAfter)
                    {
                        targetIndex++;
                    }
                    if (sourceIndex > targetIndex)
                    {
                        if (sourceIndex != -1)
                        {
                            Messenger.Default.Send(sourceIndex, "removeSongAtIndex");

                        }
                        Object[] obj = new Object[2];
                        obj[0] = targetIndex;
                        obj[1] = draggedSong;
                        Messenger.Default.Send(obj, "insertSongAtIndex");

                    }
                    else
                    {
                        Object[] obj = new Object[2];
                        obj[0] = targetIndex;
                        obj[1] = draggedSong;
                        Messenger.Default.Send(obj, "insertSongAtIndex");

                        if (sourceIndex != -1)
                        {
                            Messenger.Default.Send(sourceIndex, "removeSongAtIndex");
                        }

                    }

                }

                e.Handled = true;
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
                addPl.Visibility = Visibility.Visible;
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
