using _02_Brushes.ViewModels;

namespace _02_Brushes.Views;

public partial class LinearGradientBrushPage : ContentPage
{
    readonly LinearGradientViewModel _viewModel;

    public LinearGradientBrushPage(LinearGradientViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        ApplyPoints();
    }

    void OnAnyPointChanged(object? sender, ValueChangedEventArgs e) => ApplyPoints();

    void ApplyPoints()
    {
        PreviewBrush.StartPoint = new Point(_viewModel.StartX, _viewModel.StartY);
        PreviewBrush.EndPoint = new Point(_viewModel.EndX, _viewModel.EndY);
    }

    void OnHorizontalClicked(object? sender, EventArgs e)
    {
        _viewModel.StartX = 0;
        _viewModel.StartY = 0;
        _viewModel.EndX = 1;
        _viewModel.EndY = 0;
        ApplyPoints();
    }

    void OnVerticalClicked(object? sender, EventArgs e)
    {
        _viewModel.StartX = 0;
        _viewModel.StartY = 0;
        _viewModel.EndX = 0;
        _viewModel.EndY = 1;
        ApplyPoints();
    }

    void OnDiagonalClicked(object? sender, EventArgs e)
    {
        _viewModel.StartX = 0;
        _viewModel.StartY = 0;
        _viewModel.EndX = 1;
        _viewModel.EndY = 1;
        ApplyPoints();
    }

    void OnReverseClicked(object? sender, EventArgs e)
    {
        (_viewModel.StartX, _viewModel.EndX) = (_viewModel.EndX, _viewModel.StartX);
        (_viewModel.StartY, _viewModel.EndY) = (_viewModel.EndY, _viewModel.StartY);
        ApplyPoints();
    }
}
