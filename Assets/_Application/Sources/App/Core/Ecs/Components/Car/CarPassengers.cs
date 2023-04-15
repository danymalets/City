using System.Collections.Generic;
using System.Linq;
using _Application.Sources.Utils.CommonUtils.Libs;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.Car
{
    public readonly struct CarPassengers : IComponent
    {
        private readonly List<Entity> _passengers;

        public CarPassengers(int passengersCount) : this()
        {
            _passengers = Enumerable.Repeat<Entity>(null, passengersCount).ToList();
        }
        
        public void TakePlace(int place, Entity player)
        {
            DAssert.IsTrue(IsFree(place));
            _passengers[place] = player;
        }

        public void FreeUpPlace(int place, Entity entity)
        {
            DAssert.IsTrue(_passengers[place] == entity);
            _passengers[place] = null;
        }

        public bool IsFree(int place) =>
            _passengers[place] == null;

        public int PlacesCount =>
            _passengers.Count;

        public int PassengersCount => 
            _passengers.Count(p => p != null);

        public bool IsNoPassengers =>
            PassengersCount == 0;
    }
}