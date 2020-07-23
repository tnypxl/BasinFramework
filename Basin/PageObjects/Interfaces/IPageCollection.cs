using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Basin.PageObjects.Interfaces
{
    public interface IPageCollection
    {
        void Add<TPage>(TPage page);

        TPage Get<TPage>();

        ConcurrentDictionary<string, object> Pages { get; }
    }
}