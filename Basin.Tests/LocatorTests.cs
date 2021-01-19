using Basin.Core.Locators;
using NUnit.Framework;

namespace Basin.Tests
{
    public class LocatorTests
    {
        private Locator _div, _span, _unorderedList, _listItem;

        [SetUp]
        public void SetUp()
        {
            _div = new Locator("div");
            _span = new Locator("span");
            _unorderedList = new Locator("ul");
            _listItem = new Locator("li");
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithARootTagName()
        {
            const string expectedXPath = "//div";

            Assert.That(_div.Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithAnHtmlClassAttributeAndValue()
        {
            const string expectedXPath = "//div[contains(concat(' ',normalize-space(@class),' '),' foo ')]";

            Assert.That(_div.WithClass("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithHtmlClassAttributeAndValueAsNonInclusive()
        {
            const string expectedXPath = "//div[not(contains(concat(' ',normalize-space(@class),' '),' foo '))]";

            Assert.That(_div.WithClass("foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithMultipleHtmlClassAttributeAndValues()
        {
            var expectedCssClassXPaths = string.Join(" and ",
                "contains(concat(' ',normalize-space(@class),' '),' foo ')",
                "contains(concat(' ',normalize-space(@class),' '),' bar ')",
                "not(contains(concat(' ',normalize-space(@class),' '),' baz '))");

            var expectedXPath = $"//div[{expectedCssClassXPaths}]";

            Assert.That(_div.WithClass("foo", "bar", "!baz").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlIdAttributeAndValue()
        {
            const string expectedXPath = @"//div[@id=""foo""]";

            Assert.That(_div.WithId("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[@myattr=""foo""]";

            Assert.That(_div.WithAttr("myattr", "foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[not(@myattr=""foo"")]";

            Assert.That(_div.WithAttr("myattr", "foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlAttribute()
        {
            const string expectedXPath = "//div[@myattr]";

            Assert.That(_div.WithAttr("myattr").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithHtmlAttribute()
        {
            const string expectedXPath = "//div[not(@myattr)]";

            Assert.That(_div.WithAttr("myattr", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithAChildElement()
        {
            const string expectedXPath = "//div[./span]";

            Assert.That(_div.WithChild(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithAChildElement()
        {
            const string expectedXPath = "//div[not(./span)]";

            Assert.That(_div.WithChild(_span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithADescendantElement()
        {
            const string expectedXPath = "//div[.//span]";

            Assert.That(_div.WithDescendant(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithADescendantElement()
        {
            const string expectedXPath = "//div[not(.//span)]";

            Assert.That(_div.WithDescendant(_span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForParentOfElement()
        {
            const string expectedXPath = "//div/parent::*";

            Assert.That(_div.Parent().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForSpecificParentOfElement()
        {
            const string expectedXPath = "//span/parent::div";

            Assert.That(_span.Parent(_div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForChildElement()
        {
            const string expectedXPath = "//div/child::*";

            Assert.That(_div.Child().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForSpecificChildElement()
        {
            const string expectedXPath = "//div/child::span";

            Assert.That(_div.Child(_span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementAtAnIndexPosition()
        {
            const string expectedXPath = "//div[4]";

            Assert.That(_div.AtPosition(4).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatFollowsAnotherElement()
        {
            const string expectedXPath = "//ul/following-sibling::div";

            Assert.That(_div.Follows(_unorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatPrecedesAnotherElement()
        {
            const string expectedXPath = "//ul/preceding-sibling::div";

            Assert.That(_div.Precedes(_unorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatIsInsideAnotherElement()
        {
            const string expectedXPath = "//div//span";

            Assert.That(_span.Inside(_div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithText()
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
    }
}
