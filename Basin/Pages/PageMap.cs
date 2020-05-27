using Basin.Core.Locators;
using Basin.Core.Locators.Interfaces;
using Basin.Pages.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages
{
    public abstract class PageMap : IPageMap, IHtmlElements
    {
        public Element Locate(By by) => new Element(by);
        
        public Element Locate(By by, int timeout) => new Element(by, timeout);

        public Element LocateInside(By by, By parentBy) => new Element(by, parentBy);
        
        public Element LocateInside(By by, By parentBy, int timeout) => new Element(by, parentBy, timeout);

        public Elements LocateAll(By by) => new Elements(by);

        public Elements LocateAllInside(By by, By parentBy) => new Elements(Locate(parentBy).FindElements(by));
        
        public Elements LocateAllInside(By by, By parentBy, int timeout) => new Elements(Locate(parentBy, timeout).FindElements(by));

        public Element Area => new Element("area");
        
        public Element Article => new Element("article");
        
        public Element Aside => new Element("aside");
        
        public Element Button => new Element("button");
        
        public Element CheckboxField => new Element("input").WithAttr("type", "checkbox");
        
        public Element DateField => new Element("input").WithAttr("type", "datetime-local");
        
        public Element DateTimeField => new Element("input").WithAttr("type", "datetime");
        
        public Element Definition => new Element("dd");
        
        public Element DefinitionList => new Element("dl");
        
        public Element DefinitionTerm => new Element("dt");
        
        public Element Div => new Element("div");
        
        public Element FileField => new Element("input").WithAttr("type", "file");
        
        public Element Font => new Element("font");
        
        public Element Footer => new Element("footer");
        
        public Element Form => new Element("form");
        
        public Element HeadingOne => new Element("h1");
        
        public Element HeadingTwo => new Element("h2");
        
        public Element HeadingThree => new Element("h3");
        
        public Element HeadingFour => new Element("h4");
        
        public Element HeadingFive => new Element("h5");
        
        public Element HeadingSix => new Element("h6");
        
        public Element HiddenField => new Element("input").WithAttr("type", "hidden");
        
        public Element Img => new Element("img");
        
        public Element InlineFrame => new Element("iframe");
        
        public Element Link => new Element("a");
        
        public Element ListItem => new Element("li");
        
        public Element Main => new Element("main");
        
        public Element Nav => new Element("nav");
        
        public Element Option => new Element("option");
        
        public Element OrderedList => new Element("ol");
        
        public Element Paragraph => new Element("p");
        
        public Element Radio => new Element("input").WithAttr("type", "radio");
        
        public Element Section => new Element("section");
        
        public Element SelectList => new Element("select");
        
        public Element Span => new Element("span");
        
        public Element Table => new Element("table");
        
        public Element TableBody => new Element("tbody");
        
        public Element TableCell => new Element("td");
        
        public Element TableColumGroup => new Element("colgroup");
        
        public Element TableColumn => new Element("col");
        
        public Element TableFooter => new Element("tfooter");
        
        public Element TableHeader => new Element("thead");
        
        public Element TableRow => new Element("tr");
        
        public Element TextAreaField => new Element("textarea");
        
        public Element TextField => new Element("input").WithAttr("type", "text");
        
        public Element UnorderedList => new Element("ul");
    }
}