## Handlers

Handlers are the platform bridge in .NET MAUI that map cross-platform "virtual" views to the underlying native views on each platform. A handler is responsible for:

- Instantiating the native control (the `PlatformView`).
- Mapping cross-platform properties and commands to native APIs via mappers.
- Exposing the cross-platform element as `VirtualView` so the handler can apply state from the MAUI control.

For most built-in controls there is a corresponding interface (for example `IButton`) and a handler (for example `ButtonHandler`) that provides property and command mappers. Using handlers keeps the cross-platform control API decoupled from platform-specific implementations and makes it straightforward to customize native behavior.

Key concepts

- Mappers: `PropertyMapper` and `CommandMapper` are dictionaries that associate cross-platform properties or commands with Actions that update the native view. Mappers are the primary extension point for customizing behavior without subclassing.
- Lifecycle: Controls raise `HandlerChanging` before a handler is replaced or removed, and `HandlerChanged` after a handler is created and properties applied. Override `OnHandlerChanging` and `OnHandlerChanged` on controls to run platform-aware logic.
- Platform access: Use the handler's `PlatformView` to call native APIs, wire native events, or change platform-only properties.

Customize and extend

- Customize existing controls globally by modifying the handler mappers at app startup.
- Create custom controls with handlers when you need full control over native behavior. See the official guides: "Create custom controls with handlers" and "Customize .NET MAUI controls with handlers".

Common built-in handlers

.NET MAUI provides handlers for most views and pages (for example `LabelHandler`, `EntryHandler`, `CollectionViewHandler`, `PageHandler`, etc.). Each handler exposes a `Mapper` that you can inspect or extend.

Further reading

- https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/?view=net-maui-10.0
- https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/create?view=net-maui-10.0
- https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/customize?view=net-maui-10.0

This summary is based on the official .NET MAUI handlers documentation (NET 10).