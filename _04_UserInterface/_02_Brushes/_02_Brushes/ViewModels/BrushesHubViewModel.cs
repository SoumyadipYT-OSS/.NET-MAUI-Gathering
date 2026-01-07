using System.Collections.ObjectModel;
using System.Windows.Input;
using _02_Brushes.Models;

namespace _02_Brushes.ViewModels;

public sealed class BrushesHubViewModel : BaseViewModel
{
    public BrushesHubViewModel()
    {
        Title = "Brushes";

        Items =
        [
            new BrushMenuItem
            {
                Title = "SolidColorBrush",
                Description = "Paint with a single color. Used for backgrounds, strokes, and fills.",
                Route = Routes.SolidColorBrush
            },
            new BrushMenuItem
            {
                Title = "Gradient stops (GradientBrush)",
                Description = "Learn how GradientStop Color + Offset define any gradient.",
                Route = Routes.GradientStops
            },
            new BrushMenuItem
            {
                Title = "LinearGradientBrush",
                Description = "Blend colors along a line using StartPoint/EndPoint.",
                Route = Routes.LinearGradient
            },
            new BrushMenuItem
            {
                Title = "RadialGradientBrush",
                Description = "Blend colors from the center of a circle outwards using Center/Radius.",
                Route = Routes.RadialGradient
            }
        ];

        NavigateCommand = new Command<BrushMenuItem>(async (item) =>
        {
            if (item is null)
                return;

            await Shell.Current.GoToAsync(item.Route);
        });
    }

    public ObservableCollection<BrushMenuItem> Items { get; }

    public ICommand NavigateCommand { get; }
}

internal static class Routes
{
    public const string Hub = nameof(Hub);
    public const string SolidColorBrush = nameof(SolidColorBrush);
    public const string GradientStops = nameof(GradientStops);
    public const string LinearGradient = nameof(LinearGradient);
    public const string RadialGradient = nameof(RadialGradient);
}
