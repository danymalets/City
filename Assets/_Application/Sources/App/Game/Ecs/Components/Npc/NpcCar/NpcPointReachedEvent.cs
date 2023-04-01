using Scellecs.Morpeh;
using Sources.Data.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Components.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}