using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Libs;

namespace Sources.App.Core.Ecs.Components.Car
{
    public struct CarPassengers : IComponent
    {
        public List<Entity> Passengers;
    }
}