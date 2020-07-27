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
            // XPath axis is descendant (e.g, "//") by default
            // We need to remove one axis to make it a child
            // Ergo, "//div" becomes "/div"
            XPath.Append("[.")
                 .Append(child.XPath.Remove(0, 1))
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

        public ILocatorBuilder Parent(ILocatorBuilder parentLocator)
        {
            XPath.Append("/parent::")
                 .Append(parentLocator.XPath.Remove(0, 2));

            return this;
        }

        public ILocatorBuilder Child()
        {
            XPath.Append("/child::*");

            return this;
        }

        public ILocatorBuilder Child(ILocatorBuilder childLocator)
        {
            XPath.Append("/child::")
                 .Append(childLocator.XPath.Remove(0, 2));

            return this;
        }

        /// <summary>
        /// Locate an element that follows another element
        /// </summary>
        /// <param name="sibling" type="ILocatorBuilder"></param>
        /// <returns>//sibling-element/preceding-sibling::element</returns>
        public ILocatorBuilder Follows(ILocatorBuilder sibling)
        {
            XPath.Remove(0, 2)
                 .Insert(0, "/following-sibling::")
                 .Insert(0, sibling.XPath);

            return this;
        }

        /// <summary>
        /// Locate an element that precedes another element
        /// </summary>
        /// <param name="sibling"></param>
        /// <returns>//siblingElement/preceding-sibling::element</returns>
        public ILocatorBuilder Precedes(ILocatorBuilder sibling)
        {
            XPath.Remove(0, 2)
                 .Insert(0, "/preceding-sibling::")
                 .Insert(0, sibling.XPath);

            return this;
        }

        // private static bool RemoveAxes(StringBuilder xPath)
        // {
        //     // var numberOfPrefixedAxes =
        //     if (Regex.IsMatch(xPath.ToString(), "/"))
        //         return false;
        // }

        private static string GetXPathStringFunc(string attrOrFuncName, string attrOrFuncValue)
        {
            var op = Regex.Match(attrOrFuncValue, @"^(\^\||\$\||\*\|){1}").Value;

            // Remove operator if the string contains one
            attrOrFuncValue = string.IsNullOrEmpty(op)
                ? attrOrFuncValue
                : attrOrFuncValue.Remove(0, 2);

            return op switch
            {
                "^|" => $@"[starts-with({attrOrFuncName}, ""{attrOrFuncValue}"")]",

                // Can't use ends-with because Selenium 3 doesn't use XPath 2.0.
                // So we have to make this unholy mess to get the same behavior with XPath 1.0
                "$|" => $@"[substring({attrOrFuncName}, string-length({attrOrFuncName}) - string-length(""{attrOrFuncValue}"") +1)]",
                "*|" => $@"[contains({attrOrFuncName}, ""{attrOrFuncValue}"")]",
                _ => $@"[{attrOrFuncName}=""{attrOrFuncValue}""]",
            };
        }
    }
}