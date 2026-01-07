using Microsoft.Extensions.Logging;

namespace _02_Brushes
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Views
            builder.Services.AddSingleton<Views.BrushesHubPage>();
            builder.Services.AddTransient<Views.SolidColorBrushPage>();
            builder.Services.AddTransient<Views.GradientStopsPage>();
            builder.Services.AddTransient<Views.LinearGradientBrushPage>();
            builder.Services.AddTransient<Views.RadialGradientBrushPage>();

            // ViewModels
            builder.Services.AddSingleton<ViewModels.BrushesHubViewModel>();
            builder.Services.AddTransient<ViewModels.SolidColorBrushViewModel>();
            builder.Services.AddTransient<ViewModels.GradientStopsViewModel>();
            builder.Services.AddTransient<ViewModels.LinearGradientViewModel>();
            builder.Services.AddTransient<ViewModels.RadialGradientViewModel>();

            return builder.Build();
        }
    }
}
