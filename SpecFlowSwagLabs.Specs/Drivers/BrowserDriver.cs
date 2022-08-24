using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowSwagLabs.Specs.Drivers
{
    /*
     * This driver class is based on:
     * https://docs.specflow.org/projects/specflow/en/latest/ui-automation/Selenium-with-Page-Object-Pattern.html
     * 
     */
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        // Define driver
        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        // Sets Selenium web driver instance
        public IWebDriver Current => _currentWebDriverLazy.Value;

        // Create selenium web driver to open browser
        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            return chromeDriver;
        }

        // Closes the web driver
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }
            _isDisposed = true;
        }
    }
}
