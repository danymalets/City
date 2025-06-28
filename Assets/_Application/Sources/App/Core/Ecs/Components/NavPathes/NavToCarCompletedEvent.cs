using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;

namespace Sources.App.Core.Ecs.Components.NavPathes
{
    public struct NavToCarCompletedEvent : IComponent
    {
        public CarPlaceData PlaceData;
    }
}