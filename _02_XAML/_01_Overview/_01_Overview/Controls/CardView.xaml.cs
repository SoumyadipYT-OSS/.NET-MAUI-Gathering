namespace _01_Overview.Controls;

/// <summary>
/// CardView is a custom ContentView control with bindable properties.
/// Demonstrates ControlTemplate and TemplateBinding usage.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/controltemplate
/// </summary>
public partial class CardView : ContentView
{
    #region Bindable Properties

    /// <summary>
    /// Bindable property for the card title displayed in the header.
    /// </summary>
    public static readonly BindableProperty CardTitleProperty =
        BindableProperty.Create(
            nameof(CardTitle),
            typeof(string),
            typeof(CardView),
            string.Empty);

    /// <summary>
    /// Bindable property for the card footer text.
    /// </summary>
    public static readonly BindableProperty CardFooterProperty =
        BindableProperty.Create(
            nameof(CardFooter),
            typeof(string),
            typeof(CardView),
            string.Empty,
            propertyChanged: OnCardFooterChanged);

    /// <summary>
    /// Bindable property for the card border color.
    /// </summary>
    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(
            nameof(BorderColor),
            typeof(Color),
            typeof(CardView),
            Colors.Purple);

    /// <summary>
    /// Bindable property for the card background color.
    /// </summary>
    public static readonly BindableProperty CardBackgroundColorProperty =
        BindableProperty.Create(
            nameof(CardBackgroundColor),
            typeof(Color),
            typeof(CardView),
            Colors.White);

    /// <summary>
    /// Bindable property indicating whether footer is visible.
    /// </summary>
    public static readonly BindableProperty HasFooterProperty =
        BindableProperty.Create(
            nameof(HasFooter),
            typeof(bool),
            typeof(CardView),
            false);

    #endregion

    #region Properties

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string CardFooter
    {
        get => (string)GetValue(CardFooterProperty);
        set => SetValue(CardFooterProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Color CardBackgroundColor
    {
        get => (Color)GetValue(CardBackgroundColorProperty);
        set => SetValue(CardBackgroundColorProperty, value);
    }

    public bool HasFooter
    {
        get => (bool)GetValue(HasFooterProperty);
        set => SetValue(HasFooterProperty, value);
    }

    #endregion

    public CardView()
    {
        InitializeComponent();
    }

    private static void OnCardFooterChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CardView cardView)
        {
            cardView.HasFooter = !string.IsNullOrWhiteSpace(newValue?.ToString());
        }
    }
}
