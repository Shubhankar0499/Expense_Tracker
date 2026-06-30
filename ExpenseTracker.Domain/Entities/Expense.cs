using System;
using System.Collections.Generic;
using System.Text;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }


        public string Title { get; set; } = string.Empty;


        public decimal Amount { get; set; }


        public DateTime Date { get; set; }


        public int CategoryId { get; set; }


        public Category Category { get; set; } = null!;


        public int UserId { get; set; }


        public User User { get; set; } = null!;
    }
}
