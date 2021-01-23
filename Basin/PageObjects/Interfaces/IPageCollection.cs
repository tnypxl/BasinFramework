using System;
using System.Collections.Generic;

namespace Basin.PageObjects.Interfaces
{
    public interface IPageCollection
    {
        void Add<TPage>(TPage page);

        TPage Get<TPage>();

        IDictionary<string, object> Pages { get; }

        void Use<T>(Action<T> action);
    }
}
