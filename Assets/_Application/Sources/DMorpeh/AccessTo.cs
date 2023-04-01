using Scellecs.Morpeh;

namespace Sources.DMorpeh
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}