using SmokingCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokingCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
       
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void Reset_Tapped(object sender, EventArgs e)
        {
             bool answer = await DisplayAlert("!!!WARNING!!!", @"This will reset all of your records and achievements, all data will be lost.

Are you REALLY sure you want to delete everything?", "Yes", "No");
            if (answer) {

                Preferences.Clear();
                Preferences.Set("StartDate", DateTime.Now);
                Preferences.Set("Longest", TimeSpan.Zero.Ticks);
                await DisplayAlert("", "Please restart the app for changes to take effect", "OK"); 
            }
        }
        private async void Credits_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("", @"Thank you to the translators for their help:

German - Joseph K, Kolla, Max
Russian - Дмитрий
French - Adrien Hagège
Czech - Rijad Zinhasovic
Italian - Walter Lelouch
Dutch - Kiefer R.", "OK");
        }
        private async void Contact_Tapped(object sender, EventArgs e)
        {
            await SendEmail("Smoking Calculator App Feedback", "", new List<string> { "533865a7@opayq.com" });
        }
        private void Volunteer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Contribute", @"This app was developed by just one individual. If you appreciate my work please consider donating. 

I am looking for volunteers who would be interested in contributing the app.
Examples are:  Translators, graphic designers, achievement suggestions, C# Xamarin developers, creating a video trailer for the app, voice artists, etc.

If you are interested, please contact me :) ", "OK");
        }
        public async Task SendEmail(string subject, string body, List<string> recipient)
        {
            try
            {
                const string localFileName = "history.xml";
                string localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipient,
     
                       //Cc = ccRecipients,
                      //Bcc = bccRecipients
                     };
                message.Attachments.Add(new EmailAttachment(localPath));
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }

        private async void Rate_Tapped(object sender, EventArgs e)
        {
            string url = "https://play.google.com/store/apps/details?id=com.smokingcalculator";
            try
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

    }
}