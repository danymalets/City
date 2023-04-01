using Scellecs.Morpeh;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Components.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}