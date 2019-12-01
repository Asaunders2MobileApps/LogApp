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
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new LogListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
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