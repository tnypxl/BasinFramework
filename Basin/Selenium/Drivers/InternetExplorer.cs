using System;
using Basin.Selenium.Builders;

namespace Basin.Selenium.Drivers
{
    public static class InternetExplorer
    {
        public static Func<InternetExplorerBuilder> Default
        {
            get
            {
                static InternetExplorerBuilder Builder()
                {
                    var builder = new InternetExplorerBuilder();

                    builder.CreateService();
                    builder.CreateOptions();
                    return builder;
                }

                return Builder;
            }
        }
    }
}