namespace _01_Animation.Views;

public partial class EasingPage : ContentPage
{
    private readonly IReadOnlyList<(string Name, Easing Easing, string Description)> _items =
    [
        ("Linear", Easing.Linear, "Constant speed."),
        ("SinIn", Easing.SinIn, "Slow start, faster end."),
        ("SinOut", Easing.SinOut, "Fast start, slow end."),
        ("SinInOut", Easing.SinInOut, "Slow start, fast middle, slow end."),
        ("CubicIn", Easing.CubicIn, "Strong acceleration."),
        ("CubicOut", Easing.CubicOut, "Strong deceleration."),
        ("CubicInOut", Easing.CubicInOut, "Acceleration then deceleration."),
        ("BounceOut", Easing.BounceOut, "Bouncy end."),
        ("SpringOut", Easing.SpringOut, "Overshoots and settles."),
    ];

    public EasingPage()
    {
        InitializeComponent();

        EasingPicker.ItemsSource = _items.Select(i => i.Name).ToList();
        EasingPicker.SelectedIndex = 0;
        UpdateDescription();
    }

    private void UpdateDescription()
    {
        if (EasingPicker.SelectedIndex < 0)
            return;

        var chosen = _items[EasingPicker.SelectedIndex];
        EasingDescription.Text = $"Selected: {chosen.Name}. {chosen.Description}";
    }

    private async void OnRunClicked(object? sender, EventArgs e)
    {
        if (EasingPicker.SelectedIndex < 0)
            return;

        UpdateDescription();

        var easing = _items[EasingPicker.SelectedIndex].Easing;

        // TranslateTo with a chosen easing makes the *same* start/end positions
        // feel very different due to the easing curve.
        await Dot.TranslateTo(240, 0, length: 900, easing: easing);
        await Dot.TranslateTo(0, 0, length: 900, easing: easing);
    }

    private void OnResetClicked(object? sender, EventArgs e)
    {
        Dot.TranslationX = 0;
        Dot.TranslationY = 0;
        UpdateDescription();
    }

    private void OnPickerSelectedIndexChanged(object? sender, EventArgs e) => UpdateDescription();

    protected override void OnAppearing()
    {
        base.OnAppearing();
        EasingPicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
    }

    protected override void OnDisappearing()
    {
        EasingPicker.SelectedIndexChanged -= OnPickerSelectedIndexChanged;
        base.OnDisappearing();
    }
}
