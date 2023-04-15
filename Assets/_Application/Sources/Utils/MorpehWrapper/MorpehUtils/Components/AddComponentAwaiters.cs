using System.Collections.Generic;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Components
{
    public struct AddComponentAwaiters : IComponent
    {
        public List<AddComponentAwaiter> List { get; set; }
    }
}