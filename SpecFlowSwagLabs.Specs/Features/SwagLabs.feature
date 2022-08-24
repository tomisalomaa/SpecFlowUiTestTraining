Feature: SwagLabs

@login
Scenario: Login as standard user
	Given the user navigates to login page
	And enters username standard_user
	And enters password secret_sauce
	When the login button is clicked
	Then the user should be redirected to https://www.saucedemo.com/inventory.html