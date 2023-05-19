using System.Windows.Controls;

namespace DNS_Practice_App.Core.Base;

public abstract class NavigationalViewModel : ViewModel
{
    private Page _currentPage;

    public Page CurrentPage {
        get => _currentPage;
        set {
            _currentPage = value;
            OnPropertyChanged();
        }
    }
}