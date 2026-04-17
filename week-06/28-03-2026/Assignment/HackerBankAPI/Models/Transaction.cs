using System;

namespace HackerBankAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Type { get; set; }
        public double Amount { get; set; }
        public string Balance { get; set; } = string.Empty;
    }
}