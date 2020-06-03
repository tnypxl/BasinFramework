using System.Text;
using System.Text.RegularExpressions;
using Basin.Core.Locators.Interfaces;
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

        private static bool StartsWithOperator(string str) => Regex.IsMatch(str, @"^(\^|\$|\*){1}");

        private static string GetXPathAttribute(string attrName, string attrValue)
        {
            string xPath;
            string modAttrValue;
            var op = Regex.Match(attrValue, @"^(\^|\$|\*){1}").Value;
            
            modAttrValue = string.IsNullOrEmpty(op) ? attrValue : attrValue.Remove(0, 1); // Remove operator if present

            switch (op)
            {
                case "^":
                    xPath = $"[starts-with(@{attrName}, '{modAttrValue}')]";
                    break;
                case "$":
                    // Can't use ends-with because Selenium 3 doesn't use XPath 2.0.
                    // So we have to make this unholy mess to get the same behavior in XPath 1.0
                    xPath = $"[substring(@{attrName}, string-length(@{attrName}) - string-length('{modAttrValue}') +1)]";
                    break;
                case "*":
                    xPath = $"[contains(@{attrName}, '{modAttrValue}')]";
                    break;
                default:
                    xPath = $"[@{attrName}='{modAttrValue}']";
                    break;
            }

            return xPath;
        }
    }
}