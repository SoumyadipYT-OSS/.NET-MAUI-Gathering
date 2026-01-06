using System.Windows.Input;
using _05_DependencyInjection.Services;

namespace _05_DependencyInjection.ViewModels;

public sealed class TransientExampleViewModel(
    IClock clock,
    IFruitRepository fruitRepository,
    ILoggingService logging) : ViewModelBase
{
    private string _clockInstanceInfo = "";
    private string _data = "";

    public string Explanation =>
        "Transient services are created every time they are requested from the container.\n" +
        "They are a good default for lightweight, stateless services.";

    // Shows that a transient dependency (IClock) used by this VM is a fresh instance per VM.
    public string ClockInstanceInfo
    {
        get => _clockInstanceInfo;
        private set => SetProperty(ref _clockInstanceInfo, value);
    }

    public string Data
    {
        get => _data;
        private set => SetProperty(ref _data, value);
    }

    public ICommand LoadCommand => new Command(async () =>
    {
        var fruits = await fruitRepository.GetFruitsAsync();
        Data = string.Join(", ", fruits);
        ClockInstanceInfo = $"VM clock time: {clock.Now:O}";
        logging.Log("Transient example: loaded fruit list.");
    });
}
