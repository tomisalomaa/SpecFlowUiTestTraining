using System;
using System.Security.Policy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SpecFlowSwagLabs.Specs.PageObjects
{
    public class LoginPage
    {
        private const string SwagUrl = "https://www.saucedemo.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        // SwagLabs login page elements
        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public void EnterUsername(string username)
        {
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        { 
            LoginButton.Click();
        }

        public string GetCurrentUrl(string url)
        {
            _wait.Until(ExpectedConditions.UrlToBe(url));
            return _driver.Url;
        }

        public void NavigateToSwagLabs()
        {
            _driver.Navigate().GoToUrl(SwagUrl);
        }
    }
}
