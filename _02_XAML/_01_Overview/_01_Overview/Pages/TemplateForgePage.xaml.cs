using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class TemplateForgePage : ContentPage
{
    public TemplateForgePage()
    {
        InitializeComponent();
        BindingContext = new TemplateForgeViewModel();
    }
}
