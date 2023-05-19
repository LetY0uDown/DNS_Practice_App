using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using DNS_Practice_App.Views.Pages;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class LoginPageViewModel : ViewModel
{
    public LoginPageViewModel ()
    {
        LoginCommand = new(o => {
            App.FirstConnection = FirstConnectionData;
            App.SecondConnection = SecondConnectionData;

            bool canConnect = true;

            try {
                var context1 = new DNS_practiceContext_One();

                if (!context1.Database.CanConnect()) {
                    canConnect = false;
                    DangerText_1 = $"Невозможно подключиться к БД {App.FirstConnection.ConnectionString}";
                    OnPropertyChanged(nameof(DangerText_1));
                }

                context1.Dispose();
            }
            catch {
                canConnect = false;
                DangerText_1 = $"Невозможно подключиться к БД {App.FirstConnection.ConnectionString}";
                OnPropertyChanged(nameof(DangerText_1));
            }

            try {
                var context2 = new DNS_practiceContext_Two();

                if (!context2.Database.CanConnect()) {
                    canConnect = false;
                    DangerText_2 = $"Невозможно подключиться к БД {App.SecondConnection.ConnectionString}";
                    OnPropertyChanged(nameof(DangerText_2));
                }

                context2.Dispose();
            }
            catch {
                canConnect = false;
                DangerText_2 = $"Невозможно подключиться к БД {App.SecondConnection.ConnectionString}";
                OnPropertyChanged(nameof(DangerText_2));
            }

            if (canConnect)
                Navigation.DisplayPage<AppNavigationPage>();

        }, b => FirstConnectionData.IsNotEmpty && SecondConnectionData.IsNotEmpty);
    }

    public UICommand LoginCommand { get; private init; }

    public string DangerText_1 { get; private set; }
    public string DangerText_2 { get; private set; }

    public DBConnectionData FirstConnectionData { get; private set; } = new(string.Empty, string.Empty, string.Empty, string.Empty);
    public DBConnectionData SecondConnectionData { get; private set; } = new(string.Empty, string.Empty, string.Empty, string.Empty);
}