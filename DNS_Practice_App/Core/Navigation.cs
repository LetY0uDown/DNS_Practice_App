using DNS_Practice_App.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace DNS_Practice_App.Core;

internal class Navigation : INavigation
{
    public NavigationalViewModel NavigationalModel { get; set; } = null!;

    public void DisplayPage<T> () where T : IPage<ViewModel>
    {
        var page = App.Host.Services.GetRequiredService<T> ();

        NavigationalModel.CurrentPage = page;
    }
}