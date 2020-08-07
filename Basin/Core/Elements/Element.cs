using Basin.Core.Locators;

namespace Basin.Core.Elements
{
    public abstract class Element
    {
        public abstract ILocatorBuilder Locator { get; }

        public abstract Element Inside(Element parentElement);

        public abstract Element WithClass(string className, bool inclusive = true);

        public abstract Element WithClass(params string[] classNames);

        public abstract Element WithId(string id, bool inclusive = true);

        public abstract Element WithAttr(string attributeName, bool inclusive = true);

        public abstract Element WithAttr(string attributeName, string attributeValue, bool inclusive = true);

        public abstract Element WithText(string text, bool inclusive = true);

        public abstract Element WithDescendant(Element descendantElement, bool inclusive = true);

        public abstract Element WithChild(Element childElement, bool inclusive = true);

        public abstract Element Parent();

        public abstract Element Parent(Element targetElement);

        public abstract Element Child();

        public abstract Element Child(Element targetElement);

        public abstract Element Following(Element siblingElement);

        public abstract Element Preceding(Element precedingElement);
    }
}
