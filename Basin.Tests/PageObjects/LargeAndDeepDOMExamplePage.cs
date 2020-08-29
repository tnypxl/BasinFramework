using Basin.PageObjects;
using Basin.Selenium;

namespace Basin.Tests.PageObjects
{
    public class LargeAndDeepDOMExamplePage : Page
    {
        public Element Item(string text) => DivTag.WithId($"sibling-{text}");

        public Element ItemWithExactText(string text) => DivTag.WithText(text);

        public Element ItemContainingText(string text) => DivTag.WithText($"*|{text}");

        public Element ItemWithoutClassName(string text, string className) => Item(text).WithClass(className, false);

        public Element ItemWithoutDescedant(string elementText, string descendantText) => Item(elementText).WithDescendant(Item(descendantText), false);

        //public Element SomeElement => Css("table#large-table > tbody > tr:nth-child(23) > td:nth-child(10)");

        public Element TableCellByRowAndColumn(int row, int column) => TableTag.WithId("large-table")
                                                                               .Child(TableBodyTag)
                                                                               .Child(TableRowTag.AtPosition(row))
                                                                               .Child(TableCellTag.AtPosition(column));

    }
}