using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.App.DMorpeh.MorpehUtils.Components
{
    public struct AddComponentAwaiters : IComponent
    {
        public List<AddComponentAwaiter> List { get; set; }
    }
}