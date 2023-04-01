using Scellecs.Morpeh;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.App.Game.Ecs.Components.Npc
{
    public struct NpcOnPath : IComponent
    {
        public PathLine PathLine;
    }
    
    public struct AlwaysActive : IComponent
    {
    }
}