using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core;
using DNS_Practice_App.Core.Extensions;
using DNS_Practice_App.Models;
using DNS_Practice_App.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DNS_Practice_App;

public partial class App : Application
{
    internal static IHost Host { get; private set; } = null!;

    internal static DBConnectionData FirstConnection { get; set; } = null!;
    internal static DBConnectionData SecondConnection { get; set; } = null!;
    
    internal static void SetMainWindow<TWindow> () where TWindow : Window
    {
        Current.MainWindow?.Close();

        Current.MainWindow = Host.Services.GetRequiredService<TWindow>();
        
        Current.MainWindow.Show();
    }

    private void Application_Startup (object sender, StartupEventArgs e)
    {
        Host = ConfigureHosting();

        SetMainWindow<ApplicationWindow>();
    }

    private static IHost ConfigureHosting ()
    {
        var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().ConfigureServices(services => {
            services.AddSingleton<INavigation, Navigation>();
            services.AddSingleton<ApplicationWindow>();

            services.AddRepositorties();
            services.AddViewModels();
            services.AddPages();
        });

        return hostBuilder.Build();
    }
}