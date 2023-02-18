using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Npc
{
    public struct NpcOnPath : IComponent
    {
        public PathLine PathLine;
    }
    
    public struct AlwaysActive : IComponent
    {
    }
}