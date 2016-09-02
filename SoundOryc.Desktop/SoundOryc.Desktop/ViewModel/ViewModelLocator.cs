using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;

namespace SoundOryc.Desktop.ViewModel
{
    public class ViewModelLocator
    {
        //
        private static MainViewModel _main;
        private static PlayerViewModel _player;
        private static NavigationViewModel _nav;
        private static RegisterDialogViewModel _register;
        private static QueueViewModel _queue;
        private static SidebarViewModel _side;

        public ViewModelLocator()
        {
            CreateMain();
            CreatePlayer();
            CreateNav();
            CreateRegister();
            CreateQueue();
            CreateSide();
        }


        //
        public static MainViewModel MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }

        public static PlayerViewModel PlayerStatic
        {
            get
            {
                if (_player == null)
                {
                    CreatePlayer();
                }

                return _player;
            }
        }

        public static NavigationViewModel NavStatic
        {
            get
            {
                if (_nav == null)
                {
                    CreateNav();
                }

                return _nav;
            }
        }

        public static RegisterDialogViewModel RegisterStatic
        {
            get
            {
                if (_register == null)
                {
                    CreateRegister();
                }

                return _register;
            }
        }

        public static QueueViewModel QueueStatic
        {
            get
            {
                if (_queue == null)
                {
                    CreateQueue();
                }

                return _queue;
            }
        }
        public static SidebarViewModel SideStatic
        {
            get
            {
                if (_side == null)
                {
                    CreateSide();
                }

                return _side;
            }
        }
        



        //
        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        public static void CreatePlayer()
        {
            if (_player == null)
            {
                _player = new PlayerViewModel();
            }
        }

        public static void CreateNav()
        {
            if (_nav == null)
            {
                _nav = new NavigationViewModel();
            }
        }

        public static void CreateRegister()
        {
            if (_register == null)
            {
                _register = new RegisterDialogViewModel();
            }
        }

        public static void CreateQueue()
        {
            if (_queue == null)
            {
                _queue = new QueueViewModel();
            }
        }

        public static void CreateSide()
        {
            if (_side == null)
            {
                DialogCoordinator cd = new DialogCoordinator();
                
                _side = new SidebarViewModel();
            }
        }


        //
        [SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return MainStatic;
            }
        }


        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PlayerViewModel Player
        {
            get
            {
                return PlayerStatic;
            }
        }

        [SuppressMessage("Microsoft.Performance",
           "CA1822:MarkMembersAsStatic",
           Justification = "This non-static member is needed for data binding purposes.")]
        public NavigationViewModel Nav
        {
            get
            {
                return NavStatic;
            }
        }

        [SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public RegisterDialogViewModel Register
        {
            get
            {
                return RegisterStatic;
            }
        }

        [SuppressMessage("Microsoft.Performance",
           "CA1822:MarkMembersAsStatic",
           Justification = "This non-static member is needed for data binding purposes.")]
        public QueueViewModel Queue
        {
            get
            {
                return QueueStatic;
            }
        }

        [SuppressMessage("Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes.")]
        public SidebarViewModel Side
        {
            get
            {
                return SideStatic;
            }
        }



        public static void ClearMain()
        {
            _main.Cleanup();
            _main = null;
        }

        public static void ClearPlayer()
        {
            _player.Cleanup();
            _player = null;
        }

        public static void ClearNav()
        {
            _nav.Cleanup();
            _nav = null;
        }

        public static void ClearRegister()
        {
            _register.Cleanup();
            _register = null;
        }

        public static void ClearQueue()
        {
            _queue.Cleanup();
            _queue = null;
        }

        public static void ClearSide()
        {
            _side.Cleanup();
            _side = null;
        }

        public static void Cleanup()
        {
            ClearMain();
            ClearPlayer();
            ClearNav();
            ClearRegister();
            ClearQueue();
            ClearSide();
        }



    }
}