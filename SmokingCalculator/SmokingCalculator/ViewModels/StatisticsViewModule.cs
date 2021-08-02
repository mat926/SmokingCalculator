using SmokingCalculator.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmokingCalculator.ViewModels
{
    public class StatisticsViewModule : INotifyPropertyChanged
    {
        public ICommand Masturbated { protected set; get; }
        public ICommand OpenHistoryCommand => new Command(OpenHistory);
        public ICommand OpenSettingsCommand => new Command(OpenSettings);
        public ICommand OpenHelpCommand => new Command(OpenHelp);


        public event PropertyChangedEventHandler PropertyChanged;

        //  public bool LastIsEmpty { get; set; }

        public int Total
        {

            get => Preferences.Get(nameof(Total), 0);
            set
            {
                MessagingCenter.Subscribe<Object>(this, "total", (o) =>
                {
                    //Total = Preferences.Get(nameof(Total), 0);
                    OnPropertyChanged(nameof(Total));
                });
            }
        }

        public DateTime LastTime
        {
            get => Preferences.Get(nameof(LastTime), DateTime.MinValue);
            set
            {
                MessagingCenter.Subscribe<Object>(this, "lasttime", (o) =>
               {
                   OnPropertyChanged(nameof(LastTime));
                });
            }
        }

        public TimeSpan  Longest
        {
            
           get => TimeSpan.FromTicks(Preferences.Get(nameof(Longest), TimeSpan.Zero.Ticks));

            set
            {
                MessagingCenter.Subscribe<Object>(this, "longest", (o) =>
                {
                    OnPropertyChanged(nameof(Longest));
                });

            }

        }

        public TimeSpan TimeWasted
        {
            get => TimeSpan.FromTicks(Preferences.Get(nameof(TimeWasted), TimeSpan.Zero.Ticks));

            set
            {
                MessagingCenter.Subscribe<Object>(this, "timewasted", (o) =>
                {
                    Console.WriteLine("Changed");
                    OnPropertyChanged(nameof(TimeWasted));
                });

            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public StatisticsViewModule()
        {
            // Total = Preferences.Get(nameof(Total),0);

          
        }


        async void OpenHistory()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HistoryPage()));

        }
        async void OpenSettings()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new SettingsPage()));

        }
        async void OpenHelp()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new HelpPage());

        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }


    }
}
