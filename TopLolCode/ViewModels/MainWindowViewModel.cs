using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TopLolCode.Models;

namespace TopLolCode.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            SingIN = new Command(SingIN_Executed, CanExecute);
        }

        
        public ICommand SingIN { get; set; }
        public string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                OnPropertyChanged();
            }
        }

        private string _btnText = string.Empty;

        private void SingIN_Executed(object param)
        {
            // MessageBox.Show(_btnText);
            
        }
        
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool CanExecute(object param) { return true; }
    }
}
