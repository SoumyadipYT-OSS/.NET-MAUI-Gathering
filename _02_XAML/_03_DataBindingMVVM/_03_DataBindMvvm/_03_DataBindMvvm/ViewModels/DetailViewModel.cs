using _03_DataBindMvvm.Models;

namespace _03_DataBindMvvm.ViewModels;

/// <summary>
/// Detail viewmodel shows information about a selected <see cref="Person"/>.
/// Demonstrates one-way bindings to model properties.
/// </summary>
public sealed class DetailViewModel : BaseViewModel
{
    private Person? _person;

    public Person? Person
    {
        get => _person;
        set
        {
            if (SetProperty(ref _person, value))
            {
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(AgeDisplay));
            }
        }
    }

    /// <summary>
    /// One-way binding for a calculated full name.
    /// </summary>
    public string FullName => Person is null ? string.Empty : $"{Person.FirstName} {Person.LastName}";

    /// <summary>
    /// One-way binding for a formatted age label.
    /// </summary>
    public string AgeDisplay => Person is null ? string.Empty : $"Age: {Person.Age}";
}
