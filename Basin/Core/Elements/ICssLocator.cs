using System.Text;

namespace Basin.Core.Elements
{
    public interface ICssLocator
    {
        StringBuilder XPath { get; set; }

        StringBuilder Css { get; set; }

    }
}
