using Scellecs.Morpeh;
using Sources.Data;
using Sources.Data.Points;

namespace Sources.App.Game.Ecs.Components.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}