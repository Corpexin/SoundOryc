using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class SidebarViewModel: ViewModelBase
    {

       


        //
        private RelayCommand _openRegister;
        private RelayCommand _openLogin;

        public RelayCommand openRegister
        {
            get
            {
                return _openRegister
                       ?? (_openRegister = new RelayCommand(ShowRDialog));
            }
        }

        public RelayCommand openLogin
        {
            get
            {
                return _openLogin
                       ?? (_openLogin = new RelayCommand(ShowLDialog));
            }
        }


        //
        private  void ShowRDialog()
        {
            Messenger.Default.Send(true, "openRegister");
        }

        private  void ShowLDialog()
        {
            Messenger.Default.Send(true, "openLogin");
        }


        //
        public SidebarViewModel()
        {

        }



      
    }
}
