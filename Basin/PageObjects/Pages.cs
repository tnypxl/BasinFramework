using System;

namespace Basin.PageObjects
{
    public static class Pages
    {
        public static void Add<TPage>(TPage page) => BasinEnv.Pages.Add(page);

        public static TPage Get<TPage>() => BasinEnv.Pages.Get<TPage>();

        public static void Use<TPage>(Action<TPage> pageFunc) => pageFunc.Invoke(BasinEnv.Pages.Get<TPage>());

        public static TPage Use<TPage>(Func<TPage, TPage> pageFunc) => pageFunc.Invoke(BasinEnv.Pages.Get<TPage>());
    }
}