using ExpenseApp.ViewModels;
using ExpenseApp.Views;
using Microsoft.Extensions.Logging;

namespace ExpenseApp
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


            // DI registrations for MVVM
            builder.Services.AddSingleton<ExpensesViewModel>();
            builder.Services.AddTransient<ExpensesPage>();

            // CommunityToolkit.Mvvm
            builder.Services.AddTransient<ExpenseDetailViewModel>();
            builder.Services.AddTransient<ExpenseDetailPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
