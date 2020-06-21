using System;
using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages
{
    public class AddRemoveElementsPage : Page<AddRemoveElementsPageMap>
    {
        public void AddElement()
        {
            Map.AddElementButton.Click();
        }

        public void AddMultipleElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var addedElementsCount = Map.DeleteButton.All.Count;
                Map.AddElementButton.Click();
                Wait.Until(driver => addedElementsCount > i);
            }
        }

        public bool HasNumberOfDeleteButtons(int expectedCount)
        {
            try
            {
                Driver.Wait.Until(driver => Map.AllDeleteButtons.Count > 0);
                return Map.AllDeleteButtons.Count == expectedCount;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }

    public class AddRemoveElementsPageMap : PageMap
    {
        public Element AddElementButton => ButtonTag.WithText("Add Element");
        public Element DeleteButton => ButtonTag.WithClass("added-manually");
        public Elements AllDeleteButtons => DeleteButton.All;
    }
}