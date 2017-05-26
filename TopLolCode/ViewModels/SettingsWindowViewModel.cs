using System.Windows;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class SettingsWindowViewModel
    {
        private Data _data;

        public int TimedShutdown
        {
            get { return _data.TimedShutdown; }
            set { _data.TimedShutdown = value; }
        }
        public bool TestMode
        {
            get { return _data.TestMode; }
            set { _data.TestMode = value; }
        }
        public bool FullScreen
        {
            get { return _data.FullScreen; }
            set { _data.FullScreen = value; }
        }
        public bool BlockKeys
        {
            get { return _data.BlockKeys; }
            set { _data.BlockKeys = value; }
        }
        public string SelectedLang
        {
            get { return _data.SelectedLang; }
            set { _data.SelectedLang = value; }
        }



        public SettingsWindowViewModel()
        {
            _data = Data.GetSingleData();


        }

        private void SaveSettings(object param)
        {
            _data.SerializeData();
            var window = new ParentWindow();
            window.Show();

            foreach (var firstRunWindow in Application.Current.Windows)
            {
                if (firstRunWindow is SettingsWindow)
                    (firstRunWindow as SettingsWindow).Close();
            }
        }
    }
}
