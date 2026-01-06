using _04_DataBinding.ViewModels;
using _04_DataBinding.Views;
using Microsoft.Extensions.Logging;

namespace _04_DataBinding
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ViewModels
            builder.Services.AddSingleton<BindingIndexViewModel>();

            // Pages
            builder.Services.AddSingleton<BindingIndexPage>();
            builder.Services.AddTransient<BasicBindingsPage>();
            builder.Services.AddTransient<BindingModesPage>();
            builder.Services.AddTransient<BindingPathsPage>();
            builder.Services.AddTransient<ConvertersPage>();
            builder.Services.AddTransient<RelativeBindingsPage>();
            builder.Services.AddTransient<BindingFallbacksPage>();
            builder.Services.AddTransient<MultiBindingPage>();
            builder.Services.AddTransient<CommandingPage>();
            builder.Services.AddTransient<CompiledBindingsPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
