using System;
using System.Collections.Generic;

namespace Basin.Pages.Interfaces
{
    public interface IPageCollection
    {
        void Add<TPage>() where TPage : new();

        TPage Get<TPage>();

        Dictionary<Type, object> Pages { get; }
    }
}