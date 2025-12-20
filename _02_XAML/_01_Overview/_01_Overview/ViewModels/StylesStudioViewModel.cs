using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for StylesStudio page demonstrating XAML styles.
/// Shows explicit/implicit styles, style inheritance, and resource scopes.
/// Docs: https://learn.microsoft.com/dotnet/maui/user-interface/styles/xaml
/// </summary>
public class StylesStudioViewModel : BaseViewModel
{
    private string _selectedStyleType = "Implicit";
    private bool _useBasedOnStyle;
    private string _sampleText = "Sample Text for Styling";
    private int _selectedFontSizeIndex;

    public StylesStudioViewModel()
    {
        ToggleStyleInheritanceCommand = new Command(() => UseBasedOnStyle = !UseBasedOnStyle);
    }

    public string SelectedStyleType
    {
        get => _selectedStyleType;
        set => SetProperty(ref _selectedStyleType, value);
    }

    public bool UseBasedOnStyle
    {
        get => _useBasedOnStyle;
        set => SetProperty(ref _useBasedOnStyle, value);
    }

    public string SampleText
    {
        get => _sampleText;
        set => SetProperty(ref _sampleText, value);
    }

    public int SelectedFontSizeIndex
    {
        get => _selectedFontSizeIndex;
        set => SetProperty(ref _selectedFontSizeIndex, value);
    }

    public List<string> StyleTypes => new() { "Implicit", "Explicit", "Inherited" };
    public List<int> FontSizes => new() { 12, 14, 16, 18, 20, 24, 28, 32 };

    public ICommand ToggleStyleInheritanceCommand { get; }

    public string StyleDescription => SelectedStyleType switch
    {
        "Implicit" => "Implicit styles (no x:Key) automatically apply to all controls of the TargetType in scope.",
        "Explicit" => "Explicit styles (with x:Key) must be explicitly referenced via Style=\"{StaticResource StyleKey}\".",
        "Inherited" => "Style inheritance uses BasedOn to create derived styles that extend base style setters.",
        _ => ""
    };
}
