using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        Data _data;
        public MainWindowViewModel()
        {
            SingIN = new Command(SingIN_Executed, CanExecute);

            _data = Data.GetSingleData();
            _data.StartTimer();
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
            Window nextWind = null;
            var t = _data.StartTimer(_btnText);

            switch (t)
            {
                case -1: MessageBox.Show("неправильный идентификатор");
                    return;
                case 0: nextWind = new ChildWindow();
                    break;
                case 1: nextWind = new ParentWindow();
                    break;
            }

            nextWind.Show();

            foreach (var mainWindow in Application.Current.Windows)
            {
                if (mainWindow is MainWindow)
                    (mainWindow as MainWindow).Close();
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool CanExecute(object param) { return true; }
    }
}
