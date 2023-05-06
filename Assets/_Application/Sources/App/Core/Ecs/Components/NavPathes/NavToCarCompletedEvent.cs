using Scellecs.Morpeh;
using Sources.App.Data.Cars;

namespace Sources.App.Core.Ecs.Components.NavPathes
{
    public struct NavToCarCompletedEvent : IComponent
    {
        public CarPlaceData PlaceData;
    }
}