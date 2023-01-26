using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Collections
{
    public interface IListOf<T> : IComponent
    {
        List<T> List { get; set; }
    }
}