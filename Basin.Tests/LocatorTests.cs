using Basin.Core.Locators;
using NUnit.Framework;

namespace Basin.Tests
{
    public class LocatorTests
    {
        public Locator Div, Span, UnorderedList, ListItem;

        [SetUp]
        public void SetUp()
        {
            Div = new Locator("div");
            Span = new Locator("span");
            UnorderedList = new Locator("ul");
            ListItem = new Locator("li");
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithARootTagName()
        {
            const string expectedXPath = "//div";

            Assert.That(Div.Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithAnHtmlClassAttributeAndValue()
        {
            const string expectedXPath = "//div[contains(concat(' ',normalize-space(@class),' '),' foo ')]";

            Assert.That(Div.WithClass("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathWithHtmlClassAttributeAndValueAsNonInclusive()
        {
            const string expectedXPath = "//div[not(contains(concat(' ',normalize-space(@class),' '),' foo '))]";

            Assert.That(Div.WithClass("foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
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

            Assert.That(Div.WithClass("foo", "bar", "!baz").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlIdAttributeAndValue()
        {
            const string expectedXPath = @"//div[@id=""foo""]";

            Assert.That(Div.WithId("foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[@myattr=""foo""]";

            Assert.That(Div.WithAttr("myattr", "foo").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithHtmlAttributeAndValue()
        {
            const string expectedXPath = @"//div[not(@myattr=""foo"")]";

            Assert.That(Div.WithAttr("myattr", "foo", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithHtmlAttribute()
        {
            const string expectedXPath = "//div[@myattr]";

            Assert.That(Div.WithAttr("myattr").Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithHtmlAttribute()
        {
            const string expectedXPath = "//div[not(@myattr)]";

            Assert.That(Div.WithAttr("myattr", false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithAChildElement()
        {
            const string expectedXPath = "//div[./span]";

            Assert.That(Div.WithChild(Span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithAChildElement()
        {
            const string expectedXPath = "//div[not(./span)]";

            Assert.That(Div.WithChild(Span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithADescendantElement()
        {
            const string expectedXPath = "//div[.//span]";

            Assert.That(Div.WithDescendant(Span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsNonInclusiveXPathForElementWithADescendantElement()
        {
            const string expectedXPath = "//div[not(.//span)]";

            Assert.That(Div.WithDescendant(Span, false).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForParentOfElement()
        {
            const string expectedXPath = "//div/parent::*";

            Assert.That(Div.Parent().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForSpecificParentOfElement()
        {
            const string expectedXPath = "//span/parent::div";

            Assert.That(Span.Parent(Div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForChildElement()
        {
            const string expectedXPath = "//div/child::*";

            Assert.That(Div.Child().Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForSpecificChildElement()
        {
            const string expectedXPath = "//div/child::span";

            Assert.That(Div.Child(Span).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementAtAnIndexPosition()
        {
            const string expectedXPath = "//div[4]";

            Assert.That(Div.AtPosition(4).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatFollowsAnotherElement()
        {
            const string expectedXPath = "//ul/following-sibling::div";

            Assert.That(Div.Follows(UnorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatPrecedesAnotherElement()
        {
            const string expectedXPath = "//ul/preceding-sibling::div";

            Assert.That(Div.Precedes(UnorderedList).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementThatIsInsideAnotherElement()
        {
            const string expectedXPath = "//div//span";

            Assert.That(Span.Inside(Div).Selector.ToString(), Is.EqualTo(expectedXPath));
        }

        [Test]
        [Category("Unit")]
        public void LocatorBuildsXPathForElementWithText()
        {
            const string expectedExactTextXPath = @"//span[.=""foo bar, baz?""]";
            const string expectedStartsWithTextXPath = @"//ul[starts-with(., ""foo"")]";
            const string expectedEndsWithTextXPath = @"//div[contains(., ""foo"") and not(normalize-space(substring-after(., ""foo"")))]";
            const string expectedContainsTextXPath = @"//li[contains(., ""foo"")]";

            Assert.That(Span.WithText("foo bar, baz?").Selector.ToString(), Is.EqualTo(expectedExactTextXPath));
            Assert.That(UnorderedList.WithText("^|foo").Selector.ToString(), Is.EqualTo(expectedStartsWithTextXPath));
            Assert.That(Div.WithText("$|foo").Selector.ToString(), Is.EqualTo(expectedEndsWithTextXPath));
            Assert.That(ListItem.WithText("*|foo").Selector.ToString(), Is.EqualTo(expectedContainsTextXPath));
        }
    }
}
