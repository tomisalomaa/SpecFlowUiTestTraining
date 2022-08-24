Feature: SwagLabs

@login
Scenario Outline: Login as standard user
	Given user navigates to login page
	And enters username <User>
	And enters password secret_sauce
	When login button is clicked
	Then user should be redirected to <Url>

Examples:
	| User            | Url                                      |
	| standard_user   | https://www.saucedemo.com/inventory.html |
	| locked_out_user | https://www.saucedemo.com/               |

@purchase
Scenario Outline: Purchase a product as standard user
	Given user has logged in
	When <Item name> is added to cart
	And user navigates to cart view
	And user continues to checkout
	And enters proper postal information
	And continues to verify order
	And continues to complete purchase
	Then purchase is complete
	And cart should be empty


Examples:
	| Item name                         |
	| Sauce Labs Backpack               |
	| Sauce Labs Bike Light             |
	| Sauce Labs Bolt T-Shirt           |
	| Sauce Labs Fleece Jacket          |
	| Sauce Labs Onesie                 |
	| Test.allTheThings() T-Shirt (Red) |

@cart
Scenario Outline: Place product to shopping cart
	Given user has logged in
	When <Item name> is added to cart
	And user navigates to cart view
	Then cart items include <Item name>
	And item price is <Item price>

Examples:
	| Item name                         | Item price   |
	| Sauce Labs Backpack               | $29.99       |
	| Sauce Labs Bike Light             | $9.99        |
	| Sauce Labs Bolt T-Shirt           | $15.99       |
	| Sauce Labs Fleece Jacket          | $49.99       |
	| Sauce Labs Onesie                 | $7.99        |
	| Test.allTheThings() T-Shirt (Red) | $15.99       |

@cart
Scenario Outline: Remove product from shopping cart
	Given user has logged in
	And has added <Item name> to cart
	When user clicks the <Item name> remove button on inventory page
	Then cart should be empty
	And option to add <Item name> to cart should be available

Examples:
	| Item name                         |
	| Sauce Labs Backpack               |
	| Sauce Labs Bike Light             |
	| Sauce Labs Bolt T-Shirt           |
	| Sauce Labs Fleece Jacket          |
	| Sauce Labs Onesie                 |
	| Test.allTheThings() T-Shirt (Red) |