using GalaSoft.MvvmLight;

namespace SoundOryc.Desktop.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        //PROPIEDAD BASE LIMPIA!
        public const string MyPropertyPropertyName = "MyProperty"; //CAMBIAR ESTO SI SE CAMBIA  public bool MyProperty

        private bool _myProperty = false;

        public bool MyProperty
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
                RaisePropertyChanged(MyPropertyPropertyName);
            }
        }

        
        public MainViewModel()
        {

        }
    }
}