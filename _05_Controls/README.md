## Controls

The user interface of a .NET Multi-platform App UI (.NET MAUI) app is constructed of objects that map to the native controls of each target platform. The main control groups used to create the user interface of a .NET MAUI app are pages, layouts, and views. A .NET MAUI page generally occupies the full screen or window. The page usually contains a layout, which contains views and possibly other layouts. Pages, layouts, and views derive from the [VisualElement](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.visualelement) class. This class provides a variety of properties, methods, and events that are useful in derived classes.

Note: [ListView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.listview) and [TableView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.tableview) also support the use of cells. Cells are specialized elements used for items in a table, that describe how each item should be rendered.

For a comprehensive sample demonstrating various controls, see the [.NET MAUI Controls Gallery](https://learn.microsoft.com/en-us/samples/dotnet/maui-samples/userinterface-controlgallery).

### Pages

.NET MAUI apps consist of one or more pages. A page usually occupies all of the screen, or window, and each page typically contains at least one layout.

.NET MAUI contains the following pages:

| Page | Description |
|------|-------------|
| [ContentPage](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.contentpage) | Displays a single view, and is the most common page type. For more information, see [ContentPage](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/contentpage?view=net-maui-10.0). |
| [FlyoutPage](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.flyoutpage) | Manages two related pages of information – a flyout page that presents items, and a detail page that presents details about items on the flyout page. For more information, see [FlyoutPage](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/flyoutpage?view=net-maui-10.0). |
| [NavigationPage](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.navigationpage) | Provides a hierarchical navigation experience where you're able to navigate through pages, forwards and backwards, as desired. For more information, see [NavigationPage](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/navigationpage?view=net-maui-10.0). |
| [TabbedPage](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.tabbedpage) | Consists of a series of pages that are navigable by tabs across the top or bottom of the page, with each tab loading the page content. For more information, see [TabbedPage](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/tabbedpage?view=net-maui-10.0). |

### Layouts

.NET MAUI layouts are used to compose user-interface controls into visual structures, and each layout typically contains multiple views. Layout classes typically contain logic to set the position and size of child elements.

.NET MAUI contains the following layouts:

| Layout | Description |
|--------|-------------|
| [AbsoluteLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.absolutelayout) | Positions child elements at specific locations relative to its parent. For more information, see [AbsoluteLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/absolutelayout?view=net-maui-10.0). |
| [BindableLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.bindablelayout) | Enables any layout class to generate its content by binding to a collection of items, with the option to set the appearance of each item. For more information, see [BindableLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/bindablelayout?view=net-maui-10.0). |
| [FlexLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.flexlayout) | Enables its children to be stacked or wrapped with different alignment and orientation options. FlexLayout is based on the CSS Flexible Box Layout Module, known as flex layout or flex-box. For more information, see [FlexLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/flexlayout?view=net-maui-10.0). |
| [Grid](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.grid) | Positions its child elements in a grid of rows and columns. For more information, see [Grid](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid?view=net-maui-10.0). |
| [HorizontalStackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.horizontalstacklayout) | Positions child elements in a horizontal stack. For more information, see [HorizontalStackLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/horizontalstacklayout?view=net-maui-10.0). |
| [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) | Positions child elements in either a vertical or horizontal stack. For more information, see [StackLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/stacklayout?view=net-maui-10.0). |
| [VerticalStackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.verticalstacklayout) | Positions child elements in a vertical stack. For more information, see [VerticalStackLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/verticalstacklayout?view=net-maui-10.0). |

### Views

.NET MAUI views are the UI objects such as labels, buttons, and sliders that are commonly known as controls or widgets in other environments.

.NET MAUI contains the following views:

| View | Description |
|------|-------------|
| [ActivityIndicator](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.activityindicator) | Uses an animation to show that the app is engaged in a lengthy activity, without giving any indication of progress. For more information, see [ActivityIndicator](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/activityindicator?view=net-maui-10.0). |
| [BlazorWebView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.webview.maui.blazorwebview) | Enables you to host a Blazor web app in your .NET MAUI app. For more information, see [BlazorWebView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/blazorwebview?view=net-maui-10.0). |
| [Border](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.border) | Is a container control that draws a border, background, or both, around another control. For more information, see [Border](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/border?view=net-maui-10.0). |
| [BoxView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.boxview) | Draws a rectangle or square, of a specified width, height, and color. For more information, see [BoxView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/boxview?view=net-maui-10.0). |
| [Button](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.button) | Displays text and responds to a tap or click that directs an app to carry out a task. For more information, see [Button](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/button?view=net-maui-10.0). |
| [CarouselView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.carouselview) | Displays a scrollable list of data items, where users swipe to move through the collection. For more information, see [CarouselView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/carouselview/?view=net-maui-10.0). |
| [CheckBox](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.checkbox) | Enables you to select a boolean value using a type of button that can either be checked or empty. For more information, see [CheckBox](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/checkbox?view=net-maui-10.0). |
| [CollectionView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.collectionview) | Displays a scrollable list of selectable data items, using different layout specifications. For more information, see [CollectionView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/collectionview/?view=net-maui-10.0). |
| [ContentView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.contentview) | Is a control that enables the creation of custom, reusable controls. For more information, see [ContentView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/contentview?view=net-maui-10.0). |
| [DatePicker](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.datepicker) | Enables you to select a date with the platform date picker. For more information, see [DatePicker](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/datepicker?view=net-maui-10.0). |
| [Editor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.editor) | Enables you to enter and edit multiple lines of text. For more information, see [Editor](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/editor?view=net-maui-10.0). |
| [Ellipse](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.ellipse) | Displays an ellipse or circle. For more information, see [Ellipse](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/ellipse?view=net-maui-10.0). |
| [Entry](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.entry) | Enables you to enter and edit a single line of text. For more information, see [Entry](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/entry?view=net-maui-10.0). |
| [Frame](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.frame) | Is used to wrap a view or layout with a border that can be configured with color, shadow, and other options. For more information, see [Frame](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/frame?view=net-maui-10.0). |
| [GraphicsView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.graphicsview) | Is a graphics canvas on which 2D graphics can be drawn using types from the Microsoft.Maui.Graphics namespace. For more information, see [GraphicsView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/graphicsview?view=net-maui-10.0). |
| [HybridWebView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.hybridwebview) | Enables you to host arbitrary HTML/JS/CSS content in a web view, and enables communication between the code in the web view (JavaScript) and the code that hosts the web view (C#/.NET). For more information, see [HybridWebView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview?view=net-maui-10.0). |
| [Image](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.image) | Displays an image that can be loaded from a local file, a URI, an embedded resource, or a stream. For more information, see [Image](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/image?view=net-maui-10.0). |
| [ImageButton](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.imagebutton) | Displays an image and responds to a tap or click that direct an app to carry out a task. For more information, see [ImageButton](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/imagebutton?view=net-maui-10.0). |
| [IndicatorView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.indicatorview) | Displays indicators that represent the number of items in a CarouselView. For more information, see [IndicatorView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/indicatorview?view=net-maui-10.0). |
| [Label](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.label) | Displays single-line and multi-line text. For more information, see [Label](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-10.0). |
| [Line](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.line) | Displays a line from a start point to an end point. For more information, see [Line](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/line?view=net-maui-10.0). |
| [ListView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.listview) | Displays a scrollable list of selectable data items. For more information, see [ListView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/listview?view=net-maui-10.0). |
| [Map](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.maps.map) | Displays a map, and requires the Microsoft.Maui.Controls.Maps NuGet package to be installed in your app. |
| [Path](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.path) | Displays curves and complex shapes. For more information, see [Path](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/path?view=net-maui-10.0). |
| [Picker](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.picker) | Displays a short list of items, from which an item can be selected. For more information, see [Picker](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-10.0). |
| [Polygon](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.polygon) | Displays a polygon. For more information, see [Polygon](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/polygon?view=net-maui-10.0). |
| [Polyline](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.polyline) | Displays a series of connected straight lines. For more information, see [Polyline](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/polyline?view=net-maui-10.0). |
| [ProgressBar](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.progressbar) | Uses an animation to show that the app is progressing through a lengthy activity. For more information, see [ProgressBar](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/progressbar?view=net-maui-10.0). |
| [RadioButton](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.radiobutton) | Is a type of button that allows the selection of one option from a set. For more information, see [RadioButton](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/radiobutton?view=net-maui-10.0). |
| [Rectangle](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.rectangle) | Displays a rectangle or square. For more information, see [Rectangle](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/rectangle?view=net-maui-10.0). |
| [RefreshView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.refreshview) | Is a container control that provides pull-to-refresh functionality for scrollable content. For more information, see [RefreshView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/refreshview?view=net-maui-10.0). |
| [RoundRectangle](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.shapes.roundrectangle) | Displays a rectangle or square with rounded corners. For more information, see [RoundRectangle](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/shapes/rectangle?view=net-maui-10.0). |
| [ScrollView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.scrollview) | Provides scrolling of its content, which is typically a layout. For more information, see [ScrollView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/scrollview?view=net-maui-10.0). |
| [SearchBar](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.searchbar) | Is a user input control used to initiate a search. For more information, see [SearchBar](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/searchbar?view=net-maui-10.0). |
| [Slider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.slider) | Enables you to select a double value from a continuous range. For more information, see [Slider](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/slider?view=net-maui-10.0). |
| [Stepper](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stepper) | Enables you to select a double value from a range of incremental values. For more information, see [Stepper](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/stepper?view=net-maui-10.0). |
| [SwipeView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.swipeview) | Is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture. For more information, see [SwipeView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/swipeview?view=net-maui-10.0). |
| [Switch](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.switch) | Enables you to select a boolean value using a type of button that can either be on or off. For more information, see [Switch](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/switch?view=net-maui-10.0). |
| [TableView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.tableview) | Displays a table of scrollable items that can be grouped into sections. For more information, see [TableView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/tableview?view=net-maui-10.0). |
| [TimePicker](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.timepicker) | Enables you to select a time with the platform time picker. For more information, see [TimePicker](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/timepicker?view=net-maui-10.0). |
| [TitleBar](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.titlebar) | Enables you to add a custom title bar to a Window to match the personality of your app. For more information, see [TitleBar](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/titlebar?view=net-maui-10.0). |
| [TwoPaneView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.foldable.twopaneview) | Represents a container with two views that size and position their content in the available space, either side-by-side or top-to-bottom. For more information, see [TwoPaneView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/twopaneview?view=net-maui-10.0). |
| [WebView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.webview) | Displays web pages or local HTML content. For more information, see [WebView](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview?view=net-maui-10.0). |



## Align and Position Controls

Every .NET Multi-platform App UI (.NET MAUI) control that derives from [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view), which includes views and layouts, has `HorizontalOptions` and `VerticalOptions` properties, of type `LayoutOptions`. The `LayoutOptions` structure encapsulates a view's preferred alignment, which determines its position and size within its parent layout when the parent layout contains unused space (that is, the parent layout is larger than the combined size of all its children).

In addition, the `Margin` and `Padding` properties position controls relative to adjacent, or child controls. For more information, see [Position controls](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/align-position?view=net-maui-10.0#position-controls).

<img width="1000" height="380" alt="Margin_Alignment" src="https://github.com/user-attachments/assets/11db1b18-74d2-489b-a455-ea8de0dd67cb" />

### Align Views in Layouts

The alignment of a [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view), relative to its parent, can be controlled by setting the `HorizontalOptions` or `VerticalOptions` property of the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) to one of the public fields from the `LayoutOptions` structure. The public fields are `Start`, `Center`, `End`, and `Fill`.

The `Start`, `Center`, `End`, and `Fill` fields are used to define the view's alignment within the parent layout:

- For horizontal alignment, `Start` positions the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) on the left hand side of the parent layout, and for vertical alignment, it positions the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) at the top of the parent layout.
- For horizontal and vertical alignment, `Center` horizontally or vertically centers the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view).
- For horizontal alignment, `End` positions the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) on the right hand side of the parent layout, and for vertical alignment, it positions the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) at the bottom of the parent layout.
- For horizontal alignment, `Fill` ensures that the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) fills the width of the parent layout, and for vertical alignment, it ensures that the [View](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.view) fills the height of the parent layout.

