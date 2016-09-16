using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Model;
using SoundOryc.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class LoginDialogViewModel : ViewModelBase
    {

        public const string emailLTextPropertyName = "emailLText";
        private string _emailLText = "";

        public SecureString secureLPassword { private get; set; }
        public const string infoLTextPropertyName = "infoLText";
        private string _infoLText = "";



        public string emailLText
        {
            get
            {
                return _emailLText;
            }

            set
            {
                if (_emailLText == value)
                {
                    return;
                }

                _emailLText = value;
                RaisePropertyChanged(emailLTextPropertyName);
            }
        }


        public string infoLText
        {
            get
            {
                return _infoLText;
            }

            set
            {
                if (_infoLText == value)
                {
                    return;
                }

                _infoLText = value;
                RaisePropertyChanged(infoLTextPropertyName);
            }
        }


        public RelayCommand closeLoginDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send(true, "closeLogin");
                });
            }
        }

        public RelayCommand loginAcc
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    if (!(emailLText == "") && (secureLPassword.Length != 0)) //check if textbox are not empty
                    {
                        //WHO THE FUCK CONTROLS THE USER... sidebar?
                        User user = await FirebaseC.login(emailLText, secureLPassword);
                       
                        if (user != null)
                        {
                            Messenger.Default.Send(user, "UserLogged");
                            infoLText = "Logged succsessfully.";
                            Messenger.Default.Send(true, "closeLogin");
                            
                        }
                        else
                        {
                            infoLText = "Email or password are incorrect.";
                        }
                    }
                    else
                    {
                        infoLText = "Email or Password are empty.";
                    }
                });
            }
        }


        public LoginDialogViewModel()
        {

        }

    }
}
