using _Application.Sources.App.Data.Points;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public Point Point;
    }
}