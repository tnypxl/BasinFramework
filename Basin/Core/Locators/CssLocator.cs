using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Internal;

namespace Basin.Core.Locators
{
    /*
        Methods that won't work as a CSS selector
            -> WithChild()
            -> WithDescendant()
            -> WithText()
            -> Parent()
    */
    public class CssLocator : Locator
    {
        private string cssId;

        private readonly string rootTagName;

        // private readonly List<string> cssCombinators;

        private readonly List<string> cssClasses;

        private readonly List<string> cssPseudoClasses;

        private readonly List<string> cssAttributes;

        private readonly List<string> leftCombinators;

        private readonly List<string> rightCombinators;

        public override StringBuilder Selector => GetSelector();

        public override StringBuilder RootSelector => GetRootSelector();

        public CssLocator(string tagName)
        {
            rootTagName = tagName;
            cssClasses = new List<string>();
            cssAttributes = new List<string>();
            cssPseudoClasses = new List<string>();
            leftCombinators = new List<string>();
            rightCombinators = new List<string>();
            // cssCombinators = new List<string>();
        }

        public override ILocatorBuilder AtPosition(int index)
        {
            cssPseudoClasses.Add($":nth-child({index})");

            return this;
        }

        public override ILocatorBuilder Child()
        {
            rightCombinators.Add(" > *");

            return this;
        }

        public override ILocatorBuilder Child(ILocatorBuilder childLocator)
        {
            rightCombinators.Add($" > {childLocator.Selector}");

            return this;
        }

        public override ILocatorBuilder Follows(ILocatorBuilder sibling)
        {
            leftCombinators.Add($"{sibling.Selector} ~ ");

            return this;
        }

        public override ILocatorBuilder Inside(ILocatorBuilder parent)
        {
            leftCombinators.Add($"{parent.Selector} ");

            return this;
        }

        public override ILocatorBuilder Parent()
        {
            throw new NotSupportedException("Locating a parent is not supported");
        }

        public override ILocatorBuilder Parent(ILocatorBuilder parentLocator)
        {
            throw new NotSupportedException("Locating a parent is not supported");
        }

        public override ILocatorBuilder Precedes(ILocatorBuilder sibling)
        {
            throw new NotSupportedException();
        }

        public override ILocatorBuilder WithAttr(string name, bool inclusive = true)
        {
            cssAttributes.Add($"[{name}]");

            return this;
        }

        public override ILocatorBuilder WithAttr(string name, string value, bool inclusive = true)
        {
            cssAttributes.Add($"[{name}='{value}']");

            return this;
        }

        public override ILocatorBuilder WithChild(ILocatorBuilder child, bool inclusive = true)
        {
            throw new NotSupportedException();
        }

        public override ILocatorBuilder WithClass(string className, bool inclusive = true)
        {
            cssClasses.Add(FormatCssClass(className));

            return this;
        }

        public override ILocatorBuilder WithClass(params string[] classNames)
        {
            foreach (var className in classNames) WithClass(className);

            return this;
        }

        public override ILocatorBuilder WithDescendant(ILocatorBuilder descendant, bool inclusive = true)
        {
            throw new NotSupportedException();
        }

        public override ILocatorBuilder WithId(string id, bool inclusive = true)
        {
            cssId = FormatCssId(id);

            return this;
        }

        private StringBuilder GetSelector()
        {
            var selector = new StringBuilder(GetRootSelector().ToString());

            selector = AddLeftCombinators(selector);
            selector = AddRightCombinators(selector);

            return selector;
        }

        private StringBuilder AddRightCombinators(StringBuilder selector)
        {
            foreach (var combinator in rightCombinators)
                selector.Append(combinator);

            return selector;
        }

        private StringBuilder AddLeftCombinators(StringBuilder selector)
        {
            foreach (var combinator in leftCombinators)
                selector.Insert(0, combinator);

            return selector;
        }

        private StringBuilder GetRootSelector()
        {
            var rootSelector = new StringBuilder(rootTagName);

            if (!string.IsNullOrEmpty(cssId)) rootSelector.Append(cssId);

            rootSelector.AppendJoin("", cssAttributes);
            rootSelector.AppendJoin("", cssClasses);
            rootSelector.AppendJoin("", cssPseudoClasses);
            // rootSelectorHistory.Add(rootSelector);

            return rootSelector;
        }

        public override ILocatorBuilder WithText(string text, bool inclusive = true)
        {
            throw new NotSupportedException();
        }

        private static string FormatCssClass(string className)
        {
            if (className.StartsWith(".")) return className;

            return $".{className}";
        }

        private static string FormatCssId(string id)
        {
            if (id.StartsWith("#")) return id;

            return "#" + id;
        }
    }
}
