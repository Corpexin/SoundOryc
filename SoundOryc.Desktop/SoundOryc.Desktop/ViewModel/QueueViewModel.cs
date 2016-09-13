using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SoundOryc.Desktop.ViewModel
{
    public class QueueViewModel: ViewModelBase
    {
        public const string songsQueuePropertyName = "songsQueue";
        public ObservableCollection<Song> _songsQueue = new ObservableCollection<Song>();
        ObservableCollection<Song> randomList = new ObservableCollection<Song>();
        public int currentSong=0;
        string playmode = "rall";

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
        
        public RelayCommand<MouseButtonEventArgs> playSong
        {
            get
            {
                return new RelayCommand<MouseButtonEventArgs>((e) =>
                {
                    currentSong = (int)((ListView)e.Source).SelectedIndex;
                    Messenger.Default.Send(songsQueue[currentSong], "playSong");
                    checkNextPrevEnabled();
                });
            }
        }

        public void checkNextPrevEnabled()
        {
            if(currentSong < songsQueue.Count - 1) {
                Messenger.Default.Send(true, "nextBtn");
            }
            else
            {
                Messenger.Default.Send(false, "nextBtn");
            }

            if (currentSong > 0)
            {
                Messenger.Default.Send(true, "prevBtn");
            }
            else
            {
                Messenger.Default.Send(false, "prevBtn");
            }
        }

        public QueueViewModel()
        {
            
            Messenger.Default.Register<string>(this, "nextSongAvailable", message =>
            {
                if(playmode != "rone") //repeat all & shuffle
                {
                    if (currentSong < songsQueue.Count - 1) //if its not the last one
                    {
                        currentSong++;
                       
                    }
                    else 
                    {
                        currentSong = 0;
                    }
                }

                Messenger.Default.Send(songsQueue[currentSong], "playSong");
                checkNextPrevEnabled();


            });


            Messenger.Default.Register<string>(this, "prevSongAvailable", message =>
            {
                if (currentSong > 0) //if its not the first one
                {
                    currentSong--;
                    Messenger.Default.Send(songsQueue[currentSong], "playSong");
                    checkNextPrevEnabled();
                }

            });



            Messenger.Default.Register<List<Song>>(this, "addSongToQueue", message =>
            {
                bool playFirstSong;
                
                if(songsQueue.Count == 0)
                {
                    playFirstSong = true;
                }
                else
                {
                    playFirstSong = false;
                }

                foreach(Song s in message)
                {
                    songsQueue.Add(s);
                }

                if (playFirstSong)
                {
                    currentSong = 0;
                    Messenger.Default.Send(songsQueue[currentSong], "playSong");
                }
                checkNextPrevEnabled();

            });

            Messenger.Default.Register<string>(this, "changePlayMode", message =>
            {
                playmode = message;
                if(playmode == "shuffle")
                {
                    randomList.Clear();
                    foreach (Song s in songsQueue)
                    {
                        randomList.Add(s);
                    }
                    songsQueue.Shuffle();
                }
                else
                {
                    if(randomList.Count > 0)
                    {
                        songsQueue.Clear();
                        foreach (Song s in randomList)
                        {
                            songsQueue.Add(s);
                        }
                    }
                }
            });
        }
    }
}
