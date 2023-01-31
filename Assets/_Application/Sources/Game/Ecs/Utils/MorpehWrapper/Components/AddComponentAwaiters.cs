using System.Collections.Generic;
using Sources.Game.Ecs.Components.Collections;

namespace Sources.Game.Ecs.Utils.MorpehWrapper.Components
{
    public struct AddComponentAwaiters : IListOf<AddComponentAwaiter>
    {
        public List<AddComponentAwaiter> List { get; set; }
    }
}