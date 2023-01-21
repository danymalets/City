using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Npc.NpcCar
{
    public struct NpcCarPointReachedEvent : IComponent
    {
        public Point Point;
    }
}