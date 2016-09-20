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
            Messenger.Default.Register<string[]>(this, "openInfoDialog", async message =>
            {
                await this.ShowMessageAsync(message[0], message[1]);
            });

            Messenger.Default.Register<bool>(this, "resizeWindow", message =>
            {
                if (message)
                {
                    content.Margin = new Thickness(200, 20, 5, 0);
                }
                else
                {
                    content.Margin = new Thickness(20, 20, 5, 0);
                }
            });
        }
    }
}
