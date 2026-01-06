using _05_DependencyInjection.Services;

namespace _05_DependencyInjection.Pages;

public partial class ScopedExamplePage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public ScopedExamplePage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private void OnResolveInSameScopeClicked(object sender, EventArgs e)
    {
        using var scope = _serviceProvider.CreateScope();

        var id1 = scope.ServiceProvider.GetRequiredService<IOperationId>().Id;
        var id2 = scope.ServiceProvider.GetRequiredService<IOperationId>().Id;

        // In the same scope, a scoped service returns the same instance.
        SameScopeLabel.Text = $"Same scope:\n  First resolve:  {id1}\n  Second resolve: {id2}\n  Same instance:  {id1 == id2}";
    }

    private void OnResolveAcrossScopesClicked(object sender, EventArgs e)
    {
        Guid scope1Id;
        using (var scope1 = _serviceProvider.CreateScope())
        {
            scope1Id = scope1.ServiceProvider.GetRequiredService<IOperationId>().Id;
        }

        Guid scope2Id;
        using (var scope2 = _serviceProvider.CreateScope())
        {
            scope2Id = scope2.ServiceProvider.GetRequiredService<IOperationId>().Id;
        }

        AcrossScopesLabel.Text = $"Different scopes:\n  Scope #1: {scope1Id}\n  Scope #2: {scope2Id}\n  Same instance: {scope1Id == scope2Id}";
    }

    private async void OnBackClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
