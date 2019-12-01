using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        #region Xamarin Essentials SMS API
        //uses the Xamarin Essentials API for SMS
        public string Number { get; set; }
        public string SmsMessage { get; set; }

        private async void btnSendSms_Clicked(object sender, EventArgs e)
        {
            List<string> numbers = new List<string>
            {
                txtNumber.Text
            };
            string message =
             "Date: " + Date.Date.ToString("MM-dd-yyyy") + "\r\n" +
                "Odometer Reading: " + Miles.Text + "\r\n" +
                "Price Per Gallon: " + PricePerGallon.Text + "\r\n" +
                "Gallons Bought: " + GallonsBought.Text;
            await SendSms(message, numbers);
        }

        public async Task SendSms(string messageText, List<string> recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                //not supported
            }
            catch (Exception ex)
            {
                //failed
            }
        }
        #endregion
    }
}