using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.MonoViews;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllCrossroads : IComponent
    {
        public List<ICrossroads> List { get; set; }
    }
}