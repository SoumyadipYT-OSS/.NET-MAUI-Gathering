namespace _03_DataBindMvvm.Models;

/// <summary>
/// Simple person model used as a binding source in the UI.
/// Models are kept free of UI concepts and represent domain data only.
/// </summary>
public class Person
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }
}