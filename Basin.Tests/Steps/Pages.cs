using System;
using Basin.Tests.Pages;

namespace Basin.Tests.Steps
{
    public static class Pages
    {
        [ThreadStatic] public static HomePage Home;
        [ThreadStatic] public static AddRemoveElementsPage AddRemoveElementsExample;

        public static void Init()
        {
            Home = new HomePage();
            AddRemoveElementsExample = new AddRemoveElementsPage();
        }
    }
}
