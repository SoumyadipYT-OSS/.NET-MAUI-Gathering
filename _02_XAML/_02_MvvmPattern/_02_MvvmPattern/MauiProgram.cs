using Microsoft.Extensions.Logging;
using _02_MvvmPattern.Services;
using _02_MvvmPattern.ViewModels;
using _02_MvvmPattern.Views;

namespace _02_MvvmPattern
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

            // Register Services (Singleton to share data between ViewModels)
            builder.Services.AddSingleton<ProductDataService>();

            // Register ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<AddProductViewModel>();
            builder.Services.AddTransient<EditProductViewModel>();

            // Register Pages
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AddProductPage>();
            builder.Services.AddTransient<EditProductPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
