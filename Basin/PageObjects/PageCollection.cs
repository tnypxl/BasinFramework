using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Basin.PageObjects.Interfaces;

namespace Basin.PageObjects
{
    public class PageCollection : IPageCollection
    {
        public bool IsEmpty => Pages.Count == 0;

        public PageCollection()
        {
            Pages = new Dictionary<string, object>();
        }

        public void Add<TPage>(TPage page)
        {
            var pageKey = typeof(TPage).ToString();

            if (Pages.ContainsKey(pageKey)) return;

            Pages.Add(pageKey, page);
        }

        public TPage Get<TPage>()
        {
            var pageKey = typeof(TPage).ToString();

            if (!Pages.ContainsKey(pageKey))
                throw new NullReferenceException($"Collection does not contain a page with key `{pageKey}`."); ;

            Pages.TryGetValue(pageKey, out object page);

            return (TPage)page;
        }

        public IDictionary<string, object> Pages { get; }
    }
}