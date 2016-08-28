using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SoundOryc.Desktop.ViewModels
{
    class PlayerViewModel
    {

        private ICommand m_openQueueWindow;
        public ICommand openQueueWindow
        {
            get
            {
                return m_openQueueWindow;
            }
            set
            {
                m_openQueueWindow = value;
            }
        }

        public PlayerViewModel()
        {
            openQueueWindow = new RelayCommand(new Action<object>(ShowMessage));
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }



    }
}
