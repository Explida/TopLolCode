using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class MainWindowViewModel 
    {
        Data _data;

        public MainWindowViewModel()
        {
            CommandSingIN = new Command(SingIN_Executed, CanExecute);

            _data = Data.GetSingleData();
            _data.StartTimer();
        }
        
        public Command CommandSingIN { get; set; }
        public string SingIN_ID
        {
            get { return _singIN_ID; }
            set
            {
                _singIN_ID = value;
            }
        }
        
        private string _singIN_ID = string.Empty;

        private void SingIN_Executed(object param)
        {
            // MessageBox.Show(_btnText);
            Window nextWind = null;
            var t = _data.StartTimer(_singIN_ID);

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
        
        
        private bool CanExecute(object param) { return true; }
    }
}
