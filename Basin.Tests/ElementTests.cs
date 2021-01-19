using System;
using Basin.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Basin.Tests
{
    public class ElementTests : TestBase
    {
        [SetUp]
        public void ElementTestSetUp()
        {
        }

        [Test, Category("Integration")]
        public void ElementIsAnInstanceOfIWebElement()
        {
            var element = new Element();

            Assert.That(element, Is.InstanceOf<IWebElement>());
        }

        [Test, Category("Integration")]
        public void ElementIsInstantiatedWithATagName()
        {
            var element = new Element("div");
            Assert.That(element.FoundBy.ToString(), Does.EndWith("derp"));
        }
    }
}
