using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects.Car
{
    public struct CarEnterPointsAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public FilterBuilder GetFilter(FilterBuilder filter) =>
            filter.With<CarTag>();

        public readonly IEnterPoint GetEnterPoint(int place) =>
            Entity.GetRef<IEnterPoint[]>()[place];
    }
}