using System;

namespace Basin.Core.Elements
{
    public class ElementBase : Element
    {
        protected ElementBase()
        {
        }

        public override bool Displayed => throw new NotImplementedException();

        public override string Text => throw new NotImplementedException();

        public override Element Child()
        {
            throw new NotImplementedException();
        }

        public override Element Child(Element targetElement)
        {
            throw new NotImplementedException();
        }

        public override void Click()
        {
            throw new NotImplementedException();
        }

        public override Element Following(Element siblingElement)
        {
            throw new NotImplementedException();
        }

        public override Element Parent()
        {
            throw new NotImplementedException();
        }

        public override Element Parent(Element targetElement)
        {
            throw new NotImplementedException();
        }

        public override Element Preceding(Element precedingElement)
        {
            throw new NotImplementedException();
        }

        public override void SendKeys()
        {
            throw new NotImplementedException();
        }

        public override Element WithAttr(string attributeName)
        {
            throw new NotImplementedException();
        }

        public override Element WithAttr(string attributeName, string attributeValue)
        {
            throw new NotImplementedException();
        }

        public override Element WithChild(Element childElement)
        {
            throw new NotImplementedException();
        }

        public override Element WithClass(string className)
        {
            throw new NotImplementedException();
        }

        public override Element WithClass(params string[] classNames)
        {
            throw new NotImplementedException();
        }

        public override Element WithDescendant(Element descendantElement)
        {
            throw new NotImplementedException();
        }

        public override Element WithId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
