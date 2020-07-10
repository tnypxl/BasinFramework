using System;
using Basin.Tests.Pages;

namespace Basin.Tests.Steps
{
    public static class Pages
    {
        [ThreadStatic] public static HomePage Home;

        [ThreadStatic] public static AddRemoveElementsExamplePage AddRemoveElementsExample;

        [ThreadStatic] public static LargeAndDeepDOMExamplePage LargeAndDeepDOMExample;

        public static void Init()
        {
            Home = new HomePage();
            AddRemoveElementsExample = new AddRemoveElementsExamplePage();
            LargeAndDeepDOMExample = new LargeAndDeepDOMExamplePage();
        }
    }
}
