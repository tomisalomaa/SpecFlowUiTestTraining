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
        private const string SwagProductUrl = "https://www.saucedemo.com/inventory.html";
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

        public string GetInventoryItemName()
        {
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile("C://ImageCart.png", ScreenshotImageFormat.Png);
            return _driver.FindElement(By.ClassName("inventory_item_name")).Text;
        }

        public string GetInventoryItemPrice()
        {
            return _driver.FindElement(By.ClassName("inventory_item_price")).Text;
        }

        public void NavigateToCart()
        {
            ShoppingCartContainer.Click();
            _wait.Until(ExpectedConditions.UrlToBe("https://www.saucedemo.com/cart.html"));
        }
    }
}
