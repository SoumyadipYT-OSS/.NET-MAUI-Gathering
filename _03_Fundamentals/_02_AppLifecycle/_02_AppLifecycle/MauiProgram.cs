using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace _02_AppLifecycle
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
                })
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID21_0_OR_GREATER
                    events.AddAndroid(android =>
                    {
                        android.OnCreate((activity, bundle) => LifecycleReporter.Report("[Android] Activity OnCreate"));
                        android.OnStart((activity) => LifecycleReporter.Report("[Android] Activity OnStart"));
                        android.OnResume((activity) => LifecycleReporter.Report("[Android] Activity OnResume"));
                        android.OnPause((activity) => LifecycleReporter.Report("[Android] Activity OnPause"));
                        android.OnStop((activity) => LifecycleReporter.Report("[Android] Activity OnStop"));
                        android.OnDestroy((activity) => LifecycleReporter.Report("[Android] Activity OnDestroy"));
                    });
#endif
#if IOS15_0_OR_GREATER
                    events.AddiOS(ios =>
                    {
                        ios.FinishedLaunching((app, dict) =>
                        {
                            LifecycleReporter.Report("[iOS] FinishedLaunching");
                            return true;
                        });
                        ios.OnActivated(app => LifecycleReporter.Report("[iOS] OnActivated"));
                        ios.OnResignActivation(app => LifecycleReporter.Report("[iOS] OnResignActivation"));
                        ios.WillEnterForeground(app => LifecycleReporter.Report("[iOS] WillEnterForeground"));
                        ios.DidEnterBackground(app => LifecycleReporter.Report("[iOS] DidEnterBackground"));
                    });
#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
