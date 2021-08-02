using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmokingCalculator.ViewModels
{
    class SettingsViewModule : INotifyPropertyChanged
    {
        //public ICommand ResetCommand => new Command(Reset);
        //public ICommand ContactCommand => new Command(ContactMe);
        //public ICommand CreditsCommand => new Command(Credits);
        //public ICommand VolunteersCommand => new Command(Volunteer);
        public bool Facts
        {
            get => Preferences.Get(nameof(Facts), false);
            set
            {
                Preferences.Set(nameof(Facts), value);
                OnPropertyChanged(nameof(Facts));
            }
        }

        public bool Confirm
        {
            get => Preferences.Get(nameof(Confirm), false);
            set
            {
                Preferences.Set(nameof(Confirm), value);
                OnPropertyChanged(nameof(Confirm));
            }
        }

        public string VersionString
        {
            get { 
                return "Version " + AppInfo.VersionString; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // void Reset()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await App.Current.MainPage.DisplayAlert("reset", "new record", "OK");
        //    });

       // }
        //void ContactMe()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await App.Current.MainPage.DisplayAlert("reset", "new record", "OK");
        //    });

        //}
        //void Credits()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await App.Current.MainPage.DisplayAlert("reseft", "new record", "OK");
        //    });

        //}
        //void Volunteer()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await App.Current.MainPage.DisplayAlert("reset", "new record", "OK");
        //    });

        //}
    }
}
