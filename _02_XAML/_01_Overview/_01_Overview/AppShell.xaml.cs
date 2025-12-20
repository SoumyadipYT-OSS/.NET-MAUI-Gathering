using _01_Overview.Pages;

namespace _01_Overview
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for programmatic navigation
            // These routes support GoToAsync("RouteName") or GoToAsync("RouteName?param=value")
            // Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/shell/navigation
            Routing.RegisterRoute("LayoutLab", typeof(LayoutLabPage));
            Routing.RegisterRoute("BindingLab", typeof(BindingLabPage));
            Routing.RegisterRoute("StylesStudio", typeof(StylesStudioPage));
            Routing.RegisterRoute("TemplateForge", typeof(TemplateForgePage));
            Routing.RegisterRoute("TriggerClinic", typeof(TriggerClinicPage));
            Routing.RegisterRoute("StatesArena", typeof(StatesArenaPage));
            Routing.RegisterRoute("ThemeSwitcher", typeof(ThemeSwitcherPage));
        }
    }
}
