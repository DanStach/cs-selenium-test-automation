using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        protected readonly ILogger Logger;

        protected BasePage(IWebDriver driver, WebDriverWait wait, ILogger logger)
        {
            Driver = driver;
            Wait = wait;
            Logger = logger;
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(d =>
            {
                var el = d.FindElement(locator);
                return el.Displayed ? el : null;
            });
        }

        protected void Click(By locator) => WaitForElement(locator).Click();

        protected void Type(By locator, string text)
        {
            var el = WaitForElement(locator);
            el.Clear();
            el.SendKeys(text);
        }
    }
}