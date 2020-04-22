using Basin.Pages;
using Basin.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Pages
{
    public class ResultsPage : Page<ResultsPageMap>
    {
        public ResultsPage()
        {
            Map = new ResultsPageMap();
        }

        public bool WordDefinitionDisplayed(string definition)
        {
            return Map.WordDefinition(definition).Displayed;
        }
    }

    public class ResultsPageMap : PageMap
    {
        public Element WordDefinition(string definition) => LocateInside(
            By.XPath($".//div[{CssClassXPath("zci__def__definition")} and {TextXPath(definition)}]"), 
            By.Id("zci-dictionary_definition"));
    }
}