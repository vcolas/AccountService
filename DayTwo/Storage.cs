using System.Collections.Generic;

namespace DayTwo
{
    public class Storage : IStorage
    {
        List<AccountTransaction> Transactions = new List<AccountTransaction>();
        public void Insert(AccountTransaction transaction)
        {
            Transactions.Add(transaction);
        }

        public IEnumerable<AccountTransaction> GetAllTransactions()
        {
            return Transactions;
        }
    }
}