using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}