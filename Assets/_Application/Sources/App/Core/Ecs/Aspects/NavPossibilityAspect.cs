using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct NavPossibilityAspect : IDAspect
    {
        public Entity Entity { get; set; }
        public Filter GetFilter(Filter filter) => filter;

        // public readonly bool TryFind
    }
}