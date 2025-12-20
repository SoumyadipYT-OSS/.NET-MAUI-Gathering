# XAML Fundamentals Learning Project (_01_Overview)

A comprehensive .NET MAUI learning project demonstrating XAML fundamentals through self-contained, interactive modules. Built with MVVM pattern, compiled bindings, Shell navigation, and Hot Reload-friendly practices.

## Project Overview

This project serves as a hands-on learning resource for understanding XAML concepts in .NET MAUI. Each module focuses on specific topics with working examples, explanations, and links to official documentation.

## Modules

| Module | Description | Key Concepts |
|--------|-------------|--------------|
| **Layout Lab** | Explore layout containers | Grid, StackLayout, FlexLayout, AbsoluteLayout, responsive design |
| **Binding Lab** | Master data binding | Compiled bindings, x:Reference, binding modes, converters, query parameters |
| **Styles Studio** | Learn XAML styling | Implicit/explicit styles, BasedOn inheritance, resource scoping, StaticResource vs DynamicResource |
| **Template Forge** | Create custom controls | ControlTemplate, TemplateBinding, ContentPresenter, bindable properties |
| **Trigger Clinic** | Dynamic UI with triggers | PropertyTrigger, DataTrigger, MultiTrigger, style-based triggers |
| **States Arena** | Visual State Manager | CommonStates, custom state groups, inline vs style-based VSM |
| **Theme Switcher** | Light/Dark theming | AppThemeBinding, DynamicResource, runtime theme switching |

## Architecture

```
_01_Overview/
- App.xaml                    # App-level resources, converters, styles
- AppShell.xaml               # Shell navigation with flyout menu
- Controls/
  - CardView.xaml(.cs)        # Custom ContentView with ControlTemplate
- Converters/
  - InverseBoolConverter.cs
  - StringToBoolConverter.cs
  - DoubleToMultipliedValueConverter.cs
- Pages/
  - MainPage.xaml(.cs)           # Navigation hub
  - LayoutLabPage.xaml(.cs)      # Layout demonstrations
  - BindingLabPage.xaml(.cs)     # Binding demonstrations
  - StylesStudioPage.xaml(.cs)   # Styles demonstrations
  - TemplateForgePage.xaml(.cs)  # Template demonstrations
  - TriggerClinicPage.xaml(.cs)  # Trigger demonstrations
  - StatesArenaPage.xaml(.cs)    # VSM demonstrations
  - ThemeSwitcherPage.xaml(.cs)  # Theming demonstrations
- Resources/
  - Styles/
    - Colors.xaml           # Color palette
    - Styles.xaml           # Default control styles
    - LightTheme.xaml       # Light theme colors
    - DarkTheme.xaml        # Dark theme colors
- ViewModels/
  - BaseViewModel.cs        # INotifyPropertyChanged base class
  - MainPageViewModel.cs
  - LayoutLabViewModel.cs
  - BindingLabViewModel.cs
  - StylesStudioViewModel.cs
  - TemplateForgeViewModel.cs
  - TriggerClinicViewModel.cs
  - StatesArenaViewModel.cs
  - ThemeSwitcherViewModel.cs
```

## Key Features

### Compiled Bindings (x:DataType)
All pages use compiled bindings for:
- Compile-time validation of binding paths
- IntelliSense support in XAML
- Better runtime performance (no reflection)
- Binding errors caught at build time

```xml
<ContentPage x:DataType="viewmodels:MyViewModel">
    <Label Text="{Binding PropertyName}" />
</ContentPage>
```

### Shell Navigation
- URI-based routes defined in AppShell
- Programmatic navigation with `Shell.Current.GoToAsync()`
- Query parameter passing with `[QueryProperty]`

```csharp
// Navigate with parameter
await Shell.Current.GoToAsync($"BindingLab?message={Uri.EscapeDataString("Hello")}");

// Receive in ViewModel
[QueryProperty(nameof(Message), "message")]
public class BindingLabViewModel : BaseViewModel
{
    public string Message { get; set; }
}
```

### MVVM Pattern
- ViewModels inherit from `BaseViewModel` with `INotifyPropertyChanged`
- Commands for user interactions
- Clean separation of concerns

### Hot Reload Friendly
- Minimal constructor logic
- No blocking code in code-behind
- XAML-only triggers and visual states

## Styles Demonstrated

### Implicit Styles (no x:Key)
Automatically apply to all controls of the target type:
```xml
<Style TargetType="BoxView">
    <Setter Property="CornerRadius" Value="8" />
</Style>
```

