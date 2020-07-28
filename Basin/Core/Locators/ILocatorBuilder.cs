using System.Text;
using OpenQA.Selenium;

namespace Basin.Core.Locators
{
    public interface ILocatorBuilder
    {
        By By { get; }

        StringBuilder XPath { get; }

        ILocatorBuilder Inside(ILocatorBuilder parent);

        ILocatorBuilder WithText(string text);

        ILocatorBuilder WithClass(string className);

        ILocatorBuilder WithId(string id);

        ILocatorBuilder WithAttr(string name);

        ILocatorBuilder WithAttr(string name, string value);

        ILocatorBuilder WithChild(ILocatorBuilder child);

        ILocatorBuilder WithDescendant(ILocatorBuilder descendant);

        ILocatorBuilder Child();

        ILocatorBuilder Child(ILocatorBuilder childLocator);

        ILocatorBuilder Parent();

        ILocatorBuilder Parent(ILocatorBuilder parentLocator);

        ILocatorBuilder Precedes(ILocatorBuilder sibling);

        ILocatorBuilder Follows(ILocatorBuilder sibling);
    }
}