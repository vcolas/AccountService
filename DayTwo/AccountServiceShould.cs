using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void store_a_negative_transaction_when_withdraw_money()
        {
            var amount = 100;
            var printerSytem = A.Fake<IPrinterSystem>();
            var storage = A.Fake<IStorage>();
            var accountService = new AccountService(printerSytem, storage);

            accountService.Withdraw(amount);

            A.CallTo(() => storage.Insert(A<AccountTransaction>.That.Matches(a => a.Amount == -amount))).MustHaveHappened();            
        }

        [TestMethod]
        public void print_balance_100_when_account_balance_is_100()
        {
            var amount = 100;
            var printerSystem = A.Fake<IPrinterSystem>();
            var storage = A.Fake<IStorage>();
            A.CallTo(() => storage.GetAllTransactions()).Returns(new List<AccountTransaction>() { new AccountTransaction(amount, new DateTime(2016, 4, 1)) });
            var accountService = new AccountService(printerSystem, storage);

            accountService.Deposit(amount);

            accountService.PrintStatement();

            A.CallTo(() => printerSystem.PrintLine("DATE | AMOUNT | BALANCE")).MustHaveHappened();            
            A.CallTo(() => printerSystem.PrintLine("01/04/2016 | 100,00 | 100,00")).MustHaveHappened();
        }


    }
}
