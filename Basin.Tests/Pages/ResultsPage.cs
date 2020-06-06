using System.Collections.Generic;
using Basin.Pages;
using Basin.Selenium;
using OpenQA.Selenium;

namespace Basin.Tests.Pages
{
    public class ResultsPage : Page<ResultsPageMap>
    {
        public readonly PageCollection OtherPages = new PageCollection();

        public bool WordDefinitionDisplayed(string definition)
        {
            return Map.WordDefinition(definition).Displayed;
        }
    }

    public class ResultsPageMap : PageMap
    {
        public Element WordDefinition(string definition) => DivTag
            .WithClass("zci__def__definition")
            .WithText(definition)
            .Inside(DivTag.WithId("zci-dictionary_definition"));
    }
}
