namespace Onboarding.Views;
using Onboarding.ViewModels;

public partial class OnboardingScreen : ContentPage
{
	public OnboardingScreen()
	{
		InitializeComponent();
		BindingContext = new OnboardingViewModel();
	}
}