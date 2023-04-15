using _Application.Sources.App.Data.Pathes;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.Npc
{
    public struct NpcOnPath : IComponent
    {
        public PathLine PathLine;
    }
    
    public struct AlwaysActive : IComponent
    {
    }
}