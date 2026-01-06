using System.Collections.ObjectModel;
using _04_DataBinding.Models;

namespace _04_DataBinding.ViewModels;

public sealed class RelativeBindingsViewModel : ObservableObject
{
    public ObservableCollection<Person> People { get; } =
    [
        new Person { Name = "Ada", Age = 28 },
        new Person { Name = "Grace", Age = 37 },
        new Person { Name = "Linus", Age = 33 },
    ];

    Person? _selected;

    public Person? Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public Command<Person> SelectPersonCommand { get; }

    public RelativeBindingsViewModel()
    {
        SelectPersonCommand = new Command<Person>(p => Selected = p);
    }
}
