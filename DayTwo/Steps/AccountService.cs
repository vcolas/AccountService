using System;

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

        public void Deposit(int amount)
        {
            _storage.Insert(new AccountTransaction(amount));
        }

        public void Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }
    }
}