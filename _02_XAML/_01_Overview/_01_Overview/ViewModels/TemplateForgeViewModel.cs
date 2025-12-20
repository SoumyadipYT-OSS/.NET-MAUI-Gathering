using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for TemplateForge page demonstrating ControlTemplates.
/// Shows custom control creation with bindable properties and TemplateBinding.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/controltemplate
/// </summary>
public class TemplateForgeViewModel : BaseViewModel
{
    private string _cardTitle = "Welcome Card";
    private string _cardContent = "This is a custom CardView control using ControlTemplate. The template defines the visual structure while properties are bound via TemplateBinding.";
    private string _cardFooter = "Footer Text";
    private Color _cardBorderColor = Colors.Purple;
    private bool _showFooter = true;

    public TemplateForgeViewModel()
    {
        ToggleFooterCommand = new Command(() => ShowFooter = !ShowFooter);
        ChangeBorderColorCommand = new Command<string>(colorName =>
        {
            CardBorderColor = colorName switch
            {
                "Purple" => Colors.Purple,
                "Blue" => Colors.Blue,
                "Green" => Colors.Green,
                "Orange" => Colors.Orange,
                "Red" => Colors.Red,
                _ => Colors.Purple
            };
        });
    }

    public string CardTitle
    {
        get => _cardTitle;
        set => SetProperty(ref _cardTitle, value);
    }

    public string CardContent
    {
        get => _cardContent;
        set => SetProperty(ref _cardContent, value);
    }

    public string CardFooter
    {
        get => _cardFooter;
        set => SetProperty(ref _cardFooter, value);
    }

    public Color CardBorderColor
    {
        get => _cardBorderColor;
        set => SetProperty(ref _cardBorderColor, value);
    }

    public bool ShowFooter
    {
        get => _showFooter;
        set => SetProperty(ref _showFooter, value);
    }

    public List<string> ColorOptions => new() { "Purple", "Blue", "Green", "Orange", "Red" };

    public ICommand ToggleFooterCommand { get; }
    public ICommand ChangeBorderColorCommand { get; }
}
