using Basin.Core.Locators;

namespace Basin.Core.Elements
{
    public class ElementDecorator : Element
    {
        protected Element _element;

        public override ILocatorBuilder Locator => _element.Locator;

        public ElementDecorator(Element element) => _element = element;

        public void SetElement(Element element) => _element = element;

        public override Element Child() => _element.Child();

        public override Element Child(Element targetElement) => _element.Child(targetElement);

        public override Element Following(Element siblingElement) => _element.Following(siblingElement);

        public override Element Parent() => _element.Parent();

        public override Element Parent(Element targetElement) => _element.Parent(targetElement);

        public override Element Preceding(Element siblingElement) => _element.Preceding(siblingElement);

        public override Element Inside(Element parentElement) => _element.Inside(parentElement);

        public override Element WithAttr(string attributeName, bool inclusive = true) => _element.WithAttr(attributeName, inclusive);

        public override Element WithAttr(string attributeName, string attributeValue, bool inclusive = true) => _element.WithAttr(attributeName, attributeValue, inclusive);

        public override Element WithChild(Element childElement, bool inclusive = true) => _element.WithChild(childElement, inclusive);

        public override Element WithClass(string className, bool inclusive = true) => _element.WithClass(className, inclusive);

        public override Element WithClass(params string[] classNames) => _element.WithClass(classNames);

        public override Element WithDescendant(Element descendantElement, bool inclusive = true) => _element.WithDescendant(descendantElement, inclusive);

        public override Element WithId(string id, bool inclusive = true) => _element.WithId(id, inclusive);

        public override Element WithText(string text, bool inclusive = true) => _element.WithText(text, inclusive);
    }
}
