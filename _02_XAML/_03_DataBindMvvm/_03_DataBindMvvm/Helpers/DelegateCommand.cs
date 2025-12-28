using System;
using System.Windows.Input;

namespace _03_DataBindMvvm.Helpers;

/// <summary>
/// Simple command implementation that relays Execute and CanExecute logic.
/// Keeps viewmodels free from UI framework types, only depends on <see cref="ICommand"/>.
/// </summary>
public sealed class DelegateCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    /// <summary>
    /// Notifies the UI that the command's ability to execute has changed.
    /// </summary>
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
