using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class FirstRunViewModel
    {

        private string _parentID = string.Empty;
        private string[] _lang ;


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
            var days = new List<string> { "Friday", "Monday", "Saturday", "Sunday", "Thursday", "Tuesday", "Wednesday" };

            var data = new Data()
            {
                BlockKeys = false,
                FullScreen = false,
                SelectedLang = "eng",
                TestMode = true,
                TimedShutdown = 5
            };
            data.AddRegulations(_parentID, "Parent", DateTime.MinValue, DateTime.MaxValue, int.MaxValue, days);

            data.SerializeUserRegulations();



            var w = new MainWindow();
            w.Show();

            var t = App.Current.Windows;
            t[0].Close();
            t[1].Close();
        }
        
        private bool CanExecute(object param) { return true; }
    }
}
