using Basin.Core.Locators;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Basin.Tests
{
    public class XPathLocatorTests : TestBase
    {
        private Locator _div, _span, _unorderedList, _listItem;

        [SetUp]
        public void SetUp()
        {
            _div = new XPathLocator("div");
            _span = new XPathLocator("span");
            _unorderedList = new XPathLocator("ul");
            _listItem = new XPathLocator("li");
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathWithARootTagName()
        {
            const string expectedXPath = "//div";

            Assert.That(_div.Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathWithAnHtmlClassAttributeAndValue()
        {
            const string expectedXPath = "//div[contains(concat(' ',normalize-space(@class),' '),' foo ')]";

            Assert.That(_div.WithClass("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathWithHtmlClassAttributeAndValueAsNonInclusive()
        {
            const string expectedXPath = "//div[not(contains(concat(' ',normalize-space(@class),' '),' foo '))]";

            Assert.That(_div.WithClass("foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathWithMultipleHtmlClassAttributeAndValues()
        {
            var expectedCssClassXPaths = string.Join(" and ",
                "contains(concat(' ',normalize-space(@class),' '),' foo ')",
                "contains(concat(' ',normalize-space(@class),' '),' bar ')",
                "not(contains(concat(' ',normalize-space(@class),' '),' baz '))");

            var expectedXPath = $"//div[{expectedCssClassXPaths}]";

            Assert.That(_div.WithClass("foo", "bar", "!baz").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithHtmlIdAttributeAndValue()
        {
            const string expectedXPath = @"//div[@id=""foo""]";

            Assert.That(_div.WithId("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[@myattr=""foo""]";

            Assert.That(_div.WithAttr("myattr", "foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsNonInclusiveSelectorWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[not(@myattr=""foo"")]";

            Assert.That(_div.WithAttr("myattr", "foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithHtmlAttribute()
        {
            const string expectedXPath = "//div[@myattr]";

            Assert.That(_div.WithAttr("myattr").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsNonInclusiveSelectorWithHtmlAttribute()
        {
            const string expectedXPath = "//div[not(@myattr)]";

            Assert.That(_div.WithAttr("myattr", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithAChildSelector()
        {
            const string expectedXPath = "//div[./span]";

            Assert.That(_div.WithChild(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsNonInclusiveSelectorWithAChildSelector()
        {
            const string expectedXPath = "//div[not(./span)]";

            Assert.That(_div.WithChild(_span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithADescendantSelector()
        {
            const string expectedXPath = "//div[.//span]";

            Assert.That(_div.WithDescendant(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsNonInclusiveSelectorWithADescendantSelector()
        {
            const string expectedXPath = "//div[not(.//span)]";

            Assert.That(_div.WithDescendant(_span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathForParentOfSelector()
        {
            const string expectedXPath = "//div/parent::*";

            Assert.That(_div.Parent().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathForSpecificParentOfSelector()
        {
            const string expectedXPath = "//span/parent::div";

            Assert.That(_span.Parent(_div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathForChildSelector()
        {
            const string expectedXPath = "//div/child::*";

            Assert.That(_div.Child().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsXPathForSpecificChildSelector()
        {
            const string expectedXPath = "//div/child::span";

            Assert.That(_div.Child(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorAtPostionInListOfMatchingSelectors()
        {
            const string expectedXPath = "//div[4]";

            Assert.That(_div.AtPosition(4).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorThatFollowsAnotherSelector()
        {
            const string expectedXPath = "//ul/following-sibling::div";

            Assert.That(_div.Follows(_unorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorThatPrecedesAnotherSelector()
        {
            const string expectedXPath = "//ul/preceding-sibling::div";

            Assert.That(_div.Precedes(_unorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorThatIsInsideAnotherSelector()
        {
            const string expectedXPath = "//div//span";

            Assert.That(_span.Inside(_div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test, Category("Unit")]
        public void XPathLocatorBuildsSelectorWithText()
        {
            const string expectedExactTextXPath = @"//span[.=""foo bar, baz?""]";
            const string expectedStartsWithTextXPath = @"//ul[starts-with(., ""foo"")]";
            const string expectedEndsWithTextXPath = @"//div[contains(., ""foo"") and not(normalize-space(substring-after(., ""foo"")))]";
            const string expectedContainsTextXPath = @"//li[contains(., ""foo"")]";

            Assert.That(_span.WithText("foo bar, baz?").Selector.ToString(), Is.EqualTo(expectedExactTextXPath));
            Assert.That(_unorderedList.WithText("^|foo").Selector.ToString(), Is.EqualTo(expectedStartsWithTextXPath));
            Assert.That(_div.WithText("$|foo").Selector.ToString(), Is.EqualTo(expectedEndsWithTextXPath));
            Assert.That(_listItem.WithText("*|foo").Selector.ToString(), Is.EqualTo(expectedContainsTextXPath));
        }

        // [Test, Category("Unit")]
        // public void XPathLocatorReturnsSeleniumByObject()
        // {
        //     var expectedBy =  By.XPath("//div");

        //     Assert.That(_div.By, Is.EqualTo(expectedBy));
        // }
    }
}
