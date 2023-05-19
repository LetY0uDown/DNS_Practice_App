using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Views.Pages;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class LoginNavigationViewModel : NavigationalViewModel
{
    public LoginNavigationViewModel ()
    {
        Navigation.NavigationModel = this;
        Navigation.DisplayPage<LoginPage>();
    }
}