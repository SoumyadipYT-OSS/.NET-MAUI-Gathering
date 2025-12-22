using System.Collections.ObjectModel;
using System.Text.Json;
using _02_MvvmPattern.Models;
using System.IO;

namespace _02_MvvmPattern.Services;

public class ProductDataService
{
    private static readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");
    
    public ObservableCollection<FoodProduct> Products { get; } = [];

    public ProductDataService()
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var products = JsonSerializer.Deserialize<List<FoodProduct>>(json);
                
                if (products != null && products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        // Ensure existing products without ID get one
                        if (product.Id == Guid.Empty)
                        {
                            product.Id = Guid.NewGuid();
                        }
                        Products.Add(product);
                    }
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading products: {ex.Message}");
        }

        // If no saved products exist, load seed data
        SeedData();
        SaveProducts();
    }

    private void SeedData()
    {
        Products.Add(new FoodProduct
        {
            Name = "Organic Apple",
            Description = "Fresh organic apples from local farms. Sweet and crispy.",
            Category = "Fruits",
            Price = 2.99m,
            ImagePath = "dotnet_bot.png"
        });

        Products.Add(new FoodProduct
        {
            Name = "Fresh Spinach",
            Description = "Nutrient-rich leafy greens, perfect for salads and smoothies.",
            Category = "Vegetables",
            Price = 3.49m,
            ImagePath = "dotnet_bot.png"
        });
    }

    public void AddProduct(FoodProduct product)
    {
        if (product.Id == Guid.Empty)
        {
            product.Id = Guid.NewGuid();
        }
        Products.Add(product);
        SaveProducts();
    }

    public FoodProduct? GetProductById(Guid id)
    {
        return Products.FirstOrDefault(p => p.Id == id);
    }

    public bool UpdateProduct(FoodProduct updatedProduct)
    {
        var existingProduct = Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
        if (existingProduct == null)
            return false;

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Category = updatedProduct.Category;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.ImagePath = updatedProduct.ImagePath;

        SaveProducts();
        return true;
    }

    public bool DeleteProduct(Guid id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return false;

        Products.Remove(product);
        SaveProducts();
        return true;
    }

    public void SaveProducts()
    {
        try
        {
            var json = JsonSerializer.Serialize(Products.ToList(), new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving products: {ex.Message}");
        }
    }
}
