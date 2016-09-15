using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SoundOryc.Desktop.Utilities;
using SoundOryc.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoundOryc.Desktop.View
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            FirebaseC.loadFirebase();
            Messenger.Default.Register<bool>(this, "openInfoDialog", async message =>
            {
                if (message)
                {
                    await this.ShowMessageAsync("User was created successfully.", "");
                }
                else
                {
                    await this.ShowMessageAsync("Error. Unable to create account.", "Possible reasons:\n-Cannot connect to servers\n-Email is already registered\n-Email is not written correctly");
                }
            });
        }
    }
}