Note: The default value of a view's `HorizontalOptions` and `VerticalOptions` properties is `LayoutOptions.Fill`.

A [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) only respects the `Start`, `Center`, `End`, and `Fill` `LayoutOptions` fields on child views that are in the opposite direction to the [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) orientation. Therefore, child views within a vertically oriented [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) can set their `HorizontalOptions` properties to one of the `Start`, `Center`, `End`, or `Fill` fields. Similarly, child views within a horizontally oriented [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) can set their `VerticalOptions` properties to one of the `Start`, `Center`, `End`, or `Fill` fields.

A [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) does not respect the `Start`, `Center`, `End`, and `Fill` `LayoutOptions` fields on child views that are in the same direction as the [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) orientation. Therefore, a vertically oriented [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) ignores the `Start`, `Center`, `End`, or `Fill` fields if they are set on the `VerticalOptions` properties of child views. Similarly, a horizontally oriented [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) ignores the `Start`, `Center`, `End`, or `Fill` fields if they are set on the `HorizontalOptions` properties of child views.

Important: `LayoutOptions.Fill` generally overrides size requests specified using the [HeightRequest](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.visualelement.heightrequest) and [WidthRequest](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.visualelement.widthrequest) properties.

The following XAML example demonstrates a vertically oriented [StackLayout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.stacklayout) where each child [Label](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.label) sets its `HorizontalOptions` property to one of the four alignment fields from the `LayoutOptions` structure:

