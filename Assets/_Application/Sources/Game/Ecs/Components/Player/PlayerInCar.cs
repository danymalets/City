using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Player
{
    public struct PlayerInCar : IComponent
    {
        public Entity Car;
        public int Place;
    }
}