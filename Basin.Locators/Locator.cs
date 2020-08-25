using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Basin.Locators
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

        public ILocatorBuilder WithText(string text, bool inclusive = true)
        {
            XPath.Append(GetXPathStringFunc(".", text, inclusive));

            return this;
        }

        public ILocatorBuilder WithClass(string className, bool inclusive = true)
        {
            XPath.Append("[");

            if (!inclusive) XPath.Append("not(");

            XPath.Append("contains(concat(' ',normalize-space(@class),' '),' ")
                 .Append(className)
                 .Append(" ')");

            if (!inclusive) XPath.Append(")");

            XPath.Append("]");

            return this;
        }

        public ILocatorBuilder WithId(string id, bool inclusive = true)
        {
            WithAttr("id", id, inclusive);

            return this;
        }

        public ILocatorBuilder WithAttr(string name, bool inclusive = true)
        {
            XPath.Append("[");

            if (!inclusive) XPath.Append("not(");

            XPath.Append("@")
                 .Append(name);

            if (!inclusive) XPath.Append(")");

            XPath.Append(']');

            return this;
        }

        public ILocatorBuilder WithAttr(string name, string value, bool inclusive = true)
        {
            XPath.Append(GetXPathStringFunc($"@{name}", value, inclusive));

            return this;
        }

        public ILocatorBuilder WithChild(ILocatorBuilder child, bool inclusive = true)
        {
            XPath.Append("[");

            if (!inclusive) XPath.Append("not(");

            XPath.Append(".")
                 .Append(child.XPath.Remove(0, 1));

            if (!inclusive) XPath.Append(")");

            XPath.Append(']');

            return this;
        }

        public ILocatorBuilder WithDescendant(ILocatorBuilder descendant, bool inclusive = true)
        {
            XPath.Append("[");

            if (!inclusive) XPath.Append("not(");

            XPath.Append(".")
                 .Append(descendant.XPath);

            if (!inclusive) XPath.Append(")");

            XPath.Append(']');

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

        public ILocatorBuilder Follows(ILocatorBuilder sibling)
        {
            XPath.Remove(0, 2)
                 .Insert(0, "/following-sibling::")
                 .Insert(0, sibling.XPath);

            return this;
        }

        public ILocatorBuilder Precedes(ILocatorBuilder sibling)
        {
            XPath.Remove(0, 2)
                 .Insert(0, "/preceding-sibling::")
                 .Insert(0, sibling.XPath);

            return this;
        }

        private static string GetXPathStringFunc(string attrOrFuncName, string attrOrFuncValue, bool inclusive = true)
        {
            var op = Regex.Match(attrOrFuncValue, @"^(\^\||\$\||\*\|){1}").Value;

            // Remove operator if the string contains one
            attrOrFuncValue = string.IsNullOrEmpty(op)
                ? attrOrFuncValue
                : attrOrFuncValue.Remove(0, 2);

            var xPath = op switch
            {
                "^|" => $@"starts-with({attrOrFuncName}, ""{attrOrFuncValue}"")",

                // Can't use ends-with because Selenium 3 doesn't use XPath 2.0.
                // So we have to make this unholy mess to get the same behavior with XPath 1.0
                "$|" => $@"contains({attrOrFuncName}, ""{attrOrFuncValue}"") and not(normalize-space(substring-after({attrOrFuncName}, ""{attrOrFuncValue}"")))",
                "*|" => $@"contains({attrOrFuncName}, ""{attrOrFuncValue}"")",
                _ => $@"{attrOrFuncName}=""{attrOrFuncValue}""",
            };

            return inclusive
                ? $"[{xPath}]"
                : $"[not({xPath})]";
        }
    }
}