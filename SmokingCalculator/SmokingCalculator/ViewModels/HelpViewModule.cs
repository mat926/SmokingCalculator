using SmokingCalculator.Models;
using System;
using System.Collections.Generic;
//using PropertyChanged;
using System.Text;
using System.Collections.ObjectModel;
using SmokingCalculator.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmokingCalculator.ViewModels
{
    //[AddINotifyPropertyChangedInterface]
    public class HelpViewModule : INotifyPropertyChanged
    {
        public ObservableCollection<Boarding> Boardings { get; set; }

        private int _index = 0;
        public String NextButtonText
        {
            get
            {
                if (PositionIndex == Boardings.Count - 1)
                    return "DONE";
                return "NEXT";
            }

        }
        public ICommand NextCommand { get; set; }
        public ICommand SkipCommand { get; set; }
        public int PositionIndex
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChanged(nameof(PositionIndex));
                OnPropertyChanged(nameof(NextButtonText));
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        public HelpViewModule()
        {
            Boardings = new ObservableCollection<Boarding>
            {
                new Boarding()
                {
                    ImagePath="onboarding1.png",
                    Header = "",
                    Content ="Tap the button as soon as you finish smoking.",
                    CarouselItem = new WalkthroughItemPage()
                },
                     new Boarding()
                {
                    ImagePath="onboarding2.png",
                    Header = "",
                    Content ="You can then view your statistics in the Statistics tab",
                    CarouselItem = new WalkthroughItemPage()
                },
                          new Boarding()
                {
                    ImagePath="onboarding3.png",
                    Header = "",
                    Content ="Try to complete all of the achievements!",
                    CarouselItem = new WalkthroughItemPage()
                },
                               new Boarding()
                {
                    ImagePath="onboarding4.png",
                    Header = "",
                    Content ="Have fun!",
                    CarouselItem = new WalkthroughItemPage()
                }
            };

            foreach(var boarding in Boardings)
            {
                boarding.CarouselItem.BindingContext = boarding;
            }

            NextCommand = new Command(Next);
            SkipCommand = new Command(Skip);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Skip(object obj)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void Next(object obj)
        {
          
           if(PositionIndex<Boardings.Count-1)
            {
                PositionIndex++;
            }
            else
            {
                 App.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
