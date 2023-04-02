using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllPathLines : IComponent
    {
        public List<PathLine> List { get; set; }
    }
}