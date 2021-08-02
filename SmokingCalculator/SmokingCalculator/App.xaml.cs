using SmokingCalculator.Helpers;
using SmokingCalculator.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokingCalculator
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            if (VersionTracking.IsFirstLaunchEver)
            {
                //Gets a value indicating whether this is the first time this app has ever been launched on this device.
                Preferences.Set("StartDate", DateTime.Now);
                Preferences.Set("Longest", TimeSpan.Zero.Ticks);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    bool answer = await App.Current.MainPage.DisplayAlert("Welcome!", "Would you like to learn how to use the app?", "Yes", "No");

                    if (answer)
                    {
                        //show tutorial
                        await App.Current.MainPage.Navigation.PushModalAsync(new HelpPage());

                    }
                });

            }
            else if (VersionTracking.IsFirstLaunchForCurrentVersion)
            {
                // Display update notification for current version (1.0.0)
            }
            else if (VersionTracking.IsFirstLaunchForCurrentBuild)
            {
                // Display update notification for current build number (2)
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

       
    }
}
