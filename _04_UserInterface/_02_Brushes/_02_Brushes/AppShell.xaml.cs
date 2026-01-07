using _02_Brushes.Views;

namespace _02_Brushes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("SolidColorBrush", typeof(SolidColorBrushPage));
            Routing.RegisterRoute("GradientStops", typeof(GradientStopsPage));
            Routing.RegisterRoute("LinearGradient", typeof(LinearGradientBrushPage));
            Routing.RegisterRoute("RadialGradient", typeof(RadialGradientBrushPage));
        }
    }
}
