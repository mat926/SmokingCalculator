using SmokingCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmokingCalculator.Views

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementsPage : ContentPage
    {
        public AchievementsPage()
        {
            InitializeComponent();

            
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAchievement = (e.CurrentSelection.FirstOrDefault() as Achievement);

            if (selectedAchievement == null)
                return;

            string completed;
            if (selectedAchievement.Completed)
                completed = $"Completed at {selectedAchievement.CompletedDate}";
            else
                completed = "Incomplete";

            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.DisplayAlert(selectedAchievement.Title, $"{selectedAchievement.Subtitle}{Environment.NewLine}{Environment.NewLine}{completed}", "OK");
            });

            ((CollectionView)sender).SelectedItem = null;
        }

    }
}