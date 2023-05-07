using Scellecs.Morpeh;
using Sources.App.Data.Points;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.App.Core.Ecs.Components.Props
{
    public struct TopPoint : IComponent
    {
        public IPoint Point;
    }
}