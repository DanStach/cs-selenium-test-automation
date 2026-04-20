using Xunit;
using SauceDemoTests.Core;
using SauceDemoTests.Pages;
using SauceDemoTests.Config;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 4)]

namespace SauceDemoTests.Tests
{
    public class LoginTests : TestBase
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void Login_With_Valid_Credentials_Should_Navigate_To_Inventory()
        {
            var loginPage = new LoginPage(Driver, Wait, Logger);
            var inventoryPage = new InventoryPage(Driver, Wait, Logger);

            try
            {
                RetryHelper.Retry(() =>
                {
                    loginPage.Navigate();
                    loginPage.Login(TestConfig.Username, TestConfig.Password);
                });

                Assert.True(inventoryPage.IsAt());
            }
            catch
            {
                CaptureScreenshot(nameof(Login_With_Valid_Credentials_Should_Navigate_To_Inventory));
                throw;
            }
        }
    }
}