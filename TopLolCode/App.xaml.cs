using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
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
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
                
            }
            //if (!File.Exists("Data/Data.xml"))
            //    {

            //    }


            Data data;
            try
            {
                data = Data.DeserializeUserRegulations();
            }
            catch(Exception ex)
            {

                var firstWindow = new FirstRunWindow();
                app.Run(firstWindow);
            }

            var mainWindow = new MainWindow();
            app.Run(mainWindow);
        }
    }
}
