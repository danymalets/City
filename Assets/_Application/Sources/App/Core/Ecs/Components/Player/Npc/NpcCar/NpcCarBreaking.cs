
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
{
    public struct NpcCarBreakRequest : IComponent
    {
        public PathPoint Point;
    }
}