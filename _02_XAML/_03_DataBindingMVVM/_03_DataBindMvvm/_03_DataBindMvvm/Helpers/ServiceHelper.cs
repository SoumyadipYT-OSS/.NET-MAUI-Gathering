using System;
using Microsoft.Extensions.DependencyInjection;

namespace _03_DataBindMvvm.Helpers;

/// <summary>
/// Provides access to the app's root <see cref="IServiceProvider"/> so that XAML-constructed
/// pages can resolve their viewmodels without manual new-ing.
/// </summary>
public static class ServiceHelper
{
    private static IServiceProvider? _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public static T GetRequiredService<T>() where T : notnull
    {
        if (_serviceProvider is null)
        {
            throw new InvalidOperationException("Service provider has not been initialized yet.");
        }

        return _serviceProvider.GetRequiredService<T>();
    }
}
