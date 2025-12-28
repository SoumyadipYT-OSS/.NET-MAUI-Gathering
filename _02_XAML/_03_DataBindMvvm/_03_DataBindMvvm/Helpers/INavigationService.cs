using System.Threading.Tasks;

namespace _03_DataBindMvvm.Helpers;

/// <summary>
/// Abstraction over navigation operations so that viewmodels remain UI-agnostic.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Navigates to the specified route.
    /// </summary>
    /// <param name="route">The Shell route to navigate to, including any query parameters.</param>
    Task NavigateToAsync(string route);
}
