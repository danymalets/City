using Scellecs.Morpeh;

namespace Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerInCar : IComponent
    {
        public Entity Car;
        public int Place;
    }
}