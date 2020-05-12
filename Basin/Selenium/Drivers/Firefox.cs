using System;
using Basin.Selenium.Builders;
using Basin.Selenium.Interfaces;

namespace Basin.Selenium.Drivers
{
    public static class Firefox
    {
        public static Func<IDriverBuilder> Default
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