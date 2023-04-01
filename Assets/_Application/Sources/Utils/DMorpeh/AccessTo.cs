using Scellecs.Morpeh;

namespace Sources.Utils.DMorpeh
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}