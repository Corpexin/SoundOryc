using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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

        public ViewModelLocator()
        {
            CreateMain();
            CreatePlayer();
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

        public static void Cleanup()
        {
            ClearMain();
        }


    }
}