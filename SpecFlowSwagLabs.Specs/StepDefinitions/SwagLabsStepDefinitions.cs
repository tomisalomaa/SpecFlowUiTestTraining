using SpecFlowSwagLabs.Specs.Drivers;
using SpecFlowSwagLabs.Specs.PageObjects;
using System;
using System.Security.Policy;

namespace SpecFlowSwagLabs.Specs.StepDefinitions
{
    [Binding]
    public sealed class SwagLabsStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;

        public SwagLabsStepDefinitions(BrowserDriver driver)
        {
            _loginPage = new LoginPage(driver.Current);
            _productPage = new ProductPage(driver.Current);
        }

        [Given("user has logged in")]
        public void GivenUserHasLoggedIn()
        {
            _loginPage.NavigateToSwagLabs();
            _loginPage.EnterUsername("standard_user");
            _loginPage.EnterPassword("secret_sauce");
            _loginPage.ClickLogin();
            _loginPage.GetCurrentUrl("https://www.saucedemo.com/inventory.html")
                .Should().Be("https://www.saucedemo.com/inventory.html");
        }

        [Given("user navigates to login page")]
        public void GivenUserNavigatesToLoginPage()
        {
            _loginPage.NavigateToSwagLabs();
        }

        [Given("enters username (.*)")]
        public void GivenUsernameIs(string username)
        {
            _loginPage.EnterUsername(username);
        }

        [Given("enters password (.*)")]
        public void GivenPasswordIs(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [Given("has added (.*) to cart")]
        public void GivenItemIsAddedToCart(string item)
        {
            _productPage.AddToCart(item);
        }

        [When("login button is clicked")]
        public void WhenLoginButtonIsClicked()
        {
            _loginPage.ClickLogin();
        }

        [When("(.*) is added to cart")]
        public void WhenItemIsAddedToCart(string item)
        {
            _productPage.AddToCart(item);
        }

        [When("user navigates to cart view")]
        public void WhenUserNavigatesToCart()
        {
            _productPage.NavigateToCart();
        }

        [When("user clicks the (.*) remove button on inventory page")]
        public void WhenRemoveItemIsClicked(string item)
        {
            _productPage.RemoveFromCartInventory(item);
        }

        [When("user continues to checkout")]
        public void WhenUserNavigatesToCheckout()
        {
            _productPage.NavigateToCheckout();
        }

        [When("enters proper postal information")]
        public void WhenUserEntersProperPostalInformation()
        {
            _productPage.FillPostalInformation();
        }

        [When("continues to verify order")]
        public void WhenUserContinuesToVerifyOrder()
        {
            _productPage.ContinueToVerify();
        }

        [When("continues to complete purchase")]
        public void WhenUserContinuesToComplete()
        {
            _productPage.ContinueToComplete();
        }

        [Then("user should be redirected to (.*)")]
        public void ThenUserShouldBeRedirectedTo(string url)
        {
            _loginPage.GetCurrentUrl(url).Should().Be(url);
        }

        [Then("cart items include (.*)")]
        public void CartIncludesItem(string item)
        {
            _productPage.GetInventoryItemName().Should().Be(item);
        }

        [Then("item price is (.*)")]
        public void CartIncludesItemPrice(string price)
        {
            _productPage.GetInventoryItemPrice().Should().Be(price);
        }

        [Then("cart should be empty")]
        public void ShoppingCartIsEmpty()
        {
            _productPage.GetShoppingCartItemCount().Should().Be(0);
        }

        [Then("option to add (.*) to cart should be available")]
        public void AddToCartAvailable(string item)
        {
            if (_productPage.GetCurrentUrl() != "https://www.saucedemo.com/inventory.html")
            {
                _productPage.NavigateToInventory();
            }
            _productPage.AddToCart(item);
        }

        [Then("purchase is complete")]
        public void PurchaseComplete()
        {
            _productPage.GetCurrentUrl().Should().Be("https://www.saucedemo.com/checkout-complete.html");
        }
    }
}