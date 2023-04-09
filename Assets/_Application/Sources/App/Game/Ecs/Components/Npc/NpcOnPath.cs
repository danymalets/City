using Scellecs.Morpeh;
using Sources.Data;
using Sources.Data.Pathes;

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