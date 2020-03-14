using Basin.Screens.Interfaces;

namespace Basin.Screens
{
    public class ScreenComponent<TScreenMap> : IScreenComponent<TScreenMap>
    {
        public TScreenMap Map { get; }
    }
}