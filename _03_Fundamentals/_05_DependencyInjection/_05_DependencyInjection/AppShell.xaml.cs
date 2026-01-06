using _05_DependencyInjection.Pages;

namespace _05_DependencyInjection
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Routes are string keys that Shell uses for navigation.
            // We use the page class name as the route for clarity.
            Routing.RegisterRoute(nameof(SingletonExamplePage), typeof(SingletonExamplePage));
            Routing.RegisterRoute(nameof(TransientExamplePage), typeof(TransientExamplePage));
            Routing.RegisterRoute(nameof(ScopedExamplePage), typeof(ScopedExamplePage));
        }
    }
}
