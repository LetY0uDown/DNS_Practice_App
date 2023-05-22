namespace DNS_Practice_App.Abstracts;

public interface INavigation
{
    NavigationalViewModel NavigationalModel { get; set; }

    void DisplayPage<T> () where T : IPage<ViewModel>;
}