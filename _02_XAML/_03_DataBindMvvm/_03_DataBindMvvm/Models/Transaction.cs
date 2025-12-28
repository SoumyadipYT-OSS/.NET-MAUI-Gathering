using System;

namespace _03_DataBindMvvm.Models;

/// <summary>
/// Simple transaction model that could be displayed in a list.
/// </summary>
public class Transaction
{
    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;
}

