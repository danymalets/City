using Scellecs.Morpeh;
using Sources.App.Data.Cars;

namespace Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerWantsEnterCarEvent : IComponent
    {
        public CarPlaceData CarPlaceData;
    }
}