using Basin.Selenium;
using OpenQA.Selenium.Interactions;

namespace Basin.PageObjects.Interfaces
{
    public interface IPageActor
    {
        Actions Actions { get; }
        Wait Wait { get; }
        void Click(Element element);
        void EnterText(Element element, string text);
        bool WaitForElement(Element element);
        bool WaitForNumberOfElements(Element element, int numberOfElements = 2);
        int GetNumberOfElements(Element element);
        bool DontSee(Element element);
        bool See(Element element);
        void PressKey(params string[] keys);
    }
}
