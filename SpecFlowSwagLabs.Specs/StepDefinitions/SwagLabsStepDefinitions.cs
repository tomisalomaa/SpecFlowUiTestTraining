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
    }
}