namespace DNS_Practice_App.Abstracts;

public abstract class NavigationalViewModel : ViewModel
{
    private IPage<ViewModel> _currentPage = null!;

    public virtual IPage<ViewModel> CurrentPage
    {
        get => _currentPage;
        set {
            _currentPage = value;
            _currentPage.Display();

            OnPropertyChanged();
        }
    }
}