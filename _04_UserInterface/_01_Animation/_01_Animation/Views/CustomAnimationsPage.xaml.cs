namespace _01_Animation.Views;

public partial class CustomAnimationsPage : ContentPage
{
    private readonly RingDrawable _drawable;

    public CustomAnimationsPage()
    {
        InitializeComponent();

        // GraphicsView is a simple way to show a custom-drawn element without extra libraries.
        _drawable = new RingDrawable();
        Ring.Drawable = _drawable;

        SetStatus("Tap Run to animate the ring.");
    }

    private void SetStatus(string message) => Status.Text = message;

    private void OnResetClicked(object? sender, EventArgs e)
    {
        Ring.AbortAnimation("RingProgress");
        _drawable.Progress = 0;
        Ring.Invalidate();
        SetStatus("Reset complete.");
    }

    private void OnRunClicked(object? sender, EventArgs e)
    {
        Ring.AbortAnimation("RingProgress");

        // The Animation class lets you animate an arbitrary value.
        // 1) callback: receives the intermediate value over time
        // 2) start/end: the range of values to animate
        // 3) easing: controls acceleration/deceleration
        var animation = new Animation(
            callback: progress =>
            {
                _drawable.Progress = progress;
                Ring.Invalidate();
            },
            start: 0,
            end: 1,
            easing: Easing.CubicInOut);

        // Commit schedules the animation on the UI thread.
        // - name: allows cancellation via AbortAnimation
        // - length: total duration in ms
        // - finished: optional completion callback
        animation.Commit(
            owner: Ring,
            name: "RingProgress",
            rate: 16,
            length: 1400,
            finished: (v, cancelled) =>
            {
                if (cancelled)
                {
                    SetStatus("Animation cancelled.");
                    return;
                }

                SetStatus("Animation completed.");
            });

        SetStatus("Animating...");
    }

    private sealed class RingDrawable : IDrawable
    {
        public double Progress { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            var centerX = dirtyRect.Center.X;
            var centerY = dirtyRect.Center.Y;
            var radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2f - 10;

            // Background track
            canvas.StrokeColor = Colors.Gray.WithAlpha(0.35f);
            canvas.StrokeSize = 14;
            canvas.DrawCircle(centerX, centerY, radius);

            // Progress arc
            canvas.StrokeColor = Colors.DeepSkyBlue;
            canvas.StrokeLineCap = LineCap.Round;

            // Start at the top (12 o'clock).
            var startAngle = -90f;

            // Ensure 0% = empty and 100% = full.
            // Because the arc sweep is currently inverted for direction, we invert the visual progress too.
            var visualProgress = 1f - (float)Math.Clamp(Progress, 0, 1);

            // We want the progress to advance left-to-right (clockwise around the circle).
            // Using a *negative* sweep and clockwise=false produces consistent clockwise motion here.
            var sweepAngle = (360f * visualProgress);
            var endAngle = startAngle + sweepAngle;

            canvas.DrawArc(
                centerX - radius,
                centerY - radius,
                radius * 2,
                radius * 2,
                startAngle,
                endAngle,
                clockwise: true,
                closed: false);

            // Percentage label
            canvas.FontColor = Colors.Black;
            canvas.FontSize = 24;
            canvas.DrawString($"{(int)(Progress * 100)}%", dirtyRect, HorizontalAlignment.Center, VerticalAlignment.Center);

            canvas.RestoreState();
        }
    }
}