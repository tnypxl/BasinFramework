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
            XPath.Append("[contains(.,'")
                 .Append(text)
                 .Append("')]");

            return this;
        }

        public ILocatorBuilder WithClass(string className)
        {
            XPath.Append("[contains(concat(' ',normalize-space(@class),' '),' ")
                 .Append(className)
                 .Append(" ')]");
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
            var newChildXPath = child.XPath;
            newChildXPath.Remove(0, 1);

            XPath.Append("[.")
                 .Append(newChildXPath)
                 .Append(']');

            return this;
        }

        public ILocatorBuilder WithDescendant(ILocatorBuilder descendant)
        {
            XPath.Append("[.")
                 .Append(descendant.XPath)
                 .Append(']');

            return this;
        }

        private static string GetXPathAttribute(string attrName, string attrValue)
        {
            string modAttrValue;
            var op = Regex.Match(attrValue, @"^(\^|\$|\*){1}").Value;

            modAttrValue = string.IsNullOrEmpty(op) ? attrValue : attrValue.Remove(0, 1); // Remove operator if present

            return op
            switch
            {
                "^" => $"[starts-with(@{attrName}, '{modAttrValue}')]",
                "$" => $"[substring(@{attrName}, string-length(@{attrName}) - string-length('{modAttrValue}') +1)]", // Can't use ends-with because Selenium 3 doesn't use XPath 2.0.
                // So we have to make this unholy mess to get the same behavior in XPath 1.0
                "*" => $"[contains(@{attrName}, '{modAttrValue}')]",
                _ => $"[@{attrName}='{modAttrValue}']",
            };
        }
    }
}