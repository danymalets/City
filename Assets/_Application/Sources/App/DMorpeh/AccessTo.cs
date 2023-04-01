using Scellecs.Morpeh;

namespace Sources.App.DMorpeh
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}