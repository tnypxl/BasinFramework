using Basin.Selenium;

namespace Basin.Core.Locators.Interfaces
{
    public interface IHtmlElements
    {
        Element Tag(string tagName);

        Element AnyTag { get; }

        Element ArticleTag { get; }

        Element AsideTag { get; }

        Element AreaTag { get; }

        Element ButtonTag { get; }

        Element CheckboxInputTag { get; }

        Element DivTag { get; }

        Element DateInputTag { get; }

        Element DateTimeInputTag { get; }

        Element DefinitionListTag { get; }

        Element DefinitionTermTag { get; }

        Element DefinitionTag { get; }

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

        Element InlineFrameTag { get; }

        Element ImgTag { get; }

        Element LinkTag { get; }

        Element ListItemTag { get; }

        Element MainTag { get; }

        Element NavTag { get; }

        Element ParagraphTag { get; }

        Element OrderedListTag { get; }

        Element UnorderedListTag { get; }

        Element OptionTag { get; }

        Element RadioInputTag { get; }

        Element SelectTag { get; }

        Element SelectListTag { get; }

        Element SectionTag { get; }

        Element SpanTag { get; }

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
    }
}