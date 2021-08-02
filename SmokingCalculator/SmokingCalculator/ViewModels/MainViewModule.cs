using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SmokingCalculator.ViewModels;
using SmokingCalculator.Views;
using MarcTron.Plugin;

namespace SmokingCalculator.ViewModels
{
    public class MainViewModule : INotifyPropertyChanged
    {
        public DateTime startdate;
        public TimeSpan span;
        private string _days = "0";
        private string _hours ="0";
        private string _minutes="0";
        public Command MasturbatedCommand { get; set; }
        public ICommand OpenSettingsCommand => new Command(OpenSettings);
        public ICommand OpenHelpCommand => new Command(OpenHelp);



        public string Days
        {
            get { return _days; }
            set
            {
                _days = value;
                OnPropertyChanged(nameof(Days));
            }
        }
        public string Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                OnPropertyChanged(nameof(Hours));
            }
        }
        public string Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                OnPropertyChanged(nameof(Minutes));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //check achievements here
            if (propertyName==nameof(Minutes))
            CheckAchievements();
        }

        public MainViewModule()
        {

            MasturbatedCommand = new Command<DateTime>(_date =>
            {
                _date = DateTime.Now;
                //add your code here
                Masturbated(_date);
            });


            span = DateTime.Now - Preferences.Get("StartDate", DateTime.Now);

            //immediately update the labels at launch

            Days = span.Days.ToString();
            Hours = span.Hours.ToString();
            Minutes = span.Minutes.ToString();

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                span = DateTime.Now - Preferences.Get("StartDate", DateTime.Now);

                // do something every 60 seconds (check achievements)

                Device.BeginInvokeOnMainThread(() =>
                {
                    // interact with UI elements
                    Days = span.Days.ToString();
                    Hours = span.Hours.ToString();
                    Minutes = span.Minutes.ToString();
                });



                return true; // runs again, or false to stop
            });


        }

        public void CheckAchievements()
        {
            bool complete = false;
            
            if (Preferences.Get("Total", 0) >= 1 && !Preferences.Get("FirstStep", false))
            {
                Preferences.Set("FirstStep", true);
                Preferences.Set("FirstStepDate", DateTime.Now);
                 Device.BeginInvokeOnMainThread(async () =>
                 {
                     await App.Current.MainPage.DisplayAlert("Achievement Unlocked - First Step", @"It feels good, huh? That's one of the greatest parts of life. Congratulations on smoking for the first time (if you haven't already).

This makes you one step closer in becoming a real man... or woman. Now you are about to start a great, but a very challenging journey!

It will make you feel great , it could make you feel sick, or it can make you feel uncomfortable, this will be one of the greatest challenges of your life!
Your journey will be to complete all of the achievements listed. Do you think you can handle it, or is it just child's play?", "OK");

                 });

                complete = true;

            }
            if (Preferences.Get("Total", 0) >= 5 && !Preferences.Get("5Times", false))
            {
                Preferences.Set("5Times", true);
                Preferences.Set("5TimesDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - And so our adventure begins", @"Have you really gotten this far? Tell me, how do you feel? Tempted? You must be strong!
You still have lots to go. Don't give up, try to reach 15 times!", "OK");

                });

                complete = true;

            }
            if (Preferences.Get("Total", 0) >= 15 && !Preferences.Get("15Times", false))
            {
                Preferences.Set("15Times", true);
                Preferences.Set("15TimesDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Are you getting tired now?", @"Okay, then maybe you aren't so tired. But most people probably smoked way more times than you! Great job!", "OK");

                });
                complete = true;
            }
            if (Preferences.Get("Total", 0) >= 50 && !Preferences.Get("50Times", false))
            {
                Preferences.Set("50Times", true);
                Preferences.Set("50TimesDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Getting there", @"Well, not bad little soldier. You are getting your way there.
Here's a fact for you: Did you know smoking a pack of cigarettes each day costs about $1,500 per year -- enough money to buy a new computer or Xbox?
Interesting…", "OK");

                });
                complete = true;
            }
            if (Preferences.Get("Total", 0) >= 100 && !Preferences.Get("100Times", false))
            {
                Preferences.Set("100Times", true);
                Preferences.Set("100TimesDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Superman Stamina", @"100 times eh?  I am not impressed. Because most people can do it that easily.  But congratulations on reaching it this far. You think maybe you can do it ten times more? It's a start!", "OK");

                });
                complete = true;
            }
            if (Preferences.Get("Total", 0) >= 1000 && !Preferences.Get("1000Times", false))
            {
                Preferences.Set("1000Times", true);
                Preferences.Set("1000TimesDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - World Champion!", @"HOLY MOTHER OF JESUS CHRIST!!!!!!!!!!!
Are you serious? Are you ABSOLUTELY serious?  Well well, I declare you, the TRUE champion of Smoking!!! How about a dance, yeah?
Hell, maybe you will get up to 2000!  Very well done.

If you enjoyed this app, be sure to give a review and send me feedback :)", "OK");

                });
                complete = true;
            }
            if (span.Days >= 5 && !Preferences.Get("5Days", false))
            {
                Preferences.Set("5Days", true);
                Preferences.Set("5DaysDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Not bad", @"For a beginner, it isn't bad. Congratulations on getting this far. Unless, you screw it up! But come on, don't give up now! Try to fight that urge! Go for the world record if you can. You can do it. Try getting to 14 days.", "OK");

                });
                complete = true;
            }
            if (span.Days >= 14 && !Preferences.Get("14Days", false))
            {
                Preferences.Set("14Days", true);
                Preferences.Set("14DaysDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Getting tough, eh?", @"Can you feel the burn now?", "OK");

                });
                complete = true;
            }
            if (span.Days >= 30 && !Preferences.Get("30Days", false))
            {
                Preferences.Set("30Days", true);
                Preferences.Set("30DaysDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Getting tough, eh?", @"So, you think you are so tough now? Boy, you got at least 11 months left for the world record. Come on!! Don't let your brain fool you. You are stronger than that. Just. Don't. Rub. That. Dick. (or Clitoris) Learn To control yourself, you got this!", "OK");

                });
                complete = true;
            }
            if (span.Days >= 90 && !Preferences.Get("3Months", false))
            {
                Preferences.Set("3Months", true);
                Preferences.Set("3MonthsDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Think you can handle it?", @"I honestly did not think you would get this far! At least most people wouldn't. Assuming that you didn't cheat. I say to you , sir , keep up the good work! You wanna impress the ladies/men with your achievements?  Then KEEP IT UP!", "OK");

                });
                complete = true;
            }
            if (span.Days >= 183 && !Preferences.Get("6Months", false))
            {
                Preferences.Set("6Months", true);
                Preferences.Set("6MonthsDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Getting tough, eh?", @"There is no way you could last that long. Simply NO WAY!!! You must be one hell of a person.

(Unless you cheated) In that case, I am very disappointed in you.", "OK");

                });
                complete = true;
            }
            if (span.Days >= 365 && !Preferences.Get("12Months", false))
            {
                Preferences.Set("12Months", true);
                Preferences.Set("12MonthsDate", DateTime.Now);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Achievement Unlocked - Challenge Accepted!", @"A year?!?!?!?? You just completed the impossible that almost nobody can do!  Congratulations!! Feel free to smoke all you want now. You think maybe you can smoke 1000 times? Go for it!", "OK");

                });
                complete = true;
            }


            if (complete)
            {
                //show ad
                CrossMTAdmob.Current.ShowInterstitial();
                MessagingCenter.Send<Object>(this, "achievement");//update the achievement checkbox
            }
            if (span.Seconds % 30 == 0) CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-6196363473099538/8458038662");// force load
        }

        async void OpenSettings()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new SettingsPage()));

        }
        async void OpenHelp()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new HelpPage());

        }
        void Masturbated(DateTime dateTime)
        {
            string notes = "";
            Preferences.Set("Total", Preferences.Get("Total", 0)+1);
            MessagingCenter.Send<Object>(this, "total"); //update total counter

             Preferences.Set("LastTime", DateTime.Now);
            MessagingCenter.Send<Object>(this, "lasttime"); //update lasttime counter

            Preferences.Set("TimeWasted", Preferences.Get("TimeWasted", TimeSpan.Zero.Ticks) + (TimeSpan.TicksPerMinute * 11));
            MessagingCenter.Send<Object>(this, "timewasted"); //update timewasted counter


            if (span.Ticks > Preferences.Get("Longest", TimeSpan.Zero.Ticks))
               { 
                    Preferences.Set("Longest", span.Ticks);
                if (Preferences.Get("Total", 0) > 1)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("New record", "Congratulations! You have set a new time record", "OK");
                    });
                    notes += "Set a new record!";
                    CrossMTAdmob.Current.ShowInterstitial(); //show ad
                }
                    //show ad here
                     MessagingCenter.Send<Object>(this, "longest"); //update longest counter
                  }


            //Add to history
            HistoryViewModule h = new HistoryViewModule();
            h.AddEntry(DateTime.Now, "", notes); 

            CheckAchievements();

            Preferences.Set("StartDate", DateTime.Now);

  

            if (Preferences.Get("Facts", false))
            {
                ShowFact();
            }

            if (Preferences.Get("Confirm",false))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("", "Entry saved!", "OK");
                });
            }
            void ShowFact()
            {
                int rndnum = new Random().Next(100);
                switch (rndnum)
                {
                    case 1:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Most teens (about 70%) don't smoke. Plus, if you make it through your teen years without becoming a smoker, chances are you'll never become a smoker.", "OK");
                            });
                            break;
                        }
                    case 10:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "John Adams, 2nd president of U.S, started smoking at the age of 8.", "OK");
                            });
                            break;
                        }
                    case 15:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Teens who smoke cough and wheeze three times more than teens who don't smoke.", "OK");
                            });
                            break;
                        }
                    case 20:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "If a pregnant woman smokes, the chances of her miscarriage are increased.", "OK");
                            });
                            break;
                        }
                    case 25:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Tobacco addicts are most likely to consider quitting the habit on Mondays", "OK");
                            });
                            break;
                        }
                    case 30:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "According to many scientists, a smoker will live 14 year less.", "OK");
                            });
                            break;
                        }
                    case 35:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Smoking decreases your sense of taste and smell, making you enjoy things like flowers and ice cream a little bit less.", "OK");
                            });
                            break;
                        }
                    case 40:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Smoking makes you feel weaker and more tired because it prevents oxygen from reaching your heart.", "OK");
                            });
                            break;
                        }
                    case 45:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Nicotine -- one of the main ingredients in cigarettes -- is a poison.", "OK");
                            });
                            break;
                        }
                    case 50:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Smoking a pack of cigarettes each day costs about $1,500 per year -- enough money to buy a new computer or 3 Xbox.", "OK");
                            });
                            break;
                        }
                    case 55:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Urea, a chemical compound that is a major component in urine, is used to add 'flavor' to cigarettes.", "OK");
                            });
                            break;
                        }
                    case 60:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Men who smoke may have a difficulty maintaining an erection in middle life.", "OK");
                            });
                            break;
                        }
                    case 65:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Smoking makes your hair turn gray faster, a study found.", "OK");
                            });
                            break;
                        }
                    case 70:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Smoking near Apple computers voids the warranty.", "OK");
                            });
                            break;
                        }
                    case 75:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "More than a third of the world's smokers are Chinese.", "OK");
                            });
                            break;
                        }
                    case 80:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "15 billion cigarettes are smoked worldwide every day.", "OK");
                            });
                            break;
                        }
                    case 85:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "It is completely legal for minors to smoke cigarettes in the U.S and parts of Europe. What they can't do it purchase them.", "OK");
                            });
                            break;
                        }
                    case 90:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "Every day, nearly 4000 teens in the U.S smoke their first cigarette, while 1,000 start smoking on a daily basis.", "OK");
                            });
                            break;
                        }
                    case 95:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "About 69% of smokers want to quit completely", "OK");
                            });
                            break;
                        }
                    case 99:
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await App.Current.MainPage.DisplayAlert("Did you know?", "A single cigarette contains over 4,800 chemicals, 69 of which are known to cause cancer", "OK");
                            });
                            break;
                        }

                }

            }
        }
    }
}
