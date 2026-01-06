using _04_DataBinding.Views;

namespace _04_DataBinding
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("basic", typeof(BasicBindingsPage));
            Routing.RegisterRoute("modes", typeof(BindingModesPage));
            Routing.RegisterRoute("paths", typeof(BindingPathsPage));
            Routing.RegisterRoute("converters", typeof(ConvertersPage));
            Routing.RegisterRoute("relative", typeof(RelativeBindingsPage));
            Routing.RegisterRoute("fallbacks", typeof(BindingFallbacksPage));
            Routing.RegisterRoute("multibinding", typeof(MultiBindingPage));
            Routing.RegisterRoute("commanding", typeof(CommandingPage));
            Routing.RegisterRoute("compiled", typeof(CompiledBindingsPage));
        }
    }
}
