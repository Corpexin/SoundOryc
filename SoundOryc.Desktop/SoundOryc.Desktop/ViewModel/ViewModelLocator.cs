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
        private static QueueViewModel _queue;
        private static SidebarViewModel _side;
        private static RegisterDialogViewModel _register;
        private static LoginDialogViewModel _login;
        private static ContentViewModel _content;

        public ViewModelLocator()
        {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IDialogCoordinator, DialogCoordinator>();
            SimpleIoc.Default.Register<RegisterDialogViewModel>();
            SimpleIoc.Default.Register<LoginDialogViewModel>();

            /**
            CreateMain();
            CreatePlayer();
            CreateNav();
            CreateRegister();
            CreateLogin();
            CreateQueue();
            CreateSide();
            **/

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

        public static LoginDialogViewModel LoginStatic
        {
            get
            {
                if (_login == null)
                {
                    CreateLogin();
                }

                return _login;
            }
        }

        public static ContentViewModel ContentStatic
        {
            get
            {
                if (_content == null)
                {
                    CreateContent();
                }

                return _content;
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
                _side = new SidebarViewModel();
            }
        }

        public static void CreateLogin()
        {
            if (_login == null)
            {
                _login = new LoginDialogViewModel();
            }
        }

        public static void CreateContent()
        {
            if(_content == null)
            {
                _content = new ContentViewModel();
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
                return ServiceLocator.Current.GetInstance<MainViewModel>();
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
                return ServiceLocator.Current.GetInstance<RegisterDialogViewModel>();
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

        [SuppressMessage("Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes.")]
        public LoginDialogViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginDialogViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "This non-static member is needed for data binding purposes.")]
        public ContentViewModel Content
        {
            get
            {
                return ContentStatic;
            }
        }



        public static void ClearMain()
        {
            //_main.Cleanup();
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
            //_register.Cleanup();
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

        public static void ClearLogin()
        {
            //_login.Cleanup();
            _login = null;
        }

        public static void ClearContent()
        {
            _content.Cleanup();
            _content = null;
        }

        public static void Cleanup()
        {
            ClearMain();
            ClearPlayer();
            ClearNav();
            ClearRegister();
            ClearQueue();
            ClearSide();
            ClearLogin();
            ClearContent();
        }



    }
}