using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Components
{
    public struct FixedAwaiters : IAwaiters, IComponent
    {
        public List<ComponentAwaiter> List { get; set; }
    }
}