### Explicit Styles (with x:Key)
Must be referenced explicitly:
```xml
<Style x:Key="PrimaryButtonStyle" TargetType="Button">
    <Setter Property="BackgroundColor" Value="{StaticResource Primary}" />
</Style>

<Button Style="{StaticResource PrimaryButtonStyle}" />
```

### Style Inheritance (BasedOn)
```xml
<Style x:Key="DerivedStyle" TargetType="Button" BasedOn="{StaticResource BaseStyle}">
    <Setter Property="FontAttributes" Value="Bold" />
</Style>
```

## ControlTemplate Example

The `CardView` control demonstrates:
- Bindable properties (`CardTitle`, `CardFooter`, `BorderColor`)
- ControlTemplate with `TemplateBinding`
- `ContentPresenter` for content projection
- Template swapping via styles

```xml
<controls:CardView CardTitle="My Card"
                   BorderColor="Purple">
    <Label Text="Card content goes here" />
</controls:CardView>
```

## Triggers

### DataTrigger (Save button disabled when empty)
```xml
<Button Text="Save">
    <Button.Triggers>
        <DataTrigger TargetType="Button"
                     Binding="{Binding CanSave}"
                     Value="False">
            <Setter Property="IsEnabled" Value="False" />
        </DataTrigger>
    </Button.Triggers>
</Button>
```

### MultiDataTrigger (All conditions must be true)
```xml
<MultiDataTrigger TargetType="Button">
    <MultiDataTrigger.Conditions>
        <BindingCondition Binding="{Binding IsValidEmail}" Value="True" />
        <BindingCondition Binding="{Binding IsStrongPassword}" Value="True" />
        <BindingCondition Binding="{Binding TermsAccepted}" Value="True" />
    </MultiDataTrigger.Conditions>
    <Setter Property="IsEnabled" Value="True" />
</MultiDataTrigger>
```

## Theming

### AppThemeBinding (Automatic)
```xml
<Label TextColor="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
```

### Runtime Theme Switching
```csharp
// Light theme
Application.Current.UserAppTheme = AppTheme.Light;

// Dark theme
Application.Current.UserAppTheme = AppTheme.Dark;

// Follow system
Application.Current.UserAppTheme = AppTheme.Unspecified;
```

## .NET MAUI 10 Stretch Goal

### Implicit/Global XAML Namespaces

.NET MAUI 10 supports reducing xmlns noise through project-level configuration:

```xml
<!-- In .csproj -->
<PropertyGroup>
    <MauiImplicitXmlnsNamespaces>true</MauiImplicitXmlnsNamespaces>
</PropertyGroup>
```

This enables cleaner XAML without repetitive namespace declarations:
```xml
<!-- Before -->
<ContentPage xmlns:viewmodels="clr-namespace:MyApp.ViewModels">

<!-- After (with implicit namespaces) -->
<ContentPage>
    <!-- viewmodels namespace available automatically -->
```

**Note**: This feature requires opt-in and may affect existing projects. Test thoroughly before enabling.

## Documentation Links

- [XAML Overview](https://learn.microsoft.com/dotnet/maui/xaml/)
- [Data Binding](https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/)
- [Compiled Bindings](https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/compiled-bindings)
- [Shell Navigation](https://learn.microsoft.com/dotnet/maui/fundamentals/shell/navigation)
- [Styles](https://learn.microsoft.com/dotnet/maui/user-interface/styles/xaml)
- [ControlTemplate](https://learn.microsoft.com/dotnet/maui/fundamentals/controltemplate)
- [Triggers](https://learn.microsoft.com/dotnet/maui/fundamentals/triggers)
- [Visual States](https://learn.microsoft.com/dotnet/maui/user-interface/visual-states)
- [Theming](https://learn.microsoft.com/dotnet/maui/user-interface/theming)

## Requirements

- .NET 10 SDK
- Visual Studio 2022 17.12+ or VS Code with .NET MAUI extension
- Android SDK (for Android deployment)
- Xcode (for iOS deployment on macOS)

## Target Platforms

- Android 21+
- iOS 15+

## Running the Project

```bash
# Clone the repository
git clone https://github.com/SoumyadipYT-OSS/.NET-MAUI-Gathering.git

# Navigate to the project
cd .NET-MAUI-Gathering/_02_XAML/_01_Overview

# Run on Android
dotnet build -t:Run -f net10.0-android

# Run on iOS (macOS only)
dotnet build -t:Run -f net10.0-ios
```

## License

This project is for educational purposes. Feel free to use, modify, and distribute.

---

**Happy Learning!**
