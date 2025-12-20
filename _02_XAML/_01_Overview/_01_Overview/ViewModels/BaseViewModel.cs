using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _01_Overview.ViewModels;

/// <summary>
/// Base ViewModel implementing INotifyPropertyChanged for MVVM pattern.
/// All ViewModels should inherit from this class.
/// Docs: https://learn.microsoft.com/dotnet/maui/xaml/fundamentals/mvvm
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises PropertyChanged event to notify UI of property value changes.
    /// Uses CallerMemberName to automatically get the calling property name.
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Sets the backing field and raises PropertyChanged if the value changed.
    /// Returns true if value was changed, false otherwise.
    /// </summary>
    protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value))
            return false;

        backingField = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
