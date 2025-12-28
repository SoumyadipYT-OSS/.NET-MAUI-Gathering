using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using _03_DataBindMvvm.Helpers;
using _03_DataBindMvvm.Models;

namespace _03_DataBindMvvm.ViewModels;

/// <summary>
/// Base viewmodel that implements <see cref="INotifyPropertyChanged"/> for all derived viewmodels.
/// This centralizes change notification logic and keeps individual viewmodels focused on their own state.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises <see cref="PropertyChanged"/> so that data bindings update.
    /// </summary>
    /// <param name="propertyName">Name of the changed property. Automatically supplied by the compiler.</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return;
        }

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Helper to set a backing field and raise change notification when the value changes.
    /// </summary>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

/// <summary>
/// Main viewmodel demonstrating one-way, two-way, command, and collection bindings.
/// Also coordinates navigation to a details page through <see cref="INavigationService"/>.
/// </summary>
public sealed class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    private string _title = "MVVM & Data Binding Demo";
    private string _name = string.Empty;
    private DateTime _currentTime = DateTime.Now;
    private Person? _selectedPerson;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// An <see cref="INavigationService"/> is required so navigation can be requested
    /// without depending directly on Shell or page types.
    /// </summary>
    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

        People = new ObservableCollection<Person>
        {
            new Person { FirstName = "Ada", LastName = "Lovelace", Age = 36 },
            new Person { FirstName = "Alan", LastName = "Turing", Age = 41 },
            new Person { FirstName = "Grace", LastName = "Hopper", Age = 85 }
        };

        RefreshTimeCommand = new DelegateCommand(_ => RefreshTime());
        GreetCommand = new DelegateCommand(_ => Greet(), _ => !string.IsNullOrWhiteSpace(Name));
        NavigateToDetailsCommand = new DelegateCommand(async _ => await NavigateToDetailsAsync(), _ => SelectedPerson is not null);
    }

    /// <summary>
    /// One-way binding target. Typically bound to the page title.
    /// </summary>
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    /// <summary>
    /// Two-way binding target for an <see cref="Microsoft.Maui.Controls.Entry"/>.
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                // Notify command that its CanExecute may have changed when the name changes.
                if (GreetCommand is DelegateCommand greetDelegate)
                {
                    greetDelegate.RaiseCanExecuteChanged();
                }
            }
        }
    }

    /// <summary>
    /// One-way binding target for current time, formatted via converter in XAML.
    /// </summary>
    public DateTime CurrentTime
    {
        get => _currentTime;
        private set => SetProperty(ref _currentTime, value);
    }

    /// <summary>
    /// Collection bound to a <see cref="Microsoft.Maui.Controls.CollectionView"/>.
    /// </summary>
    public ObservableCollection<Person> People { get; }

    /// <summary>
    /// Two-way binding to the selected item in the list. This property is central to the
    /// navigation flow: when the user selects a person in the collection view, the value
    /// here is used to navigate to the detail page.
    /// </summary>
    public Person? SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            if (SetProperty(ref _selectedPerson, value))
            {
                // Update the navigation command's CanExecute when selection changes.
                if (NavigateToDetailsCommand is DelegateCommand navDelegate)
                {
                    navDelegate.RaiseCanExecuteChanged();
                }
            }
        }
    }

    /// <summary>
    /// Command bound to a button to refresh the current time.
    /// Demonstrates command binding.
    /// </summary>
    public ICommand RefreshTimeCommand { get; }

    /// <summary>
    /// Command bound to a button to greet the user.
    /// Can only execute when <see cref="Name"/> is not empty.
    /// </summary>
    public ICommand GreetCommand { get; }

    /// <summary>
    /// Command that navigates to the detail page for the currently selected person.
    /// This demonstrates how a viewmodel can coordinate navigation through an
    /// abstraction while still participating in command bindings.
    /// </summary>
    public ICommand NavigateToDetailsCommand { get; }

    private void RefreshTime()
    {
        CurrentTime = DateTime.Now;
    }

    private void Greet()
    {
        // In a real app this might navigate or show a dialog.
        // Here we just update the title to keep UI logic out of the view.
        Title = $"Hello, {Name}!";
    }

    /// <summary>
    /// Builds the navigation route using the selected person and delegates the actual
    /// navigation to the injected <see cref="INavigationService"/>.
    /// This keeps the viewmodel free of direct Shell or page references.
    /// </summary>
    private async Task NavigateToDetailsAsync()
    {
        if (SelectedPerson is null)
        {
            return;
        }

        var person = SelectedPerson;
        var route = $"DetailPage?FirstName={Uri.EscapeDataString(person.FirstName)}&LastName={Uri.EscapeDataString(person.LastName)}&Age={person.Age}";
        await _navigationService.NavigateToAsync(route);
    }
}

