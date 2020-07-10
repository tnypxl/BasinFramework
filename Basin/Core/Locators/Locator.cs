using System.Xml.XPath;
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
            XPath.Append(GetXPathStringFunc(".", text));

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
            WithAttr("id", id);

            return this;
        }

        public ILocatorBuilder WithAttr(string name)
        {
            XPath.Append("[@")
                 .Append(name)
                 .Append(']');

            return this;
        }

        public ILocatorBuilder WithAttr(string name, string value)
        {
            XPath.Append(GetXPathStringFunc($"@{name}", value));

            return this;
        }

        public ILocatorBuilder WithChild(ILocatorBuilder child)
        {

            var newChildXPath = child.XPath;

            // XPath axis is descendant (e.g, "//") by default
            // We need to remove one axis to make it a child
            // "//div" becomes "/div"
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

        public ILocatorBuilder Parent()
        {
            XPath.Append("/parent::*");

            return this;
        }

        public ILocatorBuilder After(ILocatorBuilder sibling)
        {
            XPath.Append(sibling.XPath)
                 .Append("/following-sibling::")
                 .Append(XPath);

            return this;
        }

        public ILocatorBuilder Before(ILocatorBuilder sibling)
        {
            XPath.Append(sibling.XPath)
                 .Append("/preceding-sibling::")
                 .Append(XPath);

            return this;
        }

        private static string GetXPathStringFunc(string attrOrFuncName, string attrOrFuncValue)
        {
            var op = Regex.Match(attrOrFuncValue, @"^(\^|\$|\*){1}").Value;

            attrOrFuncValue = string.IsNullOrEmpty(op) ? attrOrFuncValue : attrOrFuncValue.Remove(0, 1);

            return op
            switch
            {
                "^" => $"[starts-with({attrOrFuncName}, '{attrOrFuncValue}')]",

                // Can't use ends-with because Selenium 3 doesn't use XPath 2.0.
                // So we have to make this unholy mess to get the same behavior with XPath 1.0
                "$" => $"[substring({attrOrFuncName}, string-length({attrOrFuncName}) - string-length('{attrOrFuncValue}') +1)]",
                "*" => $"[contains({attrOrFuncName}, '{attrOrFuncValue}')]",
                _ => $"[{attrOrFuncName}='{attrOrFuncValue}']",
            };
        }
    }
}