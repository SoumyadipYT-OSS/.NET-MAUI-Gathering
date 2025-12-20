# XAML
The XAML _(eXensible Application Markup Language)_ is an XML based markup language designed to simplify the creation and configuration of objects in .NET 
applications. Instead of writing extensive programming code, XAML enables developers to define objects and arrange them in parent-child hierarchies using a clean, 
declarative syntax.

In *.NET Multi-platform App UI (.NET MAUI)*, XAML is the preferred way to build user interfaces. While it's not mandatorv. XAML offers several advantages: 
	it's more concise, visually structured and supported by powerful design-time tools. This makes it ideal for implementing the *Model-View-ViewModel (MVVM)* 
	pattern, where XAML defines the view and seamlessly binds it to the viewmodel through data binding.

A XAML file can include all .NET MAUI components - views, layouts, pages -> as well as custom controls. These files can be compiled or embedded within the 
application package. During build time, XAML is parsed to identify named elements and runtime, the corresponding objects are instantiated and initialized, 
bringing your UI to life.


**XAML offers distinct advantages compared to writing equivalent UI code:**
- It's typically *more concise* and *easier to read*, reducing boilerplate and improving clarity.
- Thanks to its XML-based structure, XAML naturally reflects the parent-child hierarchy of UI elements, providing a clear, visual representation 
of the interface layout.

** XAML also comes with certain limitations, which are typical of markup languages:**
- *No inline code:* Event handlers must be implemented in a seperate code-behind file.
- *No loops for repetitive tasks:* While XAML doesn't support loops, controls like `CollectionView`. > **⚠️ Important:** In .NET MAUI 10, `ListView` is deprecated. 
- *No conditional logic:* XAML lacks native support for conditional statements. However, you can achieve similar functionality using data binding with converters or
- *Constructor restrictions:* XAML requires a parameterless constructor for instantiating objects. If your class lacks one, you'll need to provide a default constructor.
- *Cannot call all methods directly:* Invoking methods from XAML is typically not supported, but certain techniques can bypass this limitation.


.NET MAUI does not include a visual designer for XAML, so all XAML must be written manually. However, you can take advantage of 
_XAML Hot Reload_ to instantly preview changes as you edit, making the development process faster and more interactive.
		Although XAML is based XML, it introduces several unique syntax features that enhance UI development:
			- **Property Elements:** Allow setting complex properties using nested elements.
			- **Attached Properties:** Enable child elements to set properties on parent elements.
			- **Markup Extensions:** Provide dynamic values for properties using special syntax.
		
		These are not XML extensions - they simply use XML in innovative ways. Importantly, XAML remains fully 
		compliant with XML standards while providing powerful capabilities for building rich user interfaces.