using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using _02_MvvmPattern.Models;
using _02_MvvmPattern.Services;

namespace _02_MvvmPattern.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly ProductDataService _productDataService;
    private bool _isBusy;
    private bool _isDeleting;

    public ObservableCollection<FoodProduct> Products => _productDataService.Products;

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public bool IsDeleting
    {
        get => _isDeleting;
        set => SetProperty(ref _isDeleting, value);
    }

    public ICommand NavigateToAddProductCommand { get; }
    public ICommand EditProductCommand { get; }
    public ICommand DeleteProductCommand { get; }

    public HomeViewModel(ProductDataService productDataService)
    {
        _productDataService = productDataService;
        NavigateToAddProductCommand = new Command(async () => await NavigateToAddProductAsync());
        EditProductCommand = new Command<FoodProduct>(async (product) => await EditProductAsync(product));
        DeleteProductCommand = new Command<FoodProduct>(async (product) => await DeleteProductAsync(product));
    }

    private async Task NavigateToAddProductAsync()
    {
        try
        {
            await Shell.Current.GoToAsync("AddProductPage");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
        }
    }

    private async Task EditProductAsync(FoodProduct? product)
    {
        if (product == null)
            return;

        try
        {
            await Shell.Current.GoToAsync($"EditProductPage?productId={product.Id}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
        }
    }

    private async Task DeleteProductAsync(FoodProduct? product)
    {
        if (product == null)
            return;

        try
        {
            var confirm = await Shell.Current.DisplayAlert(
                "Delete Product",
                $"Are you sure you want to delete '{product.Name}'?",
                "Delete",
                "Cancel");

            if (!confirm)
                return;

            IsDeleting = true;

            await Task.Delay(100); // Small delay for UI feedback
            var success = _productDataService.DeleteProduct(product.Id);

            if (!success)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to delete product.", "OK");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Delete error: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", "An error occurred while deleting.", "OK");
        }
        finally
        {
            IsDeleting = false;
        }
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