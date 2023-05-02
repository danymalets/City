using Scellecs.Morpeh;
using Sources.App.Data.Cars;

namespace Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerEnterCarEvent : IComponent
    {
        public CarPlaceData CarPlaceData;
    }
}