using System.Collections.Generic;
using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.DuckDuckGoExample.Pages
{
    public class ResultsPage : Page<ResultsPageMap>
    {
        public readonly PageCollection OtherPages = new TestPageCollection();
        
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
    
    public class TestPageCollection : PageCollection
    {
        public TestPageCollection()
        {
            Add<ResultsPage>();
            Add<HomePage>();
        }

        public HomePage HomePage => Get<HomePage>();
        
        public ResultsPage ResultsPage => Get<ResultsPage>();
    }
}