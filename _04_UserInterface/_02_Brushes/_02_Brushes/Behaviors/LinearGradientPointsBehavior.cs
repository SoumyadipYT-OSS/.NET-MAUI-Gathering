namespace _02_Brushes.Behaviors;

public sealed class LinearGradientPointsBehavior : Behavior<LinearGradientBrush>
{
    public static readonly BindableProperty StartXProperty = BindableProperty.Create(
        nameof(StartX), typeof(double), typeof(LinearGradientPointsBehavior), 0d,
        propertyChanged: (_, __, ___) => ((LinearGradientPointsBehavior)_).Apply());

    public static readonly BindableProperty StartYProperty = BindableProperty.Create(
        nameof(StartY), typeof(double), typeof(LinearGradientPointsBehavior), 0d,
        propertyChanged: (_, __, ___) => ((LinearGradientPointsBehavior)_).Apply());

    public static readonly BindableProperty EndXProperty = BindableProperty.Create(
        nameof(EndX), typeof(double), typeof(LinearGradientPointsBehavior), 1d,
        propertyChanged: (_, __, ___) => ((LinearGradientPointsBehavior)_).Apply());

    public static readonly BindableProperty EndYProperty = BindableProperty.Create(
        nameof(EndY), typeof(double), typeof(LinearGradientPointsBehavior), 1d,
        propertyChanged: (_, __, ___) => ((LinearGradientPointsBehavior)_).Apply());

    LinearGradientBrush? _brush;

    public double StartX { get => (double)GetValue(StartXProperty); set => SetValue(StartXProperty, value); }
    public double StartY { get => (double)GetValue(StartYProperty); set => SetValue(StartYProperty, value); }
    public double EndX { get => (double)GetValue(EndXProperty); set => SetValue(EndXProperty, value); }
    public double EndY { get => (double)GetValue(EndYProperty); set => SetValue(EndYProperty, value); }

    protected override void OnAttachedTo(LinearGradientBrush bindable)
    {
        base.OnAttachedTo(bindable);
        _brush = bindable;
        Apply();
    }

    protected override void OnDetachingFrom(LinearGradientBrush bindable)
    {
        _brush = null;
        base.OnDetachingFrom(bindable);
    }

    void Apply()
    {
        if (_brush is null)
            return;

        _brush.StartPoint = new Point(Clamp01(StartX), Clamp01(StartY));
        _brush.EndPoint = new Point(Clamp01(EndX), Clamp01(EndY));
    }

    static double Clamp01(double v) => v switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => v
    };
}
