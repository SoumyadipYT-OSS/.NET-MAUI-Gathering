
namespace ExpenseApp.Models 
{
    public sealed class Expense 
    {
        public decimal Amount { get; }
        public string Category { get; }
        public DateTime CreatedAt { get; }
        public string Details { get; set; }


        public Expense(decimal amount, string category, DateTime? createdAt = null, string? details = null) 
        {
            Amount = amount;
            Category = category ?? string.Empty;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            Details = details;
        }

        public override string ToString() 
        {
            return $"{Category} - {Amount:C} ({CreatedAt:g})";
        }
    }
}