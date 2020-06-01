using System.Text;
using System.Text.RegularExpressions;
using Basin.Core.Locators.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Core.Locators
{
    public sealed class Locator : ILocatorBuilder
    {
        public By By => By.XPath(XPath.ToString());

        public StringBuilder XPath { get; }

        public Locator(string tagName)
        {
            var rootXPath = $"//{tagName}";
            XPath = new StringBuilder();
            XPath.Append(rootXPath);
        }

        public ILocatorBuilder Inside(ILocatorBuilder parent)
        {
            XPath.Insert(0, parent.XPath);
            return this;
        }

        public ILocatorBuilder WithText(string text)
        {
            XPath.Append($"[contains(.,'{text}')]");
            return this;
        }

        public ILocatorBuilder WithClass(string className)
        {
            XPath.Append($"[contains(concat(' ',normalize-space(@class),' '),' {className} ')]");
            return this;
        }

        public ILocatorBuilder WithId(string id)
        {
            var op = string.Empty;

            if (IdHasOperator(id))
                op = Regex.Match(id, @"^(\^|\~|\$|\||\*){1}").Value;

            XPath.Append($"[@id{op}='{id}']");
            return this;
        }

        public ILocatorBuilder WithAttr(string name, string value)
        {
            XPath.Append($"[@{name}='{value}']");
            return this;
        }

        public ILocatorBuilder WithChild(ILocatorBuilder child)
        {
            // XPath axis is descendant (e.g, "//") by default
            // We need to remove one axis to make it a child
            // "//div" becomes "/div"
            var childXPath = child.XPath;
            childXPath.Remove(0, 1);

            XPath.Append($"[.{childXPath}]");
            return this;
        }

        public ILocatorBuilder WithDescendant(ILocatorBuilder descendant)
        {
            XPath.Append($"[{descendant.XPath}]");
            return this;
        }

        private static bool IdHasOperator(string id) => Regex.IsMatch(id, @"^(\^|\~|\$|\||\*){1}");
    }
}