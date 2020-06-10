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

                    builder.CreateService();
                    builder.CreateOptions();

                    if (Environment.OSVersion.Platform != PlatformID.Win32NT) return builder;
                    
                    builder.DriverService.HideCommandPromptWindow = true;
                    
                    return builder;
                }

                return Builder;
            }
        }
    }
}