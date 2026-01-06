using Microsoft.Extensions.Logging;
using _05_DependencyInjection.Pages;
using _05_DependencyInjection.Services;
using _05_DependencyInjection.ViewModels;

namespace _05_DependencyInjection
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

            // DI registrations (Microsoft.Extensions.DependencyInjection)
            //
            // Why DI?
            // - Separates *what* an object needs (an interface) from *how* it's created (implementation).
            // - Makes view models easy to unit test by swapping real services for test doubles.
            // - Centralizes app-wide composition in one place.

            // Singleton: one instance for the entire app lifetime.
            builder.Services.AddSingleton<IAppConfig>(new AppConfig
            {
                EnvironmentName = "Development",
                ApiBaseUrl = "https://example.invalid/api"
            });
            builder.Services.AddSingleton<ILoggingService, DebugLoggingService>();

            // Transient: a new instance each time it's requested.
            builder.Services.AddTransient<IClock, SystemClock>();
            builder.Services.AddTransient<IFruitRepository, InMemoryFruitRepository>();

            // "Scoped": scope support exists in the container, but MAUI doesn't create request scopes for you.
            // We'll demonstrate creating a scope manually on a dedicated page.
            builder.Services.AddScoped<IOperationId, OperationId>();

            // Shell + navigation pages
            builder.Services.AddSingleton<AppShell>();

            // Pages and view models.
            // ViewModels are transient in this tutorial so each navigation produces a fresh instance.
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<SingletonExampleViewModel>();
            builder.Services.AddTransient<SingletonExamplePage>();

            builder.Services.AddTransient<TransientExampleViewModel>();
            builder.Services.AddTransient<TransientExamplePage>();

            builder.Services.AddTransient<ScopedExamplePage>();

            return builder.Build();
        }
    }
}
