using Scellecs.Morpeh;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}