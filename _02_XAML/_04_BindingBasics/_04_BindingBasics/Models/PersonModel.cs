using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _04_BindingBasics.Models;

public class PersonModel : INotifyPropertyChanged
{
    string _name = "MAUI Developer";

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
                return;

            _name = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Greeting));
        }
    }

    public string Greeting => string.IsNullOrWhiteSpace(Name)
        ? "Hello, friend!"
        : $"Hello, {Name}!";

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
