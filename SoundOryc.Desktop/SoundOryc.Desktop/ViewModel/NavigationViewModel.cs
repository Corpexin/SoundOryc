﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoundOryc.Desktop.ViewModel
{
    public class NavigationViewModel: ViewModelBase
    {
        public const string IsSidebarOpenedPropertyName = "isSidebarOpened";
        private bool _isSidebarOpened = false;

        public const string IsEngineSelectionOpenedPropertyName = "isEngineSelectionOpened";
        private bool _isEngineSelectionOpened = false;

        public const string IsNeteaseEngineSelectedPropertyName = "isNeteaseEngineSelected";
        private bool _isNeteaseEngineSelected = true;

        public const string SearchTextPropertyName = "searchText";
        private string _searchText="";



        public string searchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                if (_searchText == value)
                {
                    return;
                }

                _searchText = value;
                RaisePropertyChanged(SearchTextPropertyName);
            }
        }


        public bool isSidebarOpened
        {
            get
            {
                return _isSidebarOpened;
            }

            set
            {
                if (_isSidebarOpened == value)
                {
                    return;
                }

                _isSidebarOpened = value;
                RaisePropertyChanged(IsSidebarOpenedPropertyName);
                Messenger.Default.Send(isSidebarOpened, "sidebarOpen");
            }
        }
        

        public bool isEngineSelectionOpened
        {
            get
            {
                return _isEngineSelectionOpened;
            }

            set
            {
                if (_isEngineSelectionOpened == value)
                {
                    return;
                }

                _isEngineSelectionOpened = value;
                RaisePropertyChanged(IsEngineSelectionOpenedPropertyName);                
            }
        }

        public bool isNeteaseEngineSelected
        {
            get
            {
                return _isNeteaseEngineSelected;
            }

            set
            {
                if (_isNeteaseEngineSelected == value)
                {
                    return;
                }

                _isNeteaseEngineSelected = value;
                RaisePropertyChanged(IsNeteaseEngineSelectedPropertyName);
            }
        }




        public RelayCommand openCloseSidebar
        {
            get
            {
                return new RelayCommand(() =>
                {
                    resizeWindow();
                });
            }
        }

        private void resizeWindow()
        {
            if (isSidebarOpened)
            {
                isSidebarOpened = false;
                Messenger.Default.Send(false, "resizeWindow");
            }
            else
            {
                isSidebarOpened = true;
                Messenger.Default.Send(true, "resizeWindow");
            }
        }

        public RelayCommand openCloseEngineSelection
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (isEngineSelectionOpened)
                    {
                        isEngineSelectionOpened = false;
                    }
                    else
                    {
                        isEngineSelectionOpened = true;
                    }
                });
            }
        }

        public RelayCommand selectedEngineNetease
        {
            get
            {
                return new RelayCommand(() =>
                {
                    isEngineSelectionOpened = false;
                    isNeteaseEngineSelected = true;
                });
            }
        }

        public RelayCommand selectedEngineMp3With
        {
            get
            {
                return new RelayCommand(() =>
                {
                    isEngineSelectionOpened = false;
                    isNeteaseEngineSelected = false;
                });
            }
        }

        public RelayCommand searchContent
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    if (isSidebarOpened)
                    {
                        isSidebarOpened = false;
                        Messenger.Default.Send(false, "resizeWindow");
                        Messenger.Default.Send(true, "showPlaylists");
                    }
                    Messenger.Default.Send("", "searchStarted");
                    Messenger.Default.Send(await Search.search(searchText, isNeteaseEngineSelected, 1, Search.TYPE_SONG), "fillContentList");
                });
            }
        }

        public NavigationViewModel()
        {
           
        }
    }
}
