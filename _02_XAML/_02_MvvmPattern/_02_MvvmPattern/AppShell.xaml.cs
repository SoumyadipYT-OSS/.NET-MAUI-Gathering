using _02_MvvmPattern.Views;

namespace _02_MvvmPattern
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
            Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));
        }
    }
}
