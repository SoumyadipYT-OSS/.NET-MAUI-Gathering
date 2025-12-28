using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace _03_DataBindMvvm.Helpers;

/// <summary>
/// Simple navigation service implementation that delegates to <see cref="Shell"/>.
/// Views can create and pass this service into viewmodels.
/// </summary>
public sealed class ShellNavigationService : INavigationService
{
    public Task NavigateToAsync(string route)
    {
        // Delegate directly to Shell navigation. Viewmodels are unaware of Shell itself.
        return Shell.Current.GoToAsync(route);
    }
}
