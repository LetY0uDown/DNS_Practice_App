using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DNS_Practice_App.Abstracts;

public abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void Initialize () { }

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
