using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public sealed class Elements : ReadOnlyCollection<IWebElement>
    {
        public Elements(IList<IWebElement> list) : base(list)
        {
        }

        public Elements(By by) : base(Driver.Current.FindElements(by))
        {
        }

        public By FoundBy { get; set; }

        public By ParentFoundBy { get; set; }

        public bool IsEmpty => Count == 0;
    }
}