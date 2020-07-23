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
            Pages = new ConcurrentDictionary<string, object>();
        }

        public void Add<TPage>(TPage page)
        {
            var pageKey = typeof(TPage).ToString();
            Pages.AddOrUpdate(pageKey, page, (_, p) => p = page);
        }

        public TPage Get<TPage>()
        {
            var pageKey = typeof(TPage).ToString();
            Pages.TryGetValue(pageKey, out object page);
            return (TPage)page ?? throw new NullReferenceException($"Collection does not contain a page with key `{pageKey}`.");
        }

        public ConcurrentDictionary<string, object> Pages { get; }
    }
}