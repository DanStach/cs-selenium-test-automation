using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver, WebDriverWait wait, ILogger logger)
            : base(driver, wait, logger) { }

        public bool IsAt()
        {
            return Wait.Until(d => d.Url.Contains("inventory.html"));
        }
    }
}