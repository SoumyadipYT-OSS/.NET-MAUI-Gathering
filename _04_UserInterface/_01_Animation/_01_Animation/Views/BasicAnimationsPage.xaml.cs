namespace _01_Animation.Views;

public partial class BasicAnimationsPage : ContentPage
{
    public BasicAnimationsPage()
    {
        InitializeComponent();
        SetStatus("Tap a button to run an animation.");
    }

    private void SetStatus(string message) => StatusLabel.Text = message;

    private async void OnFadeClicked(object? sender, EventArgs e)
    {
        SetStatus("FadeTo animates the Opacity property (0 = transparent, 1 = opaque).\nUsing Easing.CubicInOut for a smooth start/stop.");

        await Target.FadeToAsync(0.1, length: 450, easing: Easing.CubicInOut);
        await Target.FadeToAsync(1.0, length: 450, easing: Easing.CubicInOut);
    }

    private async void OnTranslateClicked(object? sender, EventArgs e)
    {
        SetStatus("TranslateTo animates TranslationX/TranslationY (relative offset in device-independent units).\nWe'll move right/down and then return.");

        await Target.TranslateToAsync(120, 40, length: 500, easing: Easing.SinInOut);
        await Target.TranslateToAsync(0, 0, length: 500, easing: Easing.SinInOut);
    }

    private async void OnScaleClicked(object? sender, EventArgs e)
    {
        SetStatus("ScaleTo animates Scale (1 = original size).\nWe'll overshoot a bit and then settle back.");

        await Target.ScaleToAsync(1.25, length: 350, easing: Easing.CubicOut);
        await Target.ScaleToAsync(1.0, length: 350, easing: Easing.CubicIn);
    }

    private async void OnRotateClicked(object? sender, EventArgs e)
    {
        SetStatus("RotateTo animates Rotation in degrees.\nWe'll rotate 360° and return to 0 so repeated taps look consistent.");

        await Target.RotateToAsync(360, length: 650, easing: Easing.Linear);
        Target.Rotation = 0;
    }

    private async void OnResetClicked(object? sender, EventArgs e)
    {
        // AbortAnimation cancels animations created via the Animation class.
        // For View extension animations, setting properties directly is enough.
        Target.Opacity = 1;
        Target.TranslationX = 0;
        Target.TranslationY = 0;
        Target.Scale = 1;
        Target.Rotation = 0;

        await Target.FadeToAsync(1, 1);
        SetStatus("Reset complete.");
    }
}
