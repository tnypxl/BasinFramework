using System.IO;
using System.Linq;
using Basin.PageObjects;
using Basin.PageObjects.Interfaces;
using Basin.Selenium;
using Basin.Tests.PageObjects;
using NUnit.Framework;

namespace Basin.Tests
{
    public class TestBase
    {
        protected IPageCollection Pages { get; } = new PageCollection();

        private readonly string _configPath = Path.GetFullPath(Path.Combine(@"../../..", "TheInternet.json"));

        private static bool IsIntegrationTest => TestContext.CurrentContext.Test.Properties["Category"].Contains("Integration");

        [SetUp]
        public void BaseSetUp()
        {
            if (!IsIntegrationTest) return;

            BasinEnv.SetConfig(_configPath);
            BrowserSession.Init();
            BrowserSession.Goto(BasinEnv.Site.Url);

            Pages.Add(new HomePage());
            Pages.Add(new AddRemoveElementsExamplePage());
            Pages.Add(new LargeAndDeepDomExamplePage());
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (!IsIntegrationTest) return;

            BrowserSession.Quit();
        }
    }
}
