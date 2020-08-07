using Basin.Core.Elements;

namespace Basin.PageObjects
{
    internal delegate SeleniumElementDecorator Element(string tagName);

    public abstract class PageMap
    {
        private readonly Element GetElement;

        private SeleniumElementDecorator GetSeleniumElement(string tagName) => new SeleniumElementDecorator(new ElementBase(tagName));


        protected PageMap()
        {
            GetElement = new Element(GetSeleniumElement);
        }

        protected Element AbbreviationTag => GetElement("abbr");

        protected Element AbbrTag => AbbreviationTag;

        protected Element AddressTag => GetElement("address");

        protected Element AnchorTag => GetElement("a");

        protected Element AnyTag => GetElement("*");

        protected Element AreaTag => GetElement("area");

        protected Element ArticleTag => GetElement("article");

        protected Element AsideTag => GetElement("aside");

        protected Element AudioTag => GetElement("audio");

        protected Element BaseTag => GetElement("base");

        protected Element BdiTag => GetElement("bdi");

        protected Element BdoTag => GetElement("bdo");

        protected Element BlockquoteTag => GetElement("blockquote");

        protected Element BodyTag => GetElement("body");

        protected Element BoldTag => GetElement("bold");

        protected Element BrTag => GetElement("br");

        protected Element ButtonTag => GetElement("button");

        protected Element CanvasTag => GetElement("canvas");

        protected Element CaptionTag => GetElement("caption");

        protected Element CheckboxInputTag => InputTag.WithAttr("type", "checkbox");

        protected Element CiteTag => GetElement("cite");

        protected Element CodeTag => GetElement("code");

        protected Element ColumnGroupTag => GetElement("colgroup");

        protected Element ColumnTag => GetElement("col");

        protected Element DataListTag => GetElement("datalist");

        protected Element DataTag => GetElement("data");

        protected Element DateInputTag => InputTag.WithAttr("type", "datetime-local");

        protected Element DateTimeInputTag => InputTag.WithAttr("type", "datetime");

        protected Element DefinitionListTag => GetElement("dl");

        protected Element DefinitionTag => GetElement("dd");

        protected Element DefinitionTermTag => GetElement("dt");

        protected Element DetailsTag => GetElement("details");

        protected Element DfnTag => GetElement("dfn");

        protected Element DialogTag => GetElement("dialog");

        protected Element DivTag => GetElement("div");

        protected Element EmbedTag => GetElement("embed");

        protected Element EmphasizedTag => GetElement("em");

        protected Element EmTag => EmphasizedTag;

        protected Element FieldSetTag => GetElement("fieldset");

        protected Element FigureCaptionTag => GetElement("figcaption");

        protected Element FigureTag => GetElement("figure");

        protected Element FileInputTag => InputTag.WithAttr("type", "file");

        protected Element FontTag => GetElement("font");

        protected Element FooterTag => GetElement("footer");

        protected Element FormTag => GetElement("form");

        protected Element FramesetTag => GetElement("frameset");

        protected Element FrameTag => GetElement("frame");

        protected Element HeadingFiveTag => GetElement("h5");

        protected Element HeadingFourTag => GetElement("h4");

        protected Element HeadingOneTag => GetElement("h1");

        protected Element HeadingSixTag => GetElement("h6");

        protected Element HeadingThreeTag => GetElement("h3");

        protected Element HeadingTwoTag => GetElement("h2");

        protected Element HeadTag => GetElement("head");

        protected Element HiddenInputTag => InputTag.WithAttr("type", "hidden");

        protected Element HorizontalRuleTag => GetElement("hr");

        protected Element HrTag => HorizontalRuleTag;

        protected Element HtmlTag => GetElement("html");

        protected Element ImgTag => GetElement("img");

        protected Element InlineFrameTag => GetElement("iframe");

        protected Element InputTag => GetElement("input");

        protected Element InsTag => GetElement("ins");

        protected Element ItalicsTag => GetElement("i");

        protected Element LabelTag => GetElement("label");

        protected Element LegendTag => GetElement("legend");

        protected Element LinkTag => GetElement("link");

        protected Element ListItemTag => GetElement("li");

        protected Element MainTag => GetElement("main");

        protected Element MetaTag => GetElement("meta");

        protected Element NavTag => GetElement("nav");

        protected Element OptionTag => GetElement("option");

        protected Element OrderedListTag => GetElement("ol");

        protected Element ParagraphTag => GetElement("p");

        protected Element PasswordInputTag => InputTag.WithAttr("type", "password");

        protected Element RadioInputTag => InputTag.WithAttr("type", "radio");

        protected Element SectionTag => GetElement("section");

        protected Element SelectListTag => SelectTag;

        protected Element SelectTag => GetElement("select");

        protected Element SpanTag => GetElement("span");

        protected Element StrongTag => GetElement("strong");

        protected Element SubmitButton => GetElement("input").WithAttr("type", "submit");

        protected Element SubscriptTag => GetElement("sub");

        protected Element SummaryTag => GetElement("summary");

        protected Element SuperscriptTag => GetElement("sup");

        protected Element TableBodyTag => GetElement("tbody");

        protected Element TableCellTag => GetElement("td");

        protected Element TableColumGroupTag => GetElement("colgroup");

        protected Element TableColumnTag => GetElement("col");

        protected Element TableFooterTag => GetElement("tfooter");

        protected Element TableHeaderTag => GetElement("thead");

        protected Element TableRowTag => GetElement("tr");

        protected Element TableTag => GetElement("table");

        protected Element TextAreaTag => GetElement("textarea");

        protected Element TextInputTag => GetElement("input").WithAttr("type", "text");

        protected Element TimeTag => GetElement("time");

        protected Element UnorderedListTag => GetElement("ul");

        protected Element UnderlineTag => GetElement("u");

        protected Element VarTag => GetElement("var");

        protected Element TrackTag => GetElement("track");

        protected Element TitleTag => GetElement("title");

        protected Element Tag(string tagName) => GetElement(tagName);
    }

    public abstract class ScreenMap : PageMap { }
}