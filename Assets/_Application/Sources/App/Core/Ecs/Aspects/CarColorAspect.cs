using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct CarColorAspect : IDAspect
    {
        public Entity Entity { get; set; }
        
        public Filter GetFilter(Filter filter) => filter.With<CarTag>();

        public readonly void SetupColor(CarColorType carColorType)
        {
            foreach (IMeshRenderer meshRenderer in MeshRenderers)
            {
                MaterialPropertyBlock materialPropertyBlock = new();
                materialPropertyBlock.SetInt(ShaderProperties.CarTargetIndex, (int)carColorType);
                meshRenderer.SetPropertyBlock(materialPropertyBlock);
            }
        }

        private readonly IMeshRenderer[] MeshRenderers => Entity.GetRef<IMeshRenderer[]>();
    }
}