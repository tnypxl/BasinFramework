namespace Basin.Core.Elements
{
    public abstract class Element
    {
        public abstract void Click();

        public abstract void SendKeys();

        public abstract bool Displayed { get; }

        public abstract string Text { get; }

        public abstract Element WithClass(string className);

        public abstract Element WithClass(params string[] classNames);

        public abstract Element WithId(string id);

        public abstract Element WithAttr(string attributeName);

        public abstract Element WithAttr(string attributeName, string attributeValue);

        public abstract Element WithDescendant(Element descendantElement);

        public abstract Element WithChild(Element childElement);

        public abstract Element Parent();

        public abstract Element Parent(Element targetElement);

        public abstract Element Child();

        public abstract Element Child(Element targetElement);

        public abstract Element Following(Element siblingElement);

        public abstract Element Preceding(Element precedingElement);
    }
}
