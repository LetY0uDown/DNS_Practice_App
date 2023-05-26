using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core;
using DNS_Practice_App.Core.Extensions;
using DNS_Practice_App.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DNS_Practice_App;

public partial class App : Application
{
    internal static IHost Host { get; private set; } = null!;

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
        var builder = new ConfigurationBuilder()
                          .SetBasePath(@"C:\Users\maksm\source\repos\DNS_Practice_App\DNS_Practice_App")
                          .AddJsonFile("appsettings.json",
                                        optional: false, reloadOnChange: true);

        var config = builder.Build();

        var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().ConfigureServices(services => {
            services.AddSingleton(typeof(IConfiguration), config);
            services.AddSingleton<INavigation, Navigation>();
            services.AddSingleton<ApplicationWindow>();

            services.AddRepositorties();
            services.AddViewModels();
            services.AddPages();
        });

        return hostBuilder.Build();
    }
}