using System;
using Basin.Selenium.Builders;

namespace Basin.Selenium.Drivers
{
    public static class Chrome
    {
        public static Func<FirefoxBuilder> Default
        {
            get
            {
                static FirefoxBuilder Builder()
                {
                    var builder = new FirefoxBuilder();

                    builder.CreateService();
                    builder.CreateOptions();
                    return builder;
                }

                return Builder;
            }
        }
    }
}