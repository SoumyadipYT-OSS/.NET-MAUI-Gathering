using Microsoft.Extensions.DependencyInjection;

namespace _02_AppLifecycle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LifecycleReporter.Report("Application constructed");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            LifecycleReporter.Report("CreateWindow invoked");
            return new Window(new AppShell());
        }
    }
}