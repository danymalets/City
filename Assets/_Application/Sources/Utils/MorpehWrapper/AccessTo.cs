using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}