using Basin.Core.Elements;
using Basin.PageObjects;
//using Basin.Cor;
using OpenQA.Selenium;

namespace Basin.Tests.PageObjects
{
    public class AddRemoveElementsExamplePage : Page<AddRemoveElementsPageMap>
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
                Wait.Until(_ => addedElementsCount > i);
            }
        }

        public bool HasNumberOfDeleteButtons(int expectedCount)
        {
            try
            {
                Wait.Until(_ => Map.AllDeleteButtons.Count > 0);
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