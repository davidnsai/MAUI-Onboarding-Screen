﻿namespace Onboarding
{
    using Onboarding.Views;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OnboardingScreen();
        }
    }
}