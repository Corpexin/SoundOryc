using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SoundOryc.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoundOryc.Desktop.ViewModel
{
    public class RegisterDialogViewModel: ViewModelBase
    {

        public const string emailTextPropertyName = "emailText";
        private string _emailText = "";


        public SecureString securePassword { private get; set; }
        public SecureString reSecurePassword { private get; set; }

        public const string infoTextPropertyName = "infoText";
        private string _infoText = "";


        public string emailText
        {
            get
            {
                return _emailText;
            }

            set
            {
                if (_emailText == value)
                {
                    return;
                }

                _emailText = value;
                RaisePropertyChanged(emailTextPropertyName);
            }
        }


        public string infoText
        {
            get
            {
                return _infoText;
            }

            set
            {
                if (_infoText == value)
                {
                    return;
                }

                _infoText = value;
                RaisePropertyChanged(infoTextPropertyName);
            }
        }







        public RelayCommand closeRegisterDialog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send(true, "closeRegister");
                });
            }
        }



        public RelayCommand registerAcc
        {
            get
            {
                return new RelayCommand(async () =>
                {

                    if (!(emailText == "") && (securePassword.Length != 0) && (reSecurePassword.Length != 0)) //check if textbox are not empty
                    {
                        if (PasswordComparator.IsEqualTo(securePassword, reSecurePassword)) //check if password and retype passwword are the same
                        {

                            if (emailText.Contains("/"))
                            {
                                infoText = "Email contains invalid characters.";
                            }
                            else
                            {
                                bool success = await FirebaseC.createUser(emailText, securePassword);
                                string[] ms = new string[2];
                                if (success)
                                {
                                    infoText = "User created successfully. Write your email (username) and password.";
                                    Messenger.Default.Send(true, "closeRegister");

                                    ms[0] = "Ethernet connection lost";
                                    Messenger.Default.Send(ms, "openInfoDialog");
                                }
                                else
                                {
                                    infoText = "";
                                    ms[0] = "Error. Unable to create account.";
                                    ms[1] = "Possible reasons:\n-Cannot connect to servers\n-Email is already registered\n-Email is not written correctly";
                                    Messenger.Default.Send(ms, "openInfoDialog");
                                }
                            }

                        }
                        else
                        {
                            infoText = "Both password are not the same.";
                        }
                    }
                    else
                    {
                        infoText = "Username or Password are empty.";
                    }

                });
            }
        }

       

        public RegisterDialogViewModel()
        {

        }
    }
}
