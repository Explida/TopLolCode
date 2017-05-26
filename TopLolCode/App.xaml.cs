using System;
using System.Windows;
using TopLolCode.Views;
using TopLolCode.Models;

namespace TopLolCode
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }
        

        [STAThread]
        static void Main()
        {
            var app = new App();
            Window _startWind;
            try
            {
                Data.DeserializeData();
                _startWind = new MainWindow();
            }
            catch (Exception e)
            {
                _startWind = new FirstRunWindow();
            }

            app.Run(_startWind);
            
        }
    }
}