```xml
<StackLayout>
  ...
  <Label Text="Start" BackgroundColor="Gray" HorizontalOptions="Start" />
  <Label Text="Center" BackgroundColor="Gray" HorizontalOptions="Center" />
  <Label Text="End" BackgroundColor="Gray" HorizontalOptions="End" />
  <Label Text="Fill" BackgroundColor="Gray" HorizontalOptions="Fill" />
</StackLayout>
```

### Position Controls

The `Margin` and `Padding` properties position controls relative to adjacent, or child controls. Margin and padding are related layout concepts:

- The `Margin` property represents the distance between an element and its adjacent elements, and is used to control the element's rendering position, and the rendering position of its neighbors. `Margin` values can be specified on layouts and views.
- The `Padding` property represents the distance between an element and its child elements, and is used to separate the control from its own content. `Padding` values can be specified on pages, layouts, and views.

Note: `Margin` values are additive. Therefore, if two adjacent elements specify a margin of 20 device-independent units, the distance between the elements will be 40 device-independent units. In addition, margin and padding values are additive when both are applied, in that the distance between an element and any content will be the margin plus padding. For more information about device-independent units, see [Device-independent units](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/device-independent-units?view=net-maui-10.0).

The `Margin` and `Padding` properties are both of type `Thickness`. There are three possibilities when creating a `Thickness` structure:

