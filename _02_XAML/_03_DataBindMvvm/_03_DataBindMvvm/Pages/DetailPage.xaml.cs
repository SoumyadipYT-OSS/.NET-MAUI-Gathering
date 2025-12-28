using _03_DataBindMvvm.Helpers;
using _03_DataBindMvvm.Models;
using _03_DataBindMvvm.ViewModels;

namespace _03_DataBindMvvm.Pages;

[QueryProperty(nameof(FirstName), nameof(FirstName))]
[QueryProperty(nameof(LastName), nameof(LastName))]
[QueryProperty(nameof(Age), nameof(Age))]
public partial class DetailPage : ContentPage
{
    private readonly DetailViewModel _viewModel;

    public DetailPage() : this(ServiceHelper.GetRequiredService<DetailViewModel>())
    {
    }

    public DetailPage(DetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            UpdatePersonFromQuery();
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            UpdatePersonFromQuery();
        }
    }

    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            UpdatePersonFromQuery();
        }
    }

    private void UpdatePersonFromQuery()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }

        _viewModel.Person = new Person
        {
            FirstName = FirstName ?? string.Empty,
            LastName = LastName ?? string.Empty,
            Age = Age
        };
    }
}