using Scellecs.Morpeh;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}