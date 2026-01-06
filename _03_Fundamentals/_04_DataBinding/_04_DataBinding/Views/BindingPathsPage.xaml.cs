using System.Globalization;

namespace _04_DataBinding.Views;

public partial class BindingPathsPage : ContentPage
{
    public BindingPathsPage()
    {
        InitializeComponent();

        // A) Sub-property binding: TimePicker.Time.TotalSeconds
        // We set up the binding in code to avoid XAML analyzer issues with nullable TimeSpan.
        timeLabel.SetBinding(
            Label.TextProperty,
            new Binding("Time.TotalSeconds", source: timePicker, stringFormat: "Total seconds: {0:F0}"));

        // B) Nested properties + indexer
        // CultureInfo.CurrentCulture.DateTimeFormat.DayNames[3]
        cultureLabel.Text = $"DayNames[3] for current culture: {CultureInfo.CurrentCulture.DateTimeFormat.DayNames[3]}";

        var frenchCulture = new CultureInfo("fr-FR");
        frenchCultureLabel.Text = $"DayNames[3] for fr-FR: {frenchCulture.DateTimeFormat.DayNames[3]}";

        // C) Path into another control
        // Bind echoLabel.Text to textEntry.Text
        echoLabel.SetBinding(
            Label.TextProperty,
            new Binding("Text", source: textEntry, stringFormat: "Echo: {0}"));

        // Bind to echoLabel.Text.Length
        echoLengthLabel.SetBinding(
            Label.TextProperty,
            new Binding("Text.Length", source: echoLabel, stringFormat: "Echo length: {0}"));
    }
}
