using System;

namespace DayTwo
{
    public class AccountTransaction
    {
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }

        public AccountTransaction(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}