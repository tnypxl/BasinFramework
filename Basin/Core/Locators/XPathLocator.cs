using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Basin.Core.Locators
{
    public class XPathLocator : Locator
    {

        public override StringBuilder RootSelector { get; }

        public override StringBuilder Selector { get; }

        public XPathLocator(string tagName)
        {
            RootSelector.Append($"//{tagName})");
            // Selector = new StringBuilder(RootSelector.ToString());
            // Selector.Append(rootSelector);
        }

        public override ILocatorBuilder Inside(ILocatorBuilder parent)
        {
            Selector.Insert(0, parent.Selector);
            return this;
        }

        public override ILocatorBuilder WithText(string text, bool inclusive = true)
        {
            Selector.Append(GetXPathStringFunc(".", text, inclusive));

            return this;
        }

        public override ILocatorBuilder WithClass(string className, bool inclusive = true)
        {
            Selector.Append("[");

            if (!inclusive) Selector.Append("not(");

            Selector.Append("contains(concat(' ',normalize-space(@class),' '),' ")
                    .Append(className)
                    .Append(" ')");

            if (!inclusive) Selector.Append(")");

            Selector.Append("]");

            return this;
        }

        public override ILocatorBuilder WithClass(params string[] classNames)
        {
            for (int i = 0; i < classNames.Length; i++)
                classNames[i] = GetClassNameXPath(classNames[i]);

            Selector.Append("[")
                    .AppendJoin(" and ", classNames)
                    .Append("]");

            return this;
        }

        public override ILocatorBuilder WithId(string id, bool inclusive = true)
        {
            WithAttr("id", id, inclusive);

            return this;
        }

        public override ILocatorBuilder WithAttr(string name, bool inclusive = true)
        {
            Selector.Append("[");

            if (!inclusive) Selector.Append("not(");

            Selector.Append("@")
                    .Append(name);

            if (!inclusive) Selector.Append(")");

            Selector.Append(']');

            return this;
        }

        public override ILocatorBuilder WithAttr(string name, string value, bool inclusive = true)
        {
            Selector.Append(GetXPathStringFunc($"@{name}", value, inclusive));

            return this;
        }

        public override ILocatorBuilder WithChild(ILocatorBuilder child, bool inclusive = true)
        {
            Selector.Append("[");

            if (!inclusive) Selector.Append("not(");

            Selector.Append(".")
                    .Append(child.Selector.Remove(0, 1));

            if (!inclusive) Selector.Append(")");

            Selector.Append(']');

            return this;
        }

        public override ILocatorBuilder WithDescendant(ILocatorBuilder descendant, bool inclusive = true)
        {
            Selector.Append("[");

            if (!inclusive) Selector.Append("not(");

            Selector.Append(".")
                    .Append(descendant.Selector);

            if (!inclusive) Selector.Append(")");

            Selector.Append(']');

            return this;
        }

        public override ILocatorBuilder Parent()
        {
            Selector.Append("/parent::*");

            return this;
        }

        public override ILocatorBuilder Parent(ILocatorBuilder parentLocator)
        {
            Selector.Append("/parent::")
                    .Append(parentLocator.Selector.Remove(0, 2));

            return this;
        }

        public override ILocatorBuilder Child()
        {
            Selector.Append("/child::*");

            return this;
        }

        public override ILocatorBuilder Child(ILocatorBuilder childLocator)
        {
            Selector.Append("/child::")
                    .Append(childLocator.Selector.Remove(0, 2));

            return this;
        }

        public override ILocatorBuilder Follows(ILocatorBuilder sibling)
        {
            Selector.Remove(0, 2)
                    .Insert(0, "/following-sibling::")
                    .Insert(0, sibling.Selector);

            return this;
        }

        public override ILocatorBuilder Precedes(ILocatorBuilder sibling)
        {
            Selector.Remove(0, 2)
                    .Insert(0, "/preceding-sibling::")
                    .Insert(0, sibling.Selector);

            return this;
        }

        public override ILocatorBuilder AtPosition(int position)
        {
            Selector.Append("[")
                    .Append(position)
                    .Append("]");

            return this;
        }

        private static string GetClassNameXPath(string className)
        {
            var classNameXpath = new StringBuilder();
            bool exclude = Regex.IsMatch(className, "^!");

            if (exclude) classNameXpath.Append("not(");

            classNameXpath.Append("contains(concat(' ',normalize-space(@class),' '),' ")
                          .Append(className.Replace("!", ""))
                          .Append(" ')");

            if (exclude) classNameXpath.Append(")");

            return classNameXpath.ToString();
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
                _ => $@"{attrOrFuncName}=""{attrOrFuncValue}"""
            };

            return inclusive
                ? $"[{xPath}]"
                : $"[not({xPath})]";
        }
    }
}
