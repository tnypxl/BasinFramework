using Basin.Selenium;

namespace Basin.Core.Locators.Interfaces
{
    public interface IHtmlElements
    {
        Element AbbreviationTag { get; }

        Element AddressTag { get; }

        Element AbbrTag { get; }

        Element AnyTag { get; }

        Element ArticleTag { get; }

        Element AsideTag { get; }

        Element AreaTag { get; }

        Element AudioTag { get; }

        Element BaseTag { get; }

        Element ButtonTag { get; }

        Element BdiTag { get; }

        Element BdoTag { get; }

        Element BlockquoteTag { get; }

        Element BodyTag { get; }

        Element BrTag { get; }

        Element BoldTag { get; }

        Element CiteTag { get; }

        Element CheckboxInputTag { get; }

        Element CanvasTag { get; }

        Element CaptionTag { get; }

        Element CodeTag { get; }

        Element ColumnTag { get; }

        Element ColumnGroupTag { get; }

        Element DivTag { get; }

        Element DateInputTag { get; }

        Element DateTimeInputTag { get; }

        Element DefinitionListTag { get; }

        Element DefinitionTermTag { get; }

        Element DefinitionTag { get; }

        Element DfnTag { get; }

        Element DialogTag { get; }

        Element DataTag { get; }

        Element DataListTag { get; }

        Element DetailsTag { get; }

        Element EmphasizedTag { get; }

        Element EmbedTag { get; }

        Element FieldSetTag { get; }

        Element FigureTag { get; }

        Element FigureCaptionTag { get; }

        Element FrameTag { get; }

        Element FramesetTag { get; }

        Element FileInputTag { get; }

        Element FontTag { get; }

        Element FooterTag { get; }

        Element FormTag { get; }

        Element HiddenInputTag { get; }

        Element HeadingOneTag { get; }

        Element HeadingTwoTag { get; }

        Element HeadingThreeTag { get; }

        Element HeadingFourTag { get; }

        Element HeadingFiveTag { get; }

        Element HeadingSixTag { get; }

        Element HeadTag { get; }

        Element HorizontalRuleTag { get; }

        Element HtmlTag { get; }

        Element ItalicsTag { get; }

        Element InlineFrameTag { get; }

        Element ImgTag { get; }

        Element LabelTag { get; }

        Element LegendTag { get; }

        Element InsTag { get; }

        Element LinkTag { get; }

        Element ListItemTag { get; }

        Element MainTag { get; }

        Element MetaTag { get; }

        Element NavTag { get; }

        Element ParagraphTag { get; }

        Element OrderedListTag { get; }

        Element UnorderedListTag { get; }

        Element OptionTag { get; }

        Element PasswordInputTag { get; }

        Element RadioInputTag { get; }

        Element SelectTag { get; }

        Element SelectListTag { get; }

        Element SectionTag { get; }

        Element SpanTag { get; }

        Element SubscriptTag { get; }

        Element SuperscriptTag { get; }

        Element SummaryTag { get; }

        Element StrongTag { get; }

        Element TimeTag { get; }

        Element TableTag { get; }

        Element TableHeaderTag { get; }

        Element TableBodyTag { get; }

        Element TableCellTag { get; }

        Element TableColumnTag { get; }

        Element TableColumGroupTag { get; }

        Element TableRowTag { get; }

        Element TableFooterTag { get; }

        Element TextAreaTag { get; }

        Element TextInputTag { get; }

        Element UnderlineTag { get; }

        Element VarTag { get; }

        Element TrackTag { get; }

        Element TitleTag { get; }
        Element Tag(string tagName);
    }
}