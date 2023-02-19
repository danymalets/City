using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Collections
{
    public interface IQueueOf<T> : IComponent
    {
        Queue<T> Queue { get; set; }
    }
}