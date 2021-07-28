using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private readonly List<string> cssPseudoClasses;

        private readonly List<string> cssCombinators;

        private readonly List<string> cssClasses;

        private readonly List<string> cssAttributes;

        public override StringBuilder Selector { get; }

        public override StringBuilder RootSelector => GetRootSelector();

        public CssLocator(string tagName)
        {
            rootTagName = tagName;
            cssClasses = new List<string>();
            cssAttributes = new List<string>();
            cssPseudoClasses = new List<string>();
            cssCombinators = new List<string>();
        }

        public override ILocatorBuilder AtPosition(int index)
        {
            throw new NotImplementedException();
        }

        public override ILocatorBuilder Child()
        {
            cssCombinators.Add(" > *");

            return this;
        }

        public override ILocatorBuilder Child(ILocatorBuilder childLocator)
        {
            throw new NotImplementedException();
        }

        public override ILocatorBuilder Follows(ILocatorBuilder sibling)
        {
            throw new NotImplementedException();
        }

        public override ILocatorBuilder Inside(ILocatorBuilder parent)
        {
            Selector.Insert(0, ' ')
                    .Insert(0, parent.Selector.ToString());

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

        // private StringBuilder GetSelector()
        // {

        //     // return Selector.Append(GetRootSelector());
        //     // Selector = new StringBuilder();
        // }

        private StringBuilder GetRootSelector()
        {
            var rootSelector = new StringBuilder(rootTagName);

            if (!string.IsNullOrEmpty(cssId)) rootSelector.Append(cssId);

            rootSelector.AppendJoin("", cssAttributes);
            rootSelector.AppendJoin("", cssClasses);
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
