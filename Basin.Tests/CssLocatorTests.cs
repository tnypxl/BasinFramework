using System;
using System.Security.Policy;
using Basin.Core.Locators;
using NUnit.Framework;

namespace Basin.Tests
{
    public class CssLocatorTests : TestBase
    {
        private Locator _div, _span, _unorderedList, _listItem;

        [SetUp]
        public void SetUp()
        {
            _div = new CssLocator("div");
            _span = new CssLocator("span");
            _unorderedList = new CssLocator("ul");
            _listItem = new CssLocator("li");
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithARootTagName()
        {
            const string expectedSelector = "div";

            Assert.That(_div.Selector.ToString(), Is.EqualTo(expectedSelector));
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithAnHtmlAttribute()
        {
            const string expectedSelector = "div[name]";

            Assert.That(_div.WithAttr("name").Selector.ToString(), Is.EqualTo(expectedSelector));
        }

        // [Test, Category("Unit")]
        // public void CssLocatorBuildsSelectorWithAnHtmlMultipleAttributes()
        // {
        //     const string expectedSelector = "div[class]";

        //     Assert.That(_div.WithAttr("class").Selector.ToString(), Is.EqualTo(expectedSelector));
        // }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithClass()
        {
            const string expectedSelector = "div.foo";

            Assert.That(_div.WithClass("foo").Selector.ToString(), Is.EqualTo(expectedSelector));
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithMultipleClasses()
        {
            const string expectedSelector = "div.derp.bar.baz";

            Assert.That(_div.WithClass("foo", "bar", "baz").Selector.ToString(), Is.EqualTo(expectedSelector));
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithId()
        {
            const string expectedSelector = "div#foo";

            Assert.That(_div.WithId("foo").Selector.ToString(), Is.EqualTo(expectedSelector));
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithIdAndClassAndAttribute()
        {
            const string expectedSelector = "div#foo[data-someAttr].bar";

            Assert.That(
                _div.WithId("foo")
                    .WithClass("bar")
                    .WithAttr("data-someAttr").Selector.ToString(),
                Is.EqualTo(expectedSelector));
        }

        [Test, Category("Unit")]
        public void CssLocatorBuildsSelectorWithCombinatorsAndOtherAttributes()
        {
            const string expectedSelector = "div ul#foo[name]";

            Assert.That(
                _unorderedList.WithAttr("name")
                              .Inside(_div)
                              .WithId("foo").Selector
                              .ToString(),
                Is.EqualTo(expectedSelector));
        }
    }
}