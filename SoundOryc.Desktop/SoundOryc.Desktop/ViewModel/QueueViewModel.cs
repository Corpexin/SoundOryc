using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class QueueViewModel: ViewModelBase
    {
        public const string songsQueuePropertyName = "songsQueue";
        public ObservableCollection<Song> _songsQueue = new ObservableCollection<Song>();

        public ObservableCollection<Song> songsQueue
        {
            get
            {
                return _songsQueue;
            }

            private set
            {
                if (_songsQueue == value)
                {
                    return;
                }

                _songsQueue = value;
                RaisePropertyChanged(songsQueuePropertyName);
            }
        }


        public QueueViewModel()
        {
            Messenger.Default.Register<Song>(this, "addSongToQueue", message =>
            {
                songsQueue.Add(message);
            });
        }
    }
}
