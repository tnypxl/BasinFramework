using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Basin.Selenium
{
    public class Window
    {
        public ReadOnlyCollection<string> CurrentWindows => BrowserSession.Current.WindowHandles;

        public static Size ScreenSize
        {
            get
            {
                const string javascript = "return [window.screen.availWidth, window.screen.availHeight];";
                var javaScriptExecutor = (IJavaScriptExecutor)BrowserSession.Current;

                dynamic dimensions = javaScriptExecutor.ExecuteScript(javascript, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void SwitchTo(int windowIndex)
        {
            BrowserSession.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public static void Maximize()
        {
            BrowserSession.Current.Manage().Window.Position = new Point(0, 0);
            BrowserSession.Current.Manage().Window.Size = ScreenSize;
        }
    }
}