using Basin.Core.Locators;
using System;

namespace Basin.Core.Elements
{
    public class ElementBase : Element
    {
        public override ILocatorBuilder Locator { get; }

        public ElementBase(string tagName)
        {
            Locator = new Locator(tagName);
        }

        public override Element Inside(Element parent)
        {
            Locator.Inside(parent.Locator);

            return this;
        }

        public override Element WithText(string text, bool inclusive = true)
        {
            Locator.WithText(text, inclusive);

            return this;
        }

        public override Element WithClass(string className, bool inclusive = true)
        {
            Locator.WithClass(className, inclusive);

            return this;
        }

        public override Element WithClass(params string[] classNames)
        {
            throw new NotImplementedException();
        }

        public override Element WithId(string id, bool inclusive = true)
        {
            Locator.WithId(id, inclusive);

            return this;
        }

        public override Element WithAttr(string name, bool inclusive = true)
        {
            Locator.WithAttr(name, inclusive);

            return this;
        }

        public override Element WithAttr(string name, string value, bool inclusive = true)
        {
            Locator.WithAttr(name, value, inclusive);

            return this;
        }

        public override Element WithChild(Element childElement, bool inclusive = true)
        {
            Locator.WithChild(childElement.Locator, inclusive);

            return this;
        }

        public override Element WithDescendant(Element descendantElement, bool inclusive = true)
        {
            Locator.WithDescendant(descendantElement.Locator, inclusive);

            return this;
        }

        public override Element Parent()
        {
            Locator.Parent();

            return this;
        }

        public override Element Parent(Element targetElement)
        {
            Locator.Parent(targetElement.Locator);

            return this;
        }

        public override Element Child()
        {
            Locator.Child();

            return this;
        }

        public override Element Child(Element targetElement)
        {
            Locator.Child(targetElement.Locator);

            return this;
        }

        public override Element Preceding(Element siblingElement)
        {
            Locator.Precedes(siblingElement.Locator);

            return this;
        }

        public override Element Following(Element siblingElement)
        {
            Locator.Follows(siblingElement.Locator);

            return this;
        }
    }
}
