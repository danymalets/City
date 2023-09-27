using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects.Car
{
    public struct CarPassengersAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public FilterBuilder GetFilter(FilterBuilder filter) => filter.With<CarTag>();

        public readonly void TakePlaceInternal(int place, Entity player)
        {
#if FORCE_DEBUG
            DAssert.IsTrue(IsFree(place));
#endif
            Passengers[place] = player;
        }

        public readonly void FreeUpPlaceInternal(int place, Entity entity)
        {
#if FORCE_DEBUG
            DAssert.IsTrue(Passengers[place] == entity);
#endif
            Passengers[place] = null;
        }

        public bool IsFree(int place) =>
            Passengers[place] == null;

        public readonly int PlacesCount =>
            Passengers.Count;

        public readonly int PassengersCount => 
            Passengers.Count(p => p != null);

        public readonly bool IsNoPassengers =>
            PassengersCount == 0;

        public readonly List<Entity> Passengers => Entity.Get<CarPassengers>().Passengers;
    }
}