namespace _02_Brushes.Behaviors;

public sealed class RadialGradientSettingsBehavior : Behavior<RadialGradientBrush>
{
    public static readonly BindableProperty CenterXProperty = BindableProperty.Create(
        nameof(CenterX), typeof(double), typeof(RadialGradientSettingsBehavior), 0.5d,
        propertyChanged: (_, __, ___) => ((RadialGradientSettingsBehavior)_).Apply());

    public static readonly BindableProperty CenterYProperty = BindableProperty.Create(
        nameof(CenterY), typeof(double), typeof(RadialGradientSettingsBehavior), 0.5d,
        propertyChanged: (_, __, ___) => ((RadialGradientSettingsBehavior)_).Apply());

    public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
        nameof(Radius), typeof(double), typeof(RadialGradientSettingsBehavior), 0.5d,
        propertyChanged: (_, __, ___) => ((RadialGradientSettingsBehavior)_).Apply());

    RadialGradientBrush? _brush;

    public double CenterX { get => (double)GetValue(CenterXProperty); set => SetValue(CenterXProperty, value); }
    public double CenterY { get => (double)GetValue(CenterYProperty); set => SetValue(CenterYProperty, value); }
    public double Radius { get => (double)GetValue(RadiusProperty); set => SetValue(RadiusProperty, value); }

    protected override void OnAttachedTo(RadialGradientBrush bindable)
    {
        base.OnAttachedTo(bindable);
        _brush = bindable;
        Apply();
    }

    protected override void OnDetachingFrom(RadialGradientBrush bindable)
    {
        _brush = null;
        base.OnDetachingFrom(bindable);
    }

    void Apply()
    {
        if (_brush is null)
            return;

        _brush.Center = new Point(Clamp01(CenterX), Clamp01(CenterY));
        _brush.Radius = Clamp01(Radius);
    }

    static double Clamp01(double v) => v switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => v
    };
}
