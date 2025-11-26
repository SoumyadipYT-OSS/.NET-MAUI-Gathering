# .NET-MAUI-Gathering
The .NET MAUI (Multi-platform App UI)  a cross-platform framework for delivering native experience mobile and desktop applications with C# in the backend and XAML in the frontend.


## What is .NET MAUI?
The .NET Multi-platform App UI (.NET MAUI) is a framework for building cross-platform applications using C# and XAML. 
It allows developers to create native applications for Android, iOS, macOS, and Windows from a single codebase. 
The .NET MAUI is the evolution of Xamarin.Forms and is part of the .NET ecosystem.

<img 
	src="pictures/NET_App_UI.png" 
	alt=".NET APP UI" 
	width="550" height="450" 
	/>

.NET MAUI represents the next evolution of cross-platform development, building upon the foundation of Xamarin.Forms. 
It is extending its capabilities beyond mobile to include desktop applications. Unlike its predecessor, .NET MAUI introduces 
 a unified project structure, enabling developers to target multiple platforms from a single codebase while still allwoing 
 platform-specific customization when needed. Its UI controls have been completely re-engineered for superor performance and 
 extensibility, ensuring modern, responsive experiences across devices. While developers familiar with Xamarin.Forms will 
 recognizee many concepts, .NET MAUI delivers a streamlined architecture and enhanced flexibility. The core vision behind 
 .NET MAUI is simple: maximize code sharing for both application logic and UI layout, empowering teams to deliver rich, 
 multi-platform applications efficiently and consistently.


 ## Who .NET MAUI is For
 .NET MAUI is designed for developers who aim to:
 - Build cross-platform applications using **XAML** and **C#** whithin a single, shared codebase in **Visual Studio**, **Rider**, **VsCode**. 

 - Maintain a consistent UI layout and design across multiple platforms while allowing for platform-specific customizations.
	
 - Reuse code, unit tests and business logic seamlessly across different operating systems.


 ## How .NET MAUI works
 With .NET 6 and later versions, Microsoft delivers a unified ecosystem of platform-specific frameworks for building modern 
 applications: .NET for Android, .NET for iOS, .NET for Mac Catalyst, Windows UI 3 (WinUI 3) and Tizen OS. These frameworks 
 share a common foundation - the .NET Base Class Library (BCL) - which abstracts platform-specific details, enabling developers 
 to write consistent, reusable business logic across devices.
 The BCL operates on top of the .NET runtime, which provides the execution environment for your applications. On Android, 
 iOS and macOS, this environment is powered by **Mono (.NET Runtime Libraries)**, a proven  implementation of the .NET runtime. 
 On Windows, Tizen the .NET Common Language Runtime (CLR) takes the lead.

 While the BCL ensures portability for core logic, user interface design remains inherently platform-specific. Each platform 
 offers unique UI paradigms and interaction models. Developers can choose to craft native UIs using the respective 
 frameworks - Android UI Toolkit, iOS UIKit, Mac Catalyst AppKit, WinUI 3 and Tizen NUI - to deliver optimal user experiences. 
 However, this approach often results in maintaining separate codebases for each device family.

 .NET MAUI provides a single framework for building the UIs for mobile and desktop apps. The following diagram 
 illustrates a high-level architecture of a .NET MAUI application:

 <img 
	src="pictures/Architecture_NETMaui.png"
	alt="Architecture of .NET MAUI Application"
	width="650" height="500"
	/>

_Architecture-diagram_

 <img 
	src="pictures/architecture-diagram.png"
	alt="Architecture diagram of .NET MAUI"
	width="650" height="500"
	/>

 In a .NET MAUI apps, your code primarily interacts with the .NET MAUI controls and API layer(1), which serves as the 
 abstraction for building cross-platform UIs. This layer communicates directly with the native platform APIs(3), 
 ensuring that your app delivers a truly native experience. When necessary, developers can also invoke 
 platform-specific APIs(2) directly for advanced customization.

 .NET MAUI apps can be developed on Windows or macOS and compiled into native application packages for each target 
 platform.

 - Android: Apps are compiled from C# into Intermediate Language (IL) and then Just-In-Time (JIT) compiled into native ARM or x86 at runtime.

 - iOS: Apps are Ahead-Of-Time (AOT) compiled from C# into native ARM code during the build process, as iOS does not support JIT compilation.

 - macOS: Apps can be either AOT compiled into native ARM or x86 code or run using JIT compilation, depending on the deployment method.

 - Windows: Apps are compiled from C# into Intermediate Language (IL) and then Just-In-Time (JIT) compiled into native x86 or ARM or x64 code at runtime.

 For more details on **WinUI 3**, refer to the official documentation: [WinUI Docs](https://learn.microsoft.com/en-us/windows/apps/winui/).