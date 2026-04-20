using System;
using System.IO;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTests.Drivers;

namespace SauceDemoTests.Core
{
    public class TestBase : IDisposable
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected ILogger Logger;

        public TestBase()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            Logger = loggerFactory.CreateLogger<TestBase>();

            Driver = WebDriverFactory.CreateDriver(Logger);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public void Dispose()
        {
            Driver.Quit();
        }

        protected void CaptureScreenshot(string testName)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            Directory.CreateDirectory("Screenshots");
            var path = Path.Combine("Screenshots", $"{testName}.png");
            screenshot.SaveAsFile(path);
        }
    }
}