- Create a `Thickness` structure defined by a single uniform value. The single value is applied to the left, top, right, and bottom sides of the element.
- Create a `Thickness` structure defined by horizontal and vertical values. The horizontal value is symmetrically applied to the left and right sides of the element, with the vertical value being symmetrically applied to the top and bottom sides of the element.
- Create a `Thickness` structure defined by four distinct values that are applied to the left, top, right, and bottom sides of the element.

The following XAML example shows all three possibilities:

```xml
<StackLayout Padding="0,20,0,0">
  <!-- Margin defined by a single uniform value. -->
  <Label Text=".NET MAUI" Margin="20" />
  <!-- Margin defined by horizontal and vertical values. -->  
  <Label Text=".NET for iOS" Margin="10,15" />
  <!-- Margin defined by four distinct values that are applied to the left, top, right, and bottom. -->  
  <Label Text=".NET for Android" Margin="0,20,15,5" />
</StackLayout>
```

The equivalent C# code is:

```csharp
StackLayout stackLayout = new StackLayout
{
  Padding = new Thickness(0,20,0,0)
};
// Margin defined by a single uniform value.
stackLayout.Add(new Label { Text = ".NET MAUI", Margin = new Thickness(20) });
// Margin defined by horizontal and vertical values.
stackLayout.Add(new Label { Text = ".NET for iOS", Margin = new Thickness(10,25) });
// Margin defined by four distinct values that are applied to the left, top, right, and bottom.
stackLayout.Add(new Label { Text = ".NET for Android", Margin = new Thickness(0,20,15,5) });  
```

Note: `Thickness` values can be negative, which typically clips or overdraws the content.

