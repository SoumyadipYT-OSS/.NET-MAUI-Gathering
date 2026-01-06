using System.Globalization;

namespace _03_Behaviors.Behaviors;

// A Behavior is a reusable component that can be attached to a control to add functionality
// without subclassing the control.
//
// This behavior restricts an Entry to numeric-only input.
public sealed class NumericValidationBehavior : Behavior<Entry>
{
    // We keep the last valid value so we can revert when the user types an invalid character.
    string _lastValidText = string.Empty;

    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);

        _lastValidText = bindable.Text ?? string.Empty;
        bindable.TextChanged += OnEntryTextChanged;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        bindable.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(bindable);
    }

    void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender!;
        var newText = e.NewTextValue ?? string.Empty;

        // Allow empty (so backspace works).
        if (newText.Length == 0)
        {
            _lastValidText = string.Empty;
            entry.TextColor = Colors.Black;
            return;
        }

        // Accept integers and decimals for the current culture.
        // If you want integers only, replace this with: `newText.All(char.IsDigit)`.
        var isNumeric = decimal.TryParse(newText, NumberStyles.Number, CultureInfo.CurrentCulture, out _);

        if (isNumeric)
        {
            _lastValidText = newText;
            entry.TextColor = Colors.Black;
            return;
        }

        // Invalid input: revert to previous valid value.
        entry.Text = _lastValidText;

        // Optional: visual cue to learners that something was rejected.
        entry.TextColor = Colors.Red;
    }
}
