using _04_DataBinding.Converters;

namespace _04_DataBinding.Views;

public partial class MultiBindingPage : ContentPage
{
    public MultiBindingPage()
    {
        InitializeComponent();

        // Set up MultiBinding in code to avoid any potential XAML issues
        var multiBinding = new MultiBinding
        {
            Converter = new AllTrueMultiConverter(),
            Bindings =
            {
                new Binding("IsOver16"),
                new Binding("HasPassedTest"),
                new Binding("IsSuspended", converter: new InverterConverter())
            }
        };

        eligibleCheckBox.SetBinding(CheckBox.IsCheckedProperty, multiBinding);
    }
}
