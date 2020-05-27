using System.Text;
using System.Text.RegularExpressions;
using Basin.Core.Locators.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Core.Locators
{
    public sealed class Locator : ILocatorBuilder
    {
        public By By => By.XPath(XPath.ToString());
        
        public StringBuilder XPath { get; }

        public Locator(string tagName, bool isChild = false)
        {
            var rootXPath = $"{(isChild ? "/" : "//")}{tagName}";
            XPath = new StringBuilder();
            XPath.Append(rootXPath);
        }
        
        public ILocatorBuilder Inside(ILocatorBuilder parent)
        {
            XPath.Insert(0, parent.XPath);
            return this;
        }
        
        public ILocatorBuilder WithText(string text)
        {
            XPath.Append($"[contains(.,'{text}')]");
            return this;
        }

        public ILocatorBuilder WithClass(string className)
        {
            XPath.Append($"[contains(concat(' ',normalize-space(@class),' '),' {className} ')]");
            return this;                                                                          
        }

        public ILocatorBuilder WithId(string id)
        {
            var op = string.Empty;
            
            if (IdHasOperator(id)) 
                op = Regex.Match(id, @"^(\^|\~|\$|\||\*){1}").Value;
            
            XPath.Append($"[@id{op}='{id}']");
            return this;                     
        }

        public ILocatorBuilder WithAttr(string name, string value)
        {
            XPath.Append($"[@{name}='{value}']");
            return this;                           
        }
        
        public ILocatorBuilder WithChild(ILocatorBuilder child)
        {
            XPath.Append($"[.{child.XPath}]");
            return this;                          
        }
        
        private static bool IdHasOperator(string id) => Regex.IsMatch(id, @"^(\^|\~|\$|\||\*){1}");
    }
}