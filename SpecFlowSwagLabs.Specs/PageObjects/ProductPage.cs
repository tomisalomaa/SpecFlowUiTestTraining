using System;
using System.Diagnostics;
using System.Security.Policy;
using Gherkin.CucumberMessages.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecFlowSwagLabs.Specs.PageObjects
{
    public class ProductPage
    {
        private const string SwagCartUrl = "https://www.saucedemo.com/cart.html";
        private const string SwagInventoryUrl = "https://www.saucedemo.com/inventory.html";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        // SwagLabs product page elements
        private IWebElement AddBackpack => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement AddBikeLight => _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement AddBoltTShirt => _driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement AddFleeceJacket => _driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        private IWebElement AddOnesie => _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        private IWebElement AddThingsTShirt => _driver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)"));
        private IWebElement ShoppingCartContainer => _driver.FindElement(By.Id("shopping_cart_container"));

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public void AddToCart(string item)
        {
            switch (item)
            {
                case "Sauce Labs Backpack":
                    AddBackpack.Click();
                    break;
                case "Sauce Labs Bike Light":
                    AddBikeLight.Click();
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    AddBoltTShirt.Click();
                    break;
                case "Sauce Labs Fleece Jacket":
                    AddFleeceJacket.Click();
                    break;
                case "Sauce Labs Onesie":
                    AddOnesie.Click();
                    break;
                case "Test.allTheThings() T-Shirt (Red)":
                    AddThingsTShirt.Click();
                    break;
            }
        }

        public void RemoveFromCartInventory(string item)
        {
            switch (item)
            {
                case "Sauce Labs Backpack":
                    _driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
                    break;
                case "Sauce Labs Bike Light":
                    _driver.FindElement(By.Id("remove-sauce-labs-bike-light")).Click();
                    break;
                case "Sauce Labs Bolt T-Shirt":
                    _driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt")).Click();
                    break;
                case "Sauce Labs Fleece Jacket":
                    _driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket")).Click();
                    break;
                case "Sauce Labs Onesie":
                    _driver.FindElement(By.Id("remove-sauce-labs-onesie")).Click();
                    break;
                case "Test.allTheThings() T-Shirt (Red)":
                    _driver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)")).Click();
                    break;
            }
        }

        public string GetInventoryItemName()
        {
            return _driver.FindElement(By.ClassName("inventory_item_name")).Text;
        }

        public string GetInventoryItemPrice()
        {
            return _driver.FindElement(By.ClassName("inventory_item_price")).Text;
        }

        public void NavigateToCart()
        {
            ShoppingCartContainer.Click();
            _wait.Until(ExpectedConditions.UrlToBe(SwagCartUrl));
        }

        public void NavigateToInventory()
        {
            _driver.Navigate().GoToUrl(SwagInventoryUrl);
            _wait.Until(ExpectedConditions.UrlToBe(SwagInventoryUrl));
        }

        public int GetShoppingCartItemCount()
        {
            _driver.Navigate().GoToUrl(SwagCartUrl);
            return _driver.FindElements(By.ClassName("cart_item")).Count;
        }

        public void NavigateToCheckout()
        {
            if (GetCurrentUrl() != SwagCartUrl)
            {
                NavigateToCart();
            }
            _driver.FindElement(By.Id("checkout")).Click();
            _wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/checkout-step-one.html"));
        }

        public void FillPostalInformation()
        {
            if (GetCurrentUrl() == "https://www.saucedemo.com/checkout-step-one.html")
            {
                _driver.FindElement(By.Id("first-name")).SendKeys("standard");
                _driver.FindElement(By.Id("last-name")).SendKeys("user");
                _driver.FindElement(By.Id("postal-code")).SendKeys("12345");
            }
        }

        public void ContinueToVerify()
        {
            if (GetCurrentUrl() == "https://www.saucedemo.com/checkout-step-one.html")
            {
                _driver.FindElement(By.Id("continue")).Click();
                _wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/checkout-step-two.html"));
            }
        }

        public void ContinueToComplete()
        {
            if (GetCurrentUrl() == "https://www.saucedemo.com/checkout-step-two.html")
            {
                _driver.FindElement(By.Id("finish")).Click();
                _wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/checkout-complete.html"));
            }
        }
    }
}
