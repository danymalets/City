using Scellecs.Morpeh;
using Sources.App.DMorpeh.Aspects;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Infrastructure.Services.AssetsManager;

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