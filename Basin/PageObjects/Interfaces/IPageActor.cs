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

        void EnterText(string text, Element element);

        void WaitForElement(Element element);

        void WaitForElement(Element element, int numberOfSeconds);

        void WaitForNumberOfElements(int numberOfElements, Element element);

        int GetNumberOfElements(Element element);

        bool DontSee(Element element);

        bool See(Element element);

        bool SeeText(string text);

        bool SeeText(string text, Element element);

        void PressKey(params string[] keys);

        void CheckOption(Element element);

        void UncheckOption(Element element);

        object ExecuteScript(string script);

        object ExecuteScript(string script, params object[] args);

        bool SeeNumberOfElements(int numberOfElements, Element element);

        void SelectOptionByText(string optionText, Element selectList);

        void SelectOptionByValue(string optionValue, Element selectList);
    }
}
