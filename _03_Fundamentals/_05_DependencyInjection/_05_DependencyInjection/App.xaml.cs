using Microsoft.Extensions.DependencyInjection;

namespace _05_DependencyInjection
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // In MAUI, the built-in DI container is available via IPlatformApplication.Current.Services.
            // Resolving AppShell here allows the Shell to participate in DI.
            var shell = IPlatformApplication.Current!.Services.GetRequiredService<AppShell>();
            return new Window(shell);
        }
    }
}