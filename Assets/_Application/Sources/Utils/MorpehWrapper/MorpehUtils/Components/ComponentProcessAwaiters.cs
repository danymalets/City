using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Components
{
    public struct ComponentProcessAwaiters : IComponent
    {
        public List<ComponentProcessAwaiter> List { get; set; }
    }
}