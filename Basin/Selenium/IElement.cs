using System;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public interface IElement
    {
        string Label { get; set; }
        By FoundBy { get; set; }
        Func<IWebDriver, bool> IsDisplaying { get; }
        Func<IWebDriver, bool> IsNotDisplaying { get; }

        Elements All { get; }

        /// <summary>
        /// Set the label of this element primarily used for logging.
        /// </summary>
        /// <param name="label"></param>
        Element As(string label);

        /// <summary>
        /// Locate the first child of this element
        /// </summary>
        Element Child();

        /// <summary>
        /// Locate specific child of this element
        /// </summary>
        /// <param name="childElement"></param>
        Element Child(Element childElement);

        /// <summary>
        /// Locate element if it follows or comes after an adjacent element
        /// </summary>
        /// <param name="siblingElement"></param>
        Element Follows(Element siblingElement);

        /// <summary>
        /// Locate element if the contained text matches the pattern
        /// </summary>
        /// <param name="pattern"></param>
        Element IfTextMatches(string pattern);

        /// <summary>
        /// Locate element contained by parent element
        /// </summary>
        /// <param name="parentElement"></param>
        Element Inside(Element parentElement);

        /// <summary>
        /// Locate first parent of element
        /// </summary>
        Element Parent();

        /// <summary>
        /// Locate specific parent of this element
        /// </summary>
        /// <param name="parentElement"></param>
        Element Parent(Element parentElement);

        /// <summary>
        /// Locate element if it precents or comes before an adjacent element
        /// </summary>
        /// <param name="siblingElement"></param>
        Element Precedes(Element siblingElement);

        /// <summary>
        /// Locate element by attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inclusive"></param>
        Element WithAttr(string name, bool inclusive = true);

        /// <summary>
        /// Locate an element by attribute and it's value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="inclusive"></param>
        Element WithAttr(string name, string value, bool inclusive = true);

        /// <summary>
        /// Locate element containing specific child elements
        /// </summary>
        /// <param name="childElement"></param>
        /// <param name="inclusive"></param>
        Element WithChild(Element childElement, bool inclusive = true);

        /// <summary>
        /// Locate element with a class attribute containing the given class name
        /// </summary>
        /// <param name="className"></param>
        /// <param name="inclusive"></param>
        Element WithClass(string className, bool inclusive = true);

        /// <summary>
        /// Locate element containing specific descendant elements
        /// </summary>
        /// <param name="descendantElement"></param>
        /// <param name="inclusive"></param>
        Element WithDescendant(Element descendantElement, bool inclusive = true);

        /// <summary>
        /// Locate element with an id attribute that equals the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inclusive"></param>
        Element WithId(string id, bool inclusive = true);

        /// <summary>
        /// Locate element containing the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="inclusive"></param>
        Element WithText(string text, bool inclusive = true);

        /// <summary>
        /// Locate element at a given index in a list of matching elements
        /// </summary>
        /// <param name="position"></param>
        Element AtPosition(int position);
    }
}