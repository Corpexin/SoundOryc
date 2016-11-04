using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SoundOryc.Desktop.View
{
    public partial class Resources
    {
        //Drag and drop

        private void ListViewItemPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            Object[] obj = new Object[2];
            obj[0] = sender;
            obj[1] = e;
            Messenger.Default.Send(obj, "ItemPreviewMouseMove");
        }

        private void ListViewItemDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Song)) && !e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            if (sender as ListBoxItem == null)
                return;
            Object[] obj = new Object[2];
            obj[0] = sender;
            obj[1] = e;
            Messenger.Default.Send(obj, "ItemDrop");
        }

        private void ListViewItemDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Song)) && !e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
    }
}