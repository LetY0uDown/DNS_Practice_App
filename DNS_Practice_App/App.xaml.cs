using DNS_Practice_App.Models;
using System.Windows;

namespace DNS_Practice_App;

public partial class App : Application
{
    internal static DBConnectionData FirstConnection { get; set; }
    internal static DBConnectionData SecondConnection { get; set; }
}