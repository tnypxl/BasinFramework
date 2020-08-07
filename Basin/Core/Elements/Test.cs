using System;
using System.Collections.Generic;
using System.Text;

namespace Basin.Core.Elements
{
    public class Test
    {
        public void Foo()
        {
            var element = new ElementDecorator(new SeleniumElementDecorator(new ElementBase("div")));
        }
    }
}
