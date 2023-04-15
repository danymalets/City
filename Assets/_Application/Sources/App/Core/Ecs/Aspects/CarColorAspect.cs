using _Application.Sources.App.Data.Cars;
using _Application.Sources.Utils.MorpehWrapper.Aspects;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Aspects
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