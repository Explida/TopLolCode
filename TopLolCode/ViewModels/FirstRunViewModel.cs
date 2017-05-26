using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class FirstRunViewModel
    {

        private string _parentID = string.Empty;
        private string[] _lang ;
        private Data _data;

        public FirstRunViewModel()
        {
            OK = new Command(OK_Execute, CanExecute);
            _lang = Languages.GetNameLanguages();
        }

        public ICommand OK { get; set; }
        public string ParentID
        {
            get
            {
                return _parentID;
            }
            set
            {
                _parentID = value;
            }
        }
        public string[] Lang {
            get
            {
                return _lang;
            }
            set
            {
                _lang = value;
            }
        }

        private void OK_Execute(object param)
        {
            var days = new ObservableCollection<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday
            };
            _data = Data.GetSingleData();
            _data.BlockKeys = false;
            _data.FullScreen = false;
            _data.SelectedLang = "eng";
            _data.TestMode = true;
            _data.TimedShutdown = 5;
            
            _data.AddRegulations(
                _parentID,
                "Parent",
                DateTime.MinValue, 
                DateTime.MaxValue,
                int.MaxValue,
                days);

            _data.SerializeData();

            NextMainWindow();
        }
        
        private void NextMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            foreach ( var firstRunWindow in Application.Current.Windows)
            {
                if (firstRunWindow is FirstRunWindow)
                    (firstRunWindow as FirstRunWindow).Close();
            }
        }

        private bool CanExecute(object param) { return true; }
    }
}
