using FakeItEasy;
using TechTalk.SpecFlow;

namespace DayTwo.TDD
{
    [Binding]
    public class BankStatementSteps
    {
        private AccountService accountService;
        private PrinterSystem printerSystem;

        [BeforeTestRun]
        public void Setup()
        {
            //accountStore = new AccountStore();
            printerSystem = new PrinterSystem();
            accountService = new AccountService(printerSystem);
        }

        [Given(@"I have deposited an amount of '(.*)' dollars into my account")]
        public void GivenIHaveDepositedAnAmountOfDollarsIntoMyAccount(int amount)
        {
            accountService.Deposit(amount);
        }
        
        [When(@"I withdraw '(.*)' dollars from my account")]
        public void WhenIWithdrawDollarsFromMyAccount(int amount)
        {
            accountService.Withdraw(amount);
        }
        
        [Then(@"the balance should be '(.*)' dollars")]
        public void ThenTheBalanceShouldBeDollars(int balance)
        {
            accountService.PrintStatement();
            A.CallTo(() => printerSystem.PrintLine("BALANCE 900")).MustHaveHappened();
            A.CallTo(() => printerSystem.PrintLine("BALANCE 900")).MustHaveHappened();
            A.CallTo(() => printerSystem.PrintLine("BALANCE 900")).MustHaveHappened();
        }
    }
}
