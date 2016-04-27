using FakeItEasy;
using TechTalk.SpecFlow;

namespace DayTwo
{
    [Binding]
    public class BankStatementSteps
    {
        private static AccountService accountService;
        private static IPrinterSystem printerSystem;
        private static IStorage storage;

        [BeforeTestRun]
        public static void Setup()
        {
            //accountStore = new AccountStore();
            printerSystem = new PrinterSystem();
            storage = new Storage();
            accountService = new AccountService(printerSystem,storage);
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
