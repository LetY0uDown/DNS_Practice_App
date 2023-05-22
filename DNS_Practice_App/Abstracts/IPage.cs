namespace DNS_Practice_App.Abstracts;

public interface IPage<out TViewModel> where TViewModel : ViewModel
{
    TViewModel ViewModel { get; }

    void Display ();
}