using Scellecs.Morpeh;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}