using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils
{
    public struct AccessTo<TTAccessible> : IComponent
    {
        public TTAccessible AccessValue;
    }
}