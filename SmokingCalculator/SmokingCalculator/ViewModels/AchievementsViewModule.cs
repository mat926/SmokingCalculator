using SmokingCalculator.Models;
using SmokingCalculator.Views;
//using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmokingCalculator.ViewModels
{ public class AchievementsViewModule// : BaseViewModel
    {
          public ObservableCollection<Achievement> Achievements { get; set; }
        public ICommand OpenSettingsCommand => new Command(OpenSettings);
        public ICommand OpenHelpCommand => new Command(OpenHelp);



        public AchievementsViewModule()
        {
            Achievements = new ObservableCollection<Achievement>();
            LoadAchievements();
            MessagingCenter.Subscribe<Object>(this, "achievement", (o) =>
            {
                //automatically update checkbox for achievement
                Device.BeginInvokeOnMainThread(() => {
                    Achievements.Clear();
                     LoadAchievements();
                });
            });
        }
        void LoadAchievements()
        {
            Achievements.Add(new Achievement
            {
                Title = "Your first breath",
                Subtitle = "Smoke for the first time",
                ImageUrl = "firstsquirt.png",
                Completed = Preferences.Get("FirstStep", false),
                CompletedDate = Preferences.Get("FirstStepDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Not bad",
                Subtitle = "Go 5 days without smoking",
                ImageUrl = "_5days.png",
                Completed = Preferences.Get("5Days", false),
                CompletedDate = Preferences.Get("5DaysDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Getting tough, eh?",
                Subtitle = "Go 14 days without smoking",
                ImageUrl = "_14days.png",
                Completed = Preferences.Get("14Days", false),
                CompletedDate = Preferences.Get("14DaysDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "So I guess it's getting serious",
                Subtitle = "Go 30 days without smoking",
                ImageUrl = "_30days.png",
                Completed = Preferences.Get("30Days", false),
                CompletedDate = Preferences.Get("30DaysDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Think you can handle it?",
                Subtitle = "Go 3 months without smoking",
                ImageUrl = "_3months.png",
                Completed = Preferences.Get("3Months", false),
                CompletedDate = Preferences.Get("3MonthsDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Are you even a human?!",
                Subtitle = "Go 6 months without smoking",
                ImageUrl = "_6months.png",
                Completed = Preferences.Get("6Months", false),
                CompletedDate = Preferences.Get("6MonthsDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Challenge Accepted!",
                Subtitle = "Survive a year without smoking",
                ImageUrl = "_12months.png",
                Completed = Preferences.Get("12Months", false),
                CompletedDate = Preferences.Get("12MonthsDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "And so our adventure begins",
                Subtitle = "Smoke a total of 5 times",
                ImageUrl = "_5times.png",
                Completed = Preferences.Get("5Times", false),
                CompletedDate = Preferences.Get("5TimesDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Are you getting tired now?",
                Subtitle = "Smoke a total of 15 times",
                ImageUrl = "_15times.png",
                Completed = Preferences.Get("15Times", false),
                CompletedDate = Preferences.Get("15TimesDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Getting there",
                Subtitle = "Smoke a total of 50 times",
                ImageUrl = "_50times.png",
                Completed = Preferences.Get("50Times", false),
                CompletedDate = Preferences.Get("50TimesDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "Superman Stamina",
                Subtitle = "Smoke a total of 100 times",
                ImageUrl = "_100times.png",
                Completed = Preferences.Get("100Times", false),
                CompletedDate = Preferences.Get("100TimesDate", DateTime.MinValue)
            }); ;
            Achievements.Add(new Achievement
            {
                Title = "World Champion!",
                Subtitle = "Smoke a total of 1000 times",
                ImageUrl = "_1000times.png",
                Completed = Preferences.Get("1000Times", false),
                CompletedDate = Preferences.Get("1000TimesDate", DateTime.MinValue)
            }); ;
           
        }
        async void OpenSettings()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new SettingsPage()));

        }

        async void OpenHelp()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new HelpPage());

        }
    }
}

