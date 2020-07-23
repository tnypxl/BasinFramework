using System;

namespace Basin.PageObjects
{
    public static class Pages
    {
        public static void Add<TPage>(TPage page)
        {
            var pageKey = typeof(TPage).ToString();

            if (BasinEnv.Pages.ContainsKey(pageKey)) return;

            BasinEnv.Pages.Add(pageKey, page);
        }

        public static TPage Get<TPage>() => (TPage)BasinEnv.Pages[typeof(TPage).ToString()];

        public static void Use<TPage>(Action<TPage> page) => page.Invoke(Get<TPage>());
    }
}