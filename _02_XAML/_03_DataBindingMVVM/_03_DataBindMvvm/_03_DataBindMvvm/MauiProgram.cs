using _03_DataBindMvvm.Helpers;
using _03_DataBindMvvm.Pages;
using _03_DataBindMvvm.ViewModels;
using Microsoft.Extensions.Logging;

namespace _03_DataBindMvvm
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

            builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddSingleton<AppShell>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}
