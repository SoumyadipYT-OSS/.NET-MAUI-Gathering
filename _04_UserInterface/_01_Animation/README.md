```mermaid
flowchart TB
  %% Global styling
  classDef page fill=#f9f9f9,stroke=#333,stroke-width=2px,color=#000,fontSize=16px,fontWeight=bold;
  classDef control fill=#e3f2fd,stroke=#1565c0,stroke-width=1.5px,color=#000,fontSize=14px;
  classDef layout fill=#fff3e0,stroke=#ef6c00,stroke-width=1.5px,color=#000,fontSize=14px;
  classDef action fill=#ede7f6,stroke=#4527a0,stroke-width=1.5px,color=#000,fontSize=14px;

  %% App + Shell
  App[" App (Application)\nMainWindow: AppShell"]:::page --> Shell
  Shell[" AppShell (Shell)\nTitle: Animations\nRoutes: Home, BasicAnimations, Easing, CustomAnimations"]:::page --> HomePage

  %% Home Page
  subgraph HOME[" HomePage (ContentPage)\nTitle: Animation Fundamentals\nBindingContext: HomeViewModel"]
    direction TB
    HOME_Scroll["ScrollView"]:::layout --> HOME_Root["VerticalStackLayout\nPadding:16, Spacing:16"]:::layout
    HOME_Root --> HOME_Title["Label: .NET MAUI Animations"]:::control
    HOME_Root --> HOME_Intro["Label: Intro (tutorial)"]:::control
    HOME_Root --> HOME_List["CollectionView\nItemsSource: {Binding Demos}"]:::layout
    HOME_List --> HOME_Template["DataTemplate\nx:DataType: DemoItem"]:::layout
    HOME_Template --> HOME_Card["Border Card\nTapGestureRecognizer: OnDemoTapped"]:::control
    HOME_Card --> HOME_CardStack["VerticalStackLayout"]:::layout
    HOME_CardStack --> HOME_CardTitle["Label: {Binding Title}"]:::control
    HOME_CardStack --> HOME_CardDesc["Label: {Binding Description}"]:::control
  end

  %% Basic Animations Page
  subgraph BASIC[" BasicAnimationsPage (ContentPage)\nTitle: Basic animations"]
    direction TB
    BASIC_Root["VerticalStackLayout\nPadding:16, Spacing:16"]:::layout
    BASIC_Root --> BASIC_Header["Label: Fade / Translate / Scale / Rotate"]:::control
    BASIC_Root --> BASIC_Target["Border Target\nBackgroundColor: Primary\nSize: 90x90"]:::control
    BASIC_Root --> BASIC_Buttons["Grid Buttons"]:::layout
    BASIC_Buttons --> BASIC_Fade["Button: Fade"]:::action
    BASIC_Buttons --> BASIC_Translate["Button: Translate"]:::action
    BASIC_Buttons --> BASIC_Scale["Button: Scale"]:::action
    BASIC_Buttons --> BASIC_Rotate["Button: Rotate"]:::action
    BASIC_Buttons --> BASIC_Reset["Button: Reset"]:::action
  end

  %% Easing Page
  subgraph EASING[" EasingPage (ContentPage)\nTitle: Easing functions"]
    direction TB
    EASING_Root["VerticalStackLayout\nPadding:16, Spacing:16"]:::layout
    EASING_Root --> EASING_Header["Label: Easing comparison"]:::control
    EASING_Root --> EASING_Picker["Picker: Select easing"]:::control
    EASING_Root --> EASING_Run["Button: Run"]:::action
    EASING_Root --> EASING_Reset["Button: Reset"]:::action
    EASING_Root --> EASING_Dot["Border Dot\nBackgroundColor: Secondary\nSize: 24x24"]:::control
  end

  %% Custom Animations Page
  subgraph CUSTOM[" CustomAnimationsPage (ContentPage)\nTitle: Custom animations"]
    direction TB
    CUSTOM_Root["VerticalStackLayout\nPadding:16, Spacing:16"]:::layout
    CUSTOM_Root --> CUSTOM_Header["Label: Custom Animation"]:::control
    CUSTOM_Root --> CUSTOM_Ring["GraphicsView Ring\nDrawable: RingDrawable"]:::control
    CUSTOM_Root --> CUSTOM_Run["Button: Run"]:::action
    CUSTOM_Root --> CUSTOM_Reset["Button: Reset"]:::action
    CUSTOM_Root --> CUSTOM_Status["Label: Status"]:::control
  end

```
