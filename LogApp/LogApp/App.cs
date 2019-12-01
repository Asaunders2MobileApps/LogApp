using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LogApp
{
    public class App : Application
    {
        static LoggingDB database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryBlue", Color.FromHex("42B7B5"));

            var nav = new NavigationPage(new LogListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryBlue"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static LoggingDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new LoggingDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LoggerAppSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtLogId { get; set; }
    }
}