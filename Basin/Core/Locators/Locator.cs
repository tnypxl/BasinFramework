using System;
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
            XPath.Append(GetXPathAttribute("id", id));
            return this;
        }

        public ILocatorBuilder WithAttr(string name, string value)
        {
            XPath.Append(GetXPathAttribute(name, value));
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

        private static bool StartsWithOperator(string str) => Regex.IsMatch(str, @"^^(\^|\$|\*){1}");

        private static string GetXPathAttribute(string attr, string str)
        {

            var xPathAttr = string.Empty;

            if (StartsWithOperator(str))
            {
                var op = Regex.Match(str, @"^(\^|\$|\*){1}").Value;
                var newStr = str.Remove(0, 1); // Remove operator

                switch (op)
                {
                    case "^":
                        xPathAttr = $"[starts-with(@{attr}, '{newStr}')]";
                        break;
                    case "$":
                        xPathAttr = $"[ends-with(@{attr}, '{newStr}')]";
                        break;
                    case "*":
                        xPathAttr = $"[contains(@{attr}, '{newStr}')]";
                        break;
                    default:
                        xPathAttr = $"[@{attr}='{newStr}']";
                        break;
                }
            }

            return xPathAttr;
        }
    }
}