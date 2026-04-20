using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTests.Config;

namespace SauceDemoTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By UsernameInput = By.Id("user-name");
        private readonly By PasswordInput = By.Id("password");
        private readonly By LoginButton = By.Id("login-button");

        public LoginPage(IWebDriver driver, WebDriverWait wait, ILogger logger)
            : base(driver, wait, logger) { }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(TestConfig.BaseUrl);
        }

        public void Login(string username, string password)
        {
            Type(UsernameInput, username);
            Type(PasswordInput, password);
            Click(LoginButton);
        }
    }
}