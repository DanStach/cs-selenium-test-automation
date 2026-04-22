using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SauceDemoTests.Config;

namespace SauceDemoTests.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(ILogger logger)
        {
            return TestConfig.Browser.ToLower() switch
            {
                "edge" => CreateEdge(),
                _ => CreateChrome()
            };
        }

        private static IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            if (TestConfig.Headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-gpu");
            }

            return new ChromeDriver(options); // Selenium Manager handles driver
        }

        private static IWebDriver CreateEdge()
        {
            var options = new EdgeOptions();

            if (TestConfig.Headless)
                options.AddArgument("--headless=new");

            return new EdgeDriver(options); // Selenium Manager handles driver
        }
    }
}