using System.Collections.ObjectModel;

namespace _01_Animation.ViewModels;

public sealed class HomeViewModel : ViewModelBase
{
    public ObservableCollection<DemoItem> Demos { get; } =
    [
        new DemoItem("Basic animations", "Fade, Translate, Scale, Rotate", Routes.BasicAnimations),
        new DemoItem("Easing functions", "Compare easings side-by-side", Routes.Easing),
        new DemoItem("Custom animations", "Animate arbitrary properties", Routes.CustomAnimations),
    ];
}

public sealed record DemoItem(string Title, string Description, string Route);

public static class Routes
{
    public const string Home = nameof(Home);
    public const string BasicAnimations = nameof(BasicAnimations);
    public const string Easing = nameof(Easing);
    public const string CustomAnimations = nameof(CustomAnimations);
}
