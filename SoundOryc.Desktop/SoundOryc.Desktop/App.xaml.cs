using MahApps.Metro;
using System;
using System.Windows;

namespace SoundOryc.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        { 
            // add custom accent and theme resource dictionaries
            ThemeManager.AddAccent("CustomAccent1", new Uri("pack://application:,,,/SoundOryc.Desktop;component/View/CustomAccent.xaml"));

            // get the theme from the current application
            AppTheme theme = ThemeManager.DetectAppStyle(Application.Current).Item1;

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent1"), theme);

            base.OnStartup(e);
        }
    }
}
