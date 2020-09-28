using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.PageObjects
{
    public abstract class PageMap
    {
        protected Element Locate(By by) => new Element(by);

        protected Element AbbreviationTag => new Element("abbr");

        protected Element AbbrTag => AbbreviationTag;

        protected Element AddressTag => new Element("address");

        protected Element AnchorTag => new Element("a");

        protected Element AnyTag => new Element("*");

        protected Element AreaTag => new Element("area");

        protected Element ArticleTag => new Element("article");

        protected Element AsideTag => new Element("aside");

        protected Element AudioTag => new Element("audio");

        protected Element BaseTag => new Element("base");

        protected Element BdiTag => new Element("bdi");

        protected Element BdoTag => new Element("bdo");

        protected Element BlockquoteTag => new Element("blockquote");

        protected Element BodyTag => new Element("body");

        protected Element BoldTag => new Element("bold");

        protected Element BrTag => new Element("br");

        protected Element ButtonTag => new Element("button");

        protected Element CanvasTag => new Element("canvas");

        protected Element CaptionTag => new Element("caption");

        protected Element CheckboxInputTag => InputTag.WithAttr("type", "checkbox");

        protected Element CiteTag => new Element("cite");

        protected Element CodeTag => new Element("code");

        protected Element ColumnGroupTag => new Element("colgroup");

        protected Element ColumnTag => new Element("col");

        protected Element DataListTag => new Element("datalist");

        protected Element DataTag => new Element("data");

        protected Element DateInputTag => InputTag.WithAttr("type", "datetime-local");

        protected Element DateTimeInputTag => InputTag.WithAttr("type", "datetime");

        protected Element DefinitionListTag => new Element("dl");

        protected Element DefinitionTag => new Element("dd");

        protected Element DefinitionTermTag => new Element("dt");

        protected Element DetailsTag => new Element("details");

        protected Element DfnTag => new Element("dfn");

        protected Element DialogTag => new Element("dialog");

        protected Element DivTag => new Element("div");

        protected Element EmbedTag => new Element("embed");

        protected Element EmphasizedTag => new Element("em");

        protected Element EmTag => EmphasizedTag;

        protected Element FieldSetTag => new Element("fieldset");

        protected Element FigureCaptionTag => new Element("figcaption");

        protected Element FigureTag => new Element("figure");

        protected Element FileInputTag => InputTag.WithAttr("type", "file");

        protected Element FontTag => new Element("font");

        protected Element FooterTag => new Element("footer");

        protected Element FormTag => new Element("form");

        protected Element FramesetTag => new Element("frameset");

        protected Element FrameTag => new Element("frame");

        protected Element HeadingFiveTag => new Element("h5");

        protected Element HeadingFourTag => new Element("h4");

        protected Element HeadingOneTag => new Element("h1");

        protected Element HeadingSixTag => new Element("h6");

        protected Element HeadingThreeTag => new Element("h3");

        protected Element HeadingTwoTag => new Element("h2");

        protected Element HeadTag => new Element("head");

        protected Element HiddenInputTag => InputTag.WithAttr("type", "hidden");

        protected Element HorizontalRuleTag => new Element("hr");

        protected Element HrTag => HorizontalRuleTag;

        protected Element HtmlTag => new Element("html");

        protected Element ImgTag => new Element("img");

        protected Element InlineFrameTag => new Element("iframe");

        protected Element InputTag => new Element("input");

        protected Element InsTag => new Element("ins");

        protected Element ItalicsTag => new Element("i");

        protected Element LabelTag => new Element("label");

        protected Element LegendTag => new Element("legend");

        protected Element LinkTag => new Element("link");

        protected Element ListItemTag => new Element("li");

        protected Element MainTag => new Element("main");

        protected Element MetaTag => new Element("meta");

        protected Element NavTag => new Element("nav");

        protected Element OptionTag => new Element("option");

        protected Element OrderedListTag => new Element("ol");

        protected Element ParagraphTag => new Element("p");

        protected Element PasswordInputTag => InputTag.WithAttr("type", "password");

        protected Element RadioInputTag => InputTag.WithAttr("type", "radio");

        protected Element SectionTag => new Element("section");

        protected Element SelectListTag => SelectTag;

        protected Element SelectTag => new Element("select");

        protected Element SpanTag => new Element("span");

        protected Element StrongTag => new Element("strong");

        protected Element SubmitButton => new Element("input").WithAttr("type", "submit");

        protected Element SubscriptTag => new Element("sub");

        protected Element SummaryTag => new Element("summary");

        protected Element SuperscriptTag => new Element("sup");

        protected Element TableBodyTag => new Element("tbody");

        protected Element TableCellTag => new Element("td");

        protected Element TableColumGroupTag => new Element("colgroup");

        protected Element TableColumnTag => new Element("col");

        protected Element TableFooterTag => new Element("tfooter");

        protected Element TableHeaderTag => new Element("thead");

        protected Element TableRowTag => new Element("tr");

        protected Element TableTag => new Element("table");

        protected Element TextAreaTag => new Element("textarea");

        protected Element TextInputTag => new Element("input").WithAttr("type", "text");

        protected Element TimeTag => new Element("time");

        protected Element UnorderedListTag => new Element("ul");

        protected Element UnderlineTag => new Element("u");

        protected Element VarTag => new Element("var");

        protected Element TrackTag => new Element("track");

        protected Element TitleTag => new Element("title");

        protected Element Tag(string tagName) => new Element(tagName);
    }

    public abstract class ScreenMap : PageMap { }
}