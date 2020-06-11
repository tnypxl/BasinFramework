using System;
using Basin.Selenium.Builders;

namespace Basin.Selenium.Drivers
{
    public class Edge
    {
        public static Func<EdgeBuilder> Default
        {
            get
            {
                static EdgeBuilder Builder()
                {
                    var builder = new EdgeBuilder();

                    builder.CreateOptions();
                    builder.DriverOptions.UseChromium = true;

                    return builder;
                }

                return Builder;
            }
        }
    }
}