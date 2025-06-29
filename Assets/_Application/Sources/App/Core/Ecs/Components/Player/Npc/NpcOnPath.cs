using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc
{
    public struct NpcOnPath : IComponent
    {
        public PathLine PathLine;
    }
}