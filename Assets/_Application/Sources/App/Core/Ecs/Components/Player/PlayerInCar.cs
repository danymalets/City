using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerInCar : IComponent
    {
        public Entity Car;
        public int Place;
    }
}