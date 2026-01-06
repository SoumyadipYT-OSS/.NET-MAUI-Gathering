using _04_DataBinding.Converters;

namespace _04_DataBinding.Views;

public partial class ConvertersPage : ContentPage
{
    public ConvertersPage()
    {
        InitializeComponent();

        // A) Enable Button based on Entry.Text.Length
        // We set up the binding in code to avoid XAML analyzer issues with Text.Length path.
        var intToBoolConverter = new IntToBoolConverter();
        searchButton.SetBinding(
            Button.IsEnabledProperty,
            new Binding("Text.Length", source: searchEntry, converter: intToBoolConverter));

        // B) Invert a boolean
        toggledLabel.SetBinding(
            Label.TextProperty,
            new Binding("IsToggled", source: toggle, stringFormat: "IsToggled: {0}"));

        var invertConverter = new InverterConverter();
        invertedLabel.SetBinding(
            Label.TextProperty,
            new Binding("IsToggled", source: toggle, converter: invertConverter, stringFormat: "Inverted: {0}"));
    }
}
