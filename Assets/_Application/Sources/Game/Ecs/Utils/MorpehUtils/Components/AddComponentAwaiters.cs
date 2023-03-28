using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehUtils.Components
{
    public struct AddComponentAwaiters : IComponent
    {
        public List<AddComponentAwaiter> List { get; set; }
    }
}