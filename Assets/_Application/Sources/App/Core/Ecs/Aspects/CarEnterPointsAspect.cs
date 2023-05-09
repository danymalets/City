using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct CarEnterPointsAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) =>
            filter.With<CarTag>();

        public readonly IEnterPoint GetEnterPoint(int place) =>
            Entity.GetRef<IEnterPoint[]>()[place];
    }
}