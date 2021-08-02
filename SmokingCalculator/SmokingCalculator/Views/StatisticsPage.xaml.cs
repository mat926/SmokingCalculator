using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmokingCalculator.ViewModels;
using Xamarin.Essentials;

namespace SmokingCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsViewModule Model { get; set; }
        public StatisticsPage()
        {
            InitializeComponent();
            Model = new StatisticsViewModule
            {

                Total = Preferences.Get("Total", 0),   //add this line
                LastTime = Preferences.Get("LastTime", DateTime.MinValue),
                Longest = TimeSpan.FromTicks(Preferences.Get("Longest", TimeSpan.Zero.Ticks)),
                TimeWasted = TimeSpan.FromTicks(Preferences.Get("TimeWasted", TimeSpan.Zero.Ticks))
            };
            this.BindingContext = Model;
        }

      


    }
}