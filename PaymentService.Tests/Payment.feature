Feature: Payment
	In order to pay for a product or a service
	As a customer
	I want to transfer money between accounts

@smoke
@positive
Scenario: Transfer funds from common account
	Given Sender account has 50 dollars
		And Recipient account has 20 dollars
	When Payment service transfers 10 dollars from Sender account to Recipient account
	Then Audit system was notified about success
		And Sender account has 40 dollars
		And Recipient account has 30 dollars

@negative
Scenario: Not enough funds on common account
	Given Sender account has 30 dollars
		And Recipient account has 20 dollars
	When Payment service transfers 50 dollars from Sender account to Recipient account
	Then Audit system was notified about failure
		And Sender account has 30 dollars
		And Recipient account has 20 dollars

# ToDo
#Scenario: Transfer funds from overdraft account
		
