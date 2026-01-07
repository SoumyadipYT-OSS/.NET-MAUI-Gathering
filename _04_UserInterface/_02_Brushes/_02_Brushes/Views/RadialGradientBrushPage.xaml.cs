using _02_Brushes.ViewModels;

namespace _02_Brushes.Views;

public partial class RadialGradientBrushPage : ContentPage
{
    readonly RadialGradientViewModel _viewModel;

    public RadialGradientBrushPage(RadialGradientViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        ApplySettings();
    }

    void OnAnyRadialChanged(object? sender, ValueChangedEventArgs e) => ApplySettings();

    void ApplySettings()
    {
        PreviewBrush.Center = new Point(_viewModel.CenterX, _viewModel.CenterY);
        PreviewBrush.Radius = _viewModel.Radius;
    }

    void OnCenterClicked(object? sender, EventArgs e)
    {
        _viewModel.CenterX = 0.5;
        _viewModel.CenterY = 0.5;
        _viewModel.Radius = 0.5;
        ApplySettings();
    }

    void OnTopLeftClicked(object? sender, EventArgs e)
    {
        _viewModel.CenterX = 0;
        _viewModel.CenterY = 0;
        _viewModel.Radius = 0.75;
        ApplySettings();
    }

    void OnBottomRightClicked(object? sender, EventArgs e)
    {
        _viewModel.CenterX = 1;
        _viewModel.CenterY = 1;
        _viewModel.Radius = 0.75;
        ApplySettings();
    }
}
