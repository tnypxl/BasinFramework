using System;
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

        bool WaitForNumberOfElements(Element element, int numberOfElements);

        int GetNumberOfElements(Element element);

        bool DontSee(Element element);

        bool See(Element element);

        bool SeeText(string text);

        bool SeeText(string text, Element element);

        void PressKey(params string[] keys);

        void CheckOption(Element element);

        void UncheckOption(Element element);

        void SelectOption(Element element, string value);

        object ExecuteScript(string script);

        object ExecuteScript(string script, params object[] args);
    }
}
