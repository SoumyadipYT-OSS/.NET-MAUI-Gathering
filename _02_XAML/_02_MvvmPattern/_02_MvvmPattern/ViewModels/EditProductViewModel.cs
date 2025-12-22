using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using _02_MvvmPattern.Models;
using _02_MvvmPattern.Services;

namespace _02_MvvmPattern.ViewModels;

[QueryProperty(nameof(ProductId), "productId")]
public class EditProductViewModel : INotifyPropertyChanged
{
    private readonly ProductDataService _productDataService;

    private Guid _productId;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _selectedCategory = string.Empty;
    private string _priceText = string.Empty;
    private string _imagePath = "dotnet_bot.png";
    private bool _isBusy;
    private string _nameError = string.Empty;
    private string _categoryError = string.Empty;
    private string _priceError = string.Empty;

    public string ProductId
    {
        get => _productId.ToString();
        set
        {
            if (Guid.TryParse(value, out var id))
            {
                _productId = id;
                LoadProduct();
            }
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                ValidateName();
                (SaveProductCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value))
            {
                ValidateCategory();
                (SaveProductCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string PriceText
    {
        get => _priceText;
        set
        {
            if (SetProperty(ref _priceText, value))
            {
                ValidatePrice();
                (SaveProductCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string ImagePath
    {
        get => _imagePath;
        set => SetProperty(ref _imagePath, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public string NameError
    {
        get => _nameError;
        set => SetProperty(ref _nameError, value);
    }

    public string CategoryError
    {
        get => _categoryError;
        set => SetProperty(ref _categoryError, value);
    }

    public string PriceError
    {
        get => _priceError;
        set => SetProperty(ref _priceError, value);
    }

    public List<string> Categories { get; } =
    [
        "Fruits",
        "Vegetables",
        "Grains",
        "Proteins",
        "Dairy",
        "Other Beverages"
    ];

    public ICommand SaveProductCommand { get; }
    public ICommand PickImageCommand { get; }
    public ICommand CancelCommand { get; }

    public EditProductViewModel(ProductDataService productDataService)
    {
        _productDataService = productDataService;
        SaveProductCommand = new Command(async () => await SaveProductAsync(), CanSaveProduct);
        PickImageCommand = new Command(async () => await PickImageAsync());
        CancelCommand = new Command(async () => await CancelAsync());
    }

    private void LoadProduct()
    {
        try
        {
            var product = _productDataService.GetProductById(_productId);
            if (product != null)
            {
                Name = product.Name;
                Description = product.Description;
                SelectedCategory = product.Category;
                PriceText = product.Price.ToString("F2");
                ImagePath = product.ImagePath;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Load product error: {ex.Message}");
        }
    }

    private void ValidateName()
    {
        NameError = string.IsNullOrWhiteSpace(Name) ? "Product name is required" : string.Empty;
    }

    private void ValidateCategory()
    {
        CategoryError = string.IsNullOrWhiteSpace(SelectedCategory) ? "Please select a category" : string.Empty;
    }

    private void ValidatePrice()
    {
        if (string.IsNullOrWhiteSpace(PriceText))
        {
            PriceError = "Price is required";
        }
        else if (!decimal.TryParse(PriceText, out var price) || price <= 0)
        {
            PriceError = "Please enter a valid price greater than 0";
        }
        else
        {
            PriceError = string.Empty;
        }
    }

    private bool CanSaveProduct()
    {
        return !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(SelectedCategory) &&
               decimal.TryParse(PriceText, out var price) && price > 0;
    }

    private async Task SaveProductAsync()
    {
        if (!CanSaveProduct())
            return;

        IsBusy = true;

        try
        {
            await Task.Delay(100); // Small delay for UI feedback

            if (!decimal.TryParse(PriceText, out var price))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please enter a valid price.", "OK");
                return;
            }

            var updatedProduct = new FoodProduct
            {
                Id = _productId,
                Name = Name,
                Description = Description,
                Category = SelectedCategory,
                Price = price,
                ImagePath = string.IsNullOrWhiteSpace(ImagePath) ? "dotnet_bot.png" : ImagePath
            };

            var success = _productDataService.UpdateProduct(updatedProduct);

            if (success)
            {
                await Shell.Current.DisplayAlert("Success", $"Product '{Name}' updated successfully!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Failed to update product.", "OK");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Update error: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", "An error occurred while updating.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task PickImageAsync()
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a product image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                ImagePath = result.FullPath;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Image picker error: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"Unable to pick image: {ex.Message}", "OK");
        }
    }

    private async Task CancelAsync()
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
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
