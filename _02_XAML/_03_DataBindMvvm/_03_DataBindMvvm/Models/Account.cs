namespace _03_DataBindMvvm.Models;

/// <summary>
/// Simple account model to demonstrate how viewmodels can work with multiple models.
/// </summary>
public class Account
{
    public string AccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}

