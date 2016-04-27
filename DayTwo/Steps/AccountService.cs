using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DayTwo
{
    public class AccountService
    {
        private readonly IPrinterSystem _printerSystem;
        private readonly IStorage _storage;

        public AccountService(IPrinterSystem printerSystem, IStorage storage)
        {
            _printerSystem = printerSystem;
            _storage = storage;
        }

        public void Deposit(decimal amount)
        {
            _storage.Insert(new AccountTransaction(amount, DateTime.Now));
        }

        public void Withdraw(decimal amount)
        {
            _storage.Insert(new AccountTransaction(-amount, DateTime.Now));
        }

        public void PrintStatement()
        {
            IEnumerable<AccountTransaction> transactions = _storage.GetAllTransactions();
            _printerSystem.PrintLine("DATE | AMOUNT | BALANCE");
            var transactionsOrdered = transactions.OrderByDescending(t => t.Date).ToList();
            decimal balance = 0;
            foreach (var accountTransaction in transactionsOrdered)
            {
                balance += accountTransaction.Amount;
                _printerSystem.PrintLine(string.Format("{0} | {1} | {2}", accountTransaction.Date.ToString("d"), accountTransaction.Amount.ToString("F2"), balance.ToString("F2")));
            }
        }
    }
}