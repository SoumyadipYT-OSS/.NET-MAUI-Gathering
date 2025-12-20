using Microsoft.Maui.Layouts;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for LayoutLab page demonstrating Grid, StackLayout, FlexLayout.
/// Shows responsive layout techniques and layout properties.
/// </summary>
public class LayoutLabViewModel : BaseViewModel
{
    private int _gridRows = 3;
    private int _gridColumns = 3;
    private double _spacing = 10;
    private FlexWrap _flexWrap = FlexWrap.Wrap;
    private FlexJustify _flexJustify = FlexJustify.SpaceAround;

    public LayoutLabViewModel()
    {
        LayoutItems = new List<LayoutItem>
        {
            new("Item 1", Colors.Red),
            new("Item 2", Colors.Blue),
            new("Item 3", Colors.Green),
            new("Item 4", Colors.Orange),
            new("Item 5", Colors.Purple),
            new("Item 6", Colors.Teal)
        };
    }

    public int GridRows
    {
        get => _gridRows;
        set => SetProperty(ref _gridRows, value);
    }

    public int GridColumns
    {
        get => _gridColumns;
        set => SetProperty(ref _gridColumns, value);
    }

    public double Spacing
    {
        get => _spacing;
        set => SetProperty(ref _spacing, value);
    }

    public FlexWrap FlexWrap
    {
        get => _flexWrap;
        set => SetProperty(ref _flexWrap, value);
    }

    public FlexJustify FlexJustify
    {
        get => _flexJustify;
        set => SetProperty(ref _flexJustify, value);
    }

    public List<LayoutItem> LayoutItems { get; }

    public List<string> FlexWrapOptions => Enum.GetNames(typeof(FlexWrap)).ToList();
    public List<string> FlexJustifyOptions => Enum.GetNames(typeof(FlexJustify)).ToList();
}

public record LayoutItem(string Name, Color BackgroundColor);
