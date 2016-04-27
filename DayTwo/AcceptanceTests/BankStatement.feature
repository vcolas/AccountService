Feature: BankStatement
		Deposit into Account
		Withdraw from an Account
		Print a bank statement to the console.
  
Scenario: Print a bank statement
	Given I have deposited an amount of '1000' dollars into my account
	When I withdraw '100' dollars from my account
	Then the balance should be '900' dollars
