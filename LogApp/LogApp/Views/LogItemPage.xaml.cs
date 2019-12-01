using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogApp
{
    public partial class LogItemPage : ContentPage
    {
        public LogItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var logItem = (LogItem)BindingContext;
            await App.Database.SaveItemAsync(logItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var logItem = (LogItem)BindingContext;
            await App.Database.DeleteItemAsync(logItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //void OnSpeakClicked(object sender, EventArgs e)
        //{
        //    var logItem = (LogItem)BindingContext;
        //    DependencyService.Get<ITextToSpeech>().Speak(logItem.Name + " " + logItem.Notes);
        //}
    }
}