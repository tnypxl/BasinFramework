using Basin.PageObjects;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.PageObjects
{
    public class LargeAndDeepDomExamplePage : Page
    {
        public Element Item(string text) => DivTag.WithId($"sibling-{text}");

        public Element ItemWithExactText(string text) => DivTag.WithText(text);

        public Element ItemContainingText(string text) => DivTag.WithText($"*|{text}");

        public Element ItemWithoutClassName(string text, string className) => Item(text).WithClass(className, false);

        public Element ItemWithMultipleClasses(string text, params string[] classNames) =>
            Item(text).WithClass(classNames);

        public Element ItemWithoutDescedant(string elementText, string descendantText) =>
            Item(elementText).WithDescendant(Item(descendantText), false);

        public Element TableCellByRowAndColumn(int row, int column) => TableTag
            .WithId("large-table")
            .Child(TableBodyTag)
            .Child(TableRowTag.AtPosition(row))
            .Child(TableCellTag.AtPosition(column));

        public Element ItemById(string id) => Locate(By.Id(id));
    }
}