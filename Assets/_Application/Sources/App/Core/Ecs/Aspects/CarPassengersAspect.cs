using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct CarPassengersAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) => filter.With<CarTag>();

        public void TakePlace(int place, Entity player)
        {
#if FORCE_DEBUG
            DAssert.IsTrue(IsFree(place));
#endif
            Passengers[place] = player;
        }

        public readonly void FreeUpPlace(int place, Entity entity)
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

        public readonly IEnterPoint GetPlaceEnterPoint(int place) =>
            EnterPoints[place];
        
        public readonly List<Entity> Passengers => Entity.Get<CarPassengers>().Passengers;
        public readonly IEnterPoint[] EnterPoints => Entity.GetRef<IEnterPoint[]>();
    }
}