using System;
using System.Collections.Generic;
using Basin.Pages.Interfaces;

namespace Basin.Pages
{
    public class PageCollection : IPageCollection
    {
        private static Dictionary<Type, object> _pages;

        public bool IsEmpty => _pages.Count == 0;

        public PageCollection()
        {
            _pages = new Dictionary<Type, object>();
        }

        public void Add<TPage>() where TPage : new()
        {
            var page = new TPage();

            if (_pages.ContainsKey(typeof(TPage))) return;

            _pages.Add(typeof(TPage), page);
        }

        public TPage Get<TPage>()
        {
            return (TPage) _pages[typeof(TPage)];
        }

        public Dictionary<Type, object> Pages => _pages;
    }
}