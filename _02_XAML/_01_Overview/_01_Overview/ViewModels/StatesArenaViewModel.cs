using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for StatesArena page demonstrating Visual State Manager.
/// Shows Normal, Disabled, Focused, Selected, PointerOver states.
/// Docs: https://learn.microsoft.com/dotnet/maui/user-interface/visual-states
/// </summary>
public class StatesArenaViewModel : BaseViewModel
{
    private bool _isControlEnabled = true;
    private string _selectedState = "Normal";
    private StateItem? _selectedItem;

    public StatesArenaViewModel()
    {
        StateItems = new ObservableCollection<StateItem>
        {
            new("Item 1", "First item with VSM", false),
            new("Item 2", "Second item with VSM", false),
            new("Item 3", "Third item - try selecting", false),
            new("Item 4", "Fourth item with states", false)
        };

        ToggleEnabledCommand = new Command(() => IsControlEnabled = !IsControlEnabled);
        SelectItemCommand = new Command<StateItem>(item =>
        {
            foreach (var stateItem in StateItems)
            {
                stateItem.IsSelected = stateItem == item;
            }
            SelectedItem = item;
        });
    }

    public bool IsControlEnabled
    {
        get => _isControlEnabled;
        set
        {
            if (SetProperty(ref _isControlEnabled, value))
            {
                OnPropertyChanged(nameof(EnabledStatusText));
            }
        }
    }

    public string EnabledStatusText => IsControlEnabled ? "Enabled" : "Disabled";

    public string SelectedState
    {
        get => _selectedState;
        set => SetProperty(ref _selectedState, value);
    }

    public StateItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetProperty(ref _selectedItem, value))
            {
                OnPropertyChanged(nameof(SelectedItemName));
            }
        }
    }

    public string SelectedItemName => SelectedItem?.Title ?? "None selected";

    public ObservableCollection<StateItem> StateItems { get; }

    public List<string> AvailableStates => new()
    {
        "Normal",
        "Disabled",
        "Focused",
        "Selected",
        "PointerOver"
    };

    public ICommand ToggleEnabledCommand { get; }
    public ICommand SelectItemCommand { get; }
}

public class StateItem : BaseViewModel
{
    private bool _isSelected;

    public StateItem(string title, string description, bool isSelected)
    {
        Title = title;
        Description = description;
        IsSelected = isSelected;
    }

    public string Title { get; }
    public string Description { get; }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }
}
