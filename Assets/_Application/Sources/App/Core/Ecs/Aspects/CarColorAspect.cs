using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects
{
    public struct CarColorAspect : IDAspect
    {
        public Entity Entity { get; set; }
        private readonly IMeshRenderer[] MeshRenderers => Entity.GetAccess<IMeshRenderer[]>();
        
        public readonly void SetupColor(CarColorType carColorType)
        {
            foreach (IMeshRenderer meshRenderer in MeshRenderers)
            {
                meshRenderer.Material.SetInt("_TargetIndex", (int)carColorType);
            }
        }
    }
}