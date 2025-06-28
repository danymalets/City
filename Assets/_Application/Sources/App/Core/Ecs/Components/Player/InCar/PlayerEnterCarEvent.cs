using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;

namespace Sources.App.Core.Ecs.Components.Player.InCar
{
    public struct PlayerEnterCarEvent : IComponent
    {
        public CarPlaceData CarPlaceData;
    }
}