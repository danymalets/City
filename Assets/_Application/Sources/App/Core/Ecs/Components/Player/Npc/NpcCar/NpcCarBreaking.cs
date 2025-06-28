
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
{
    public struct NpcCarBreakRequest : IComponent
    {
        public Point Point;
    }
}