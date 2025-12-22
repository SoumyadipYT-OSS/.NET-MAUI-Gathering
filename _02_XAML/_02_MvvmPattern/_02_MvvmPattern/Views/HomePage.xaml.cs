using _02_MvvmPattern.Models;
using _02_MvvmPattern.ViewModels;

namespace _02_MvvmPattern.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _viewModel;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private void OnEditSwipeItemInvoked(object? sender, EventArgs e)
    {
        try
        {
            if (sender is SwipeItem swipeItem && swipeItem.BindingContext is FoodProduct product)
            {
                _viewModel.EditProductCommand.Execute(product);
                
                // Find and close the parent SwipeView
                CloseParentSwipeView(swipeItem);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Edit swipe error: {ex.Message}");
        }
    }

    private void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
    {
        try
        {
            if (sender is SwipeItem swipeItem && swipeItem.BindingContext is FoodProduct product)
            {
                _viewModel.DeleteProductCommand.Execute(product);
                
                // Find and close the parent SwipeView
                CloseParentSwipeView(swipeItem);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Delete swipe error: {ex.Message}");
        }
    }

    private static void CloseParentSwipeView(SwipeItem swipeItem)
    {
        try
        {
            // Navigate up the parent chain to find SwipeView
            if (swipeItem.Parent is SwipeItems swipeItems && 
                swipeItems.Parent is SwipeView swipeView)
            {
                swipeView.Close();
            }
        }
        catch
        {
            // Ignore close errors
        }
    }
}