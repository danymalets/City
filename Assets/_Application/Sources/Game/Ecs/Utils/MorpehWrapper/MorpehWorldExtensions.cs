using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public static class MorpehWorldExtensions
    {
        public static void AddSystem<TDSystem>(this World world) where TDSystem : DUpdateSystem, new()
        {
            
        }
    }
}