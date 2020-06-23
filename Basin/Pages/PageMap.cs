using Basin.Core.Locators;
using Basin.Core.Locators.Interfaces;
using Basin.Pages.Interfaces;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Pages
{
    public abstract class PageMap : IHtmlElements
    {
        public Element Tag(string tagName) => new Element(tagName);

        public Element AnyTag => new Element("*");

        public Element AreaTag => new Element("area");

        public Element ArticleTag => new Element("article");

        public Element AsideTag => new Element("aside");

        public Element ButtonTag => new Element("button");

        public Element CheckboxInputTag => InputTag.WithAttr("type", "checkbox");

        public Element DateInputTag => InputTag.WithAttr("type", "datetime-local");

        public Element DateTimeInputTag => InputTag.WithAttr("type", "datetime");

        public Element DefinitionTag => new Element("dd");

        public Element DefinitionListTag => new Element("dl");

        public Element DefinitionTermTag => new Element("dt");

        public Element DivTag => new Element("div");

        public Element FileInputTag => InputTag.WithAttr("type", "file");

        public Element FontTag => new Element("font");

        public Element FooterTag => new Element("footer");

        public Element FormTag => new Element("form");

        public Element HeadingOneTag => new Element("h1");

        public Element HeadingTwoTag => new Element("h2");

        public Element HeadingThreeTag => new Element("h3");

        public Element HeadingFourTag => new Element("h4");

        public Element HeadingFiveTag => new Element("h5");

        public Element HeadingSixTag => new Element("h6");

        public Element HiddenInputTag => InputTag.WithAttr("type", "hidden");

        public Element InputTag => new Element("input");

        public Element ImgTag => new Element("img");

        public Element InlineFrameTag => new Element("iframe");

        public Element AnchorTag => new Element("a");

        public Element LinkTag => AnchorTag;

        public Element ListItemTag => new Element("li");

        public Element MainTag => new Element("main");

        public Element NavTag => new Element("nav");

        public Element OptionTag => new Element("option");

        public Element OrderedListTag => new Element("ol");

        public Element ParagraphTag => new Element("p");

        public Element PasswordInputTag => InputTag.WithAttr("type", "password");

        public Element RadioInputTag => InputTag.WithAttr("type", "radio");

        public Element SectionTag => new Element("section");

        public Element SelectTag => new Element("select");

        public Element SelectListTag => SelectTag;

        public Element SubmitButton => new Element("input").WithAttr("type", "submit");

        public Element SpanTag => new Element("span");

        public Element TableTag => new Element("table");

        public Element TableBodyTag => new Element("tbody");

        public Element TableCellTag => new Element("td");

        public Element TableColumGroupTag => new Element("colgroup");

        public Element TableColumnTag => new Element("col");

        public Element TableFooterTag => new Element("tfooter");

        public Element TableHeaderTag => new Element("thead");

        public Element TableRowTag => new Element("tr");

        public Element TextAreaTag => new Element("textarea");

        public Element TextInputTag => new Element("input").WithAttr("type", "text");

        public Element UnorderedListTag => new Element("ul");
    }
}