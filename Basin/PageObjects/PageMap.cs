using Basin.Core.Locators.Interfaces;
using Basin.Selenium;

namespace Basin.PageObjects
{
    public abstract class PageMap : IHtmlElements
    {
        public Element AbbreviationTag => new Element("abbr");

        public Element AbbrTag => AbbreviationTag;

        public Element AddressTag => new Element("address");

        public Element AnchorTag => new Element("a");

        public Element AnyTag => new Element("*");

        public Element AreaTag => new Element("area");

        public Element ArticleTag => new Element("article");

        public Element AsideTag => new Element("aside");

        public Element AudioTag => new Element("audio");

        public Element BaseTag => new Element("base");

        public Element BdiTag => new Element("bdi");

        public Element BdoTag => new Element("bdo");

        public Element BlockquoteTag => new Element("blockquote");

        public Element BodyTag => new Element("body");

        public Element BoldTag => new Element("bold");

        public Element BrTag => new Element("br");

        public Element ButtonTag => new Element("button");

        public Element CanvasTag => new Element("canvas");

        public Element CaptionTag => new Element("caption");

        public Element CheckboxInputTag => InputTag.WithAttr("type", "checkbox");

        public Element CiteTag => new Element("cite");

        public Element CodeTag => new Element("code");

        public Element ColumnGroupTag => new Element("colgroup");

        public Element ColumnTag => new Element("col");

        public Element DataListTag => new Element("datalist");

        public Element DataTag => new Element("data");

        public Element DateInputTag => InputTag.WithAttr("type", "datetime-local");

        public Element DateTimeInputTag => InputTag.WithAttr("type", "datetime");

        public Element DefinitionListTag => new Element("dl");

        public Element DefinitionTag => new Element("dd");

        public Element DefinitionTermTag => new Element("dt");

        public Element DetailsTag => new Element("details");

        public Element DfnTag => new Element("dfn");

        public Element DialogTag => new Element("dialog");

        public Element DivTag => new Element("div");

        public Element EmbedTag => new Element("embed");

        public Element EmphasizedTag => new Element("em");

        public Element EmTag => EmphasizedTag;

        public Element FieldSetTag => new Element("fieldset");

        public Element FigureCaptionTag => new Element("figcaption");

        public Element FigureTag => new Element("figure");

        public Element FileInputTag => InputTag.WithAttr("type", "file");

        public Element FontTag => new Element("font");

        public Element FooterTag => new Element("footer");

        public Element FormTag => new Element("form");

        public Element FramesetTag => new Element("frameset");

        public Element FrameTag => new Element("frame");

        public Element HeadingFiveTag => new Element("h5");

        public Element HeadingFourTag => new Element("h4");

        public Element HeadingOneTag => new Element("h1");

        public Element HeadingSixTag => new Element("h6");

        public Element HeadingThreeTag => new Element("h3");

        public Element HeadingTwoTag => new Element("h2");

        public Element HeadTag => new Element("head");

        public Element HiddenInputTag => InputTag.WithAttr("type", "hidden");

        public Element HorizontalRuleTag => new Element("hr");

        public Element HrTag => HorizontalRuleTag;

        public Element HtmlTag => new Element("html");

        public Element ImgTag => new Element("img");

        public Element InlineFrameTag => new Element("iframe");

        public Element InputTag => new Element("input");

        public Element InsTag => new Element("ins");

        public Element ItalicsTag => new Element("i");

        public Element LabelTag => new Element("label");

        public Element LegendTag => new Element("legend");

        public Element LinkTag => new Element("link");

        public Element ListItemTag => new Element("li");

        public Element MainTag => new Element("main");

        public Element MetaTag => new Element("meta");

        public Element NavTag => new Element("nav");

        public Element OptionTag => new Element("option");

        public Element OrderedListTag => new Element("ol");

        public Element ParagraphTag => new Element("p");

        public Element PasswordInputTag => InputTag.WithAttr("type", "password");

        public Element RadioInputTag => InputTag.WithAttr("type", "radio");

        public Element SectionTag => new Element("section");

        public Element SelectListTag => SelectTag;

        public Element SelectTag => new Element("select");

        public Element SpanTag => new Element("span");

        public Element StrongTag => new Element("strong");

        public Element SubmitButton => new Element("input").WithAttr("type", "submit");

        public Element SubscriptTag => new Element("sub");

        public Element SummaryTag => new Element("summary");

        public Element SuperscriptTag => new Element("sup");

        public Element TableBodyTag => new Element("tbody");

        public Element TableCellTag => new Element("td");

        public Element TableColumGroupTag => new Element("colgroup");

        public Element TableColumnTag => new Element("col");

        public Element TableFooterTag => new Element("tfooter");

        public Element TableHeaderTag => new Element("thead");

        public Element TableRowTag => new Element("tr");

        public Element TableTag => new Element("table");

        public Element TextAreaTag => new Element("textarea");

        public Element TextInputTag => new Element("input").WithAttr("type", "text");

        public Element TimeTag => new Element("time");

        public Element UnorderedListTag => new Element("ul");

        public Element UnderlineTag => new Element("u");

        public Element VarTag => new Element("var");

        public Element TrackTag => new Element("track");

        public Element TitleTag => new Element("title");

        public Element Tag(string tagName) => new Element(tagName);
    }
}