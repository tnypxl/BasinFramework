using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public class Window
    {
        public ReadOnlyCollection<string> CurrentWindows => Browser.Current.WindowHandles;

        public static Size ScreenSize
        {
            get
            {
                const string javascript = "return [window.screen.availWidth, window.screen.availHeight];";
                var javaScriptExecutor = (IJavaScriptExecutor)Browser.Current;

                dynamic dimensions = javaScriptExecutor.ExecuteScript(javascript, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void SwitchTo(int windowIndex)
        {
            Browser.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public static void Maximize()
        {
            Browser.Current.Manage().Window.Position = new Point(0, 0);
            Browser.Current.Manage().Window.Size = ScreenSize;
        }
    }
}