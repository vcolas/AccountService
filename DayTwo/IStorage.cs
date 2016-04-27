using System.Collections.Generic;

namespace DayTwo
{
    public interface IStorage
    {
        void Insert(AccountTransaction transaction);
        IEnumerable<AccountTransaction> GetAllTransactions();
    }
}