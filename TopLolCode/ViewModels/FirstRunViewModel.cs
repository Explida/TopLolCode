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
        public FirstRunViewModel()
        {
            OK = new Command(OK_Execute, CanExecute);
            _lang = Languages.GetNameLanguages();
        }

        public ICommand OK { get; set; }
        public string MainPass
        {
            get
            {
                return _mainPass;
            }
            set
            {
                _mainPass = value;
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

           

            //var w = new MainWindow();
            //w.Show();

            //var t = App.Current.Windows;
            //t[0].Close();
        }

        

        private string _mainPass = string.Empty;
        private string[] _lang ;
        




        private bool CanExecute(object param) { return true; }
    }
}
