using Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Onboarding.ViewModels
{
    public class OnboardingViewModel : BaseViewModel
    {
            #region Properties

            private string _buttonText = "Next";
            public string ButtonText
            {
                get => _buttonText;
                set => SetProperty(ref _buttonText, value);
            }

            private int _position;
            public int Position
            {
                get => _position;
                set => SetProperty(ref _position, value, onChanged: (() =>
                {
                    if (value == IntroScreens.Count - 1)
                    {
                        ButtonText = "Get Started!";
                    }
                    else
                    {
                        ButtonText = "Next";
                    }
                }));
            }

            public ObservableCollection<OnBoardingModel> IntroScreens { get; set; } = new ObservableCollection<OnBoardingModel>();
            #endregion


            public OnboardingViewModel()
            {
                var _onboarded = Preferences.Default.Get("Onboarded",false);

                if(_onboarded)
                {
                    Application.Current.MainPage = new AppShell();
                }

                IntroScreens.Add(new OnBoardingModel
                {
                    IntroTitle = "Welcome to My App!",
                    IntroDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ut odio nec purus ultricies lacinia.",
                    IntroImage = "hello"
                });

                IntroScreens.Add(new OnBoardingModel
                {
                    IntroTitle = "Stay in Control!",
                    IntroDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ut odio nec purus ultricies lacinia.",
                    IntroImage = "graphs"
                });

                IntroScreens.Add(new OnBoardingModel
                {
                    IntroTitle = "Get Started!",
                    IntroDescription = "Click the button below to start using Begin!",
                    IntroImage = "rocket"
                });
            }



            public ICommand NextCommand => new Command(() =>
            {
                if (Position >= IntroScreens.Count - 1)
                {
                    Preferences.Default.Set("Onboarded", true);
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    Position += 1;
                }
            });
        }
}
