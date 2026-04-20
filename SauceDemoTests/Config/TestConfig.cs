using System.IO;
using Microsoft.Extensions.Configuration;

namespace SauceDemoTests.Config
{
    public static class TestConfig
    {
        public static IConfigurationRoot Configuration { get; }

        static TestConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string BaseUrl => Configuration["TestSettings:BaseUrl"];
        public static string Username => Configuration["TestSettings:Username"];
        public static string Password => Configuration["TestSettings:Password"];
        public static string Browser => Configuration["TestSettings:Browser"] ?? "chrome";
        public static bool Headless => bool.Parse(Configuration["TestSettings:Headless"] ?? "false");
    }
}