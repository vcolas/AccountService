using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayTwo
{
    [TestClass]
    public class AccountServiceShould
    {
        [TestMethod]
        public void store_a_transaction_when_depositing_money()
        {
            var amount = 100;
            var printerSytem = A.Fake<IPrinterSystem>();
            var storage = A.Fake<IStorage>();
            var accountService = new AccountService(printerSytem, storage);

            accountService.Deposit(amount);

            A.CallTo(() => storage.Insert(A<AccountTransaction>.That.Matches(a => a.Amount == amount))).MustHaveHappened();
            //A.CallTo(()=> storage.Insert(A<AccountTransaction>.Ignored)).MustHaveHappened();
            //A.CallTo(()=> storage.Insert(new AccountTransaction(amount))).WithAnyArguments().MustHaveHappened();
        }
    }
}
