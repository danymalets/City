using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;

namespace Sources.Game.Ecs.Utils.MorpehWrapper.Components
{
    public struct AddComponentAwaiters : IComponent
    {
        public List<AddComponentAwaiter> List { get; set; }
    }
}