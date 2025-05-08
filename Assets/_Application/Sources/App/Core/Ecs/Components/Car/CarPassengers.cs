using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.App.Core.Ecs.Components.Car
{
    public struct CarPassengers : IComponent
    {
        public List<Entity> Passengers;
    }
}