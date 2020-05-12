using System.Collections.Generic;
using System.Text.RegularExpressions;
using Basin.Selenium.Interfaces;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    internal class Locator : ILocator
    {
        private static string _selector;

        // TODO: Beginnings of a more robust locator class
        // private readonly string cssAttrs = @"\[\w*([\~\!\|\^\$\*]?\]?)\=?(?:\'|\"")?(\w+)(?:\'|\"")?\]";

        private static readonly List<(string Pattern, By By)> Locators = new List<(string Pattern, By Selector)>
        {
            (@"^(\#)[\w\-]*?$)", By.Id(_selector.Replace(".", ""))),
            (@"^(\.)[\w\-]*?$)", By.ClassName(_selector.Replace(".", ""))),
            (@"^(\.|\#|\:\:?|\[[\w\=\^\*\?\|\~]*\]|\w)[\w\s\-\.]*?$", By.CssSelector(_selector)),
            (@"^(\.?\/\/?|\*).*?$", By.XPath(_selector))
        };

        internal Locator(string selector)
        {
            _selector = selector;
            GetLocator();
        }

        public By By { get; private set; }

        private void GetLocator()
        {
            By = Locators.Find(loc => Regex.IsMatch(_selector, loc.Pattern)).By;
        }
    }
}