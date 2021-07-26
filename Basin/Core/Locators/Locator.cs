using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Basin.Core.Locators
{
    public abstract class Locator : ILocatorBuilder
    {
        public abstract StringBuilder RootSelector { get; }

        public abstract StringBuilder Selector { get; }

        public abstract ILocatorBuilder AtPosition(int index);

        public abstract ILocatorBuilder Child();

        public abstract ILocatorBuilder Child(ILocatorBuilder childLocator);

        public abstract ILocatorBuilder Follows(ILocatorBuilder sibling);

        public abstract ILocatorBuilder Inside(ILocatorBuilder parent);

        public abstract ILocatorBuilder Parent();

        public abstract ILocatorBuilder Parent(ILocatorBuilder parentLocator);

        public abstract ILocatorBuilder Precedes(ILocatorBuilder sibling);

        public abstract ILocatorBuilder WithAttr(string name, bool inclusive = true);

        public abstract ILocatorBuilder WithAttr(string name, string value, bool inclusive = true);

        public abstract ILocatorBuilder WithChild(ILocatorBuilder child, bool inclusive = true);

        public abstract ILocatorBuilder WithClass(string className, bool inclusive = true);

        public abstract ILocatorBuilder WithClass(params string[] classNames);

        public abstract ILocatorBuilder WithDescendant(ILocatorBuilder descendant, bool inclusive = true);

        public abstract ILocatorBuilder WithId(string id, bool inclusive = true);

        public abstract ILocatorBuilder WithText(string text, bool inclusive = true);
    }
}
