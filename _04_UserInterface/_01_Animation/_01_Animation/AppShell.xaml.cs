using _01_Animation.ViewModels;
using _01_Animation.Views;

namespace _01_Animation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(Routes.BasicAnimations, typeof(BasicAnimationsPage));
            Routing.RegisterRoute(Routes.Easing, typeof(EasingPage));
            Routing.RegisterRoute(Routes.CustomAnimations, typeof(CustomAnimationsPage));
        }
    }
}
