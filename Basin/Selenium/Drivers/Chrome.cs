using System;
using Basin.Selenium.Builders;

namespace Basin.Selenium.Drivers
{
    public static class Chrome
    {
        public static Func<ChromeBuilder> Default
        {
            get
            {
                static ChromeBuilder Builder()
                {
                    var builder = new ChromeBuilder();

                    builder.CreateService();
                    builder.CreateOptions();
                    return builder;
                }

                return Builder;
            }
        }
    }
}