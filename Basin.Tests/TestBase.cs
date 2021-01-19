using System.IO;
using System.Linq;
using Basin.Selenium;
using NUnit.Framework;

namespace Basin.Tests
{
    public class TestBase
    {
        private readonly string _configPath = Path.GetFullPath(Path.Combine(@"../../..", "TheInternet.json"));

        private bool _isIntegrationTest;

        [SetUp]
        public void BaseSetUp()
        {
            _isIntegrationTest = TestContext.CurrentContext.Test.Properties["Category"].Contains("Integration");

            if (!_isIntegrationTest) return;

            BasinEnv.SetConfig(_configPath);
            BrowserSession.Init();
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (!_isIntegrationTest) return;

            BrowserSession.Quit();
        }
    }
}
