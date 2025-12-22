using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _02_MvvmPattern.Models;

public class FoodProduct : INotifyPropertyChanged
{
    private Guid _id;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _category = string.Empty;
    private decimal _price;
    private string _imagePath = string.Empty;

    public Guid Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string Category
    {
        get => _category;
        set => SetProperty(ref _category, value);
    }

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public string ImagePath
    {
        get => _imagePath;
        set => SetProperty(ref _imagePath, value);
    }

    public FoodProduct()
    {
        _id = Guid.NewGuid();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}