using Scellecs.Morpeh;
using Sources.Data;
using Sources.Data.Cars;
using Sources.Utils.DMorpeh.Aspects;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;

namespace Sources.App.Game.Ecs.Aspects
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