namespace _04_DataBinding.Views;

public partial class BasicBindingsPage : ContentPage
{
    public BasicBindingsPage()
    {
        InitializeComponent();

        // B) Explicit Source binding - set in code to avoid XAML analyzer issues
        scaleLabel.SetBinding(
            Label.ScaleProperty,
            new Binding("Value", source: scaleSlider));

        // C) Compiled binding using lambda expression
        // The Label is the binding target.
        // The Slider is the binding source.
        // This compiled binding avoids string-based reflection lookups.
        codeBindingLabel.BindingContext = codeBindingSlider;
        codeBindingLabel.SetBinding(Label.RotationProperty, static (Slider s) => s.Value);
    }
}
