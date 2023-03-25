using Scellecs.Morpeh;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.Aspects;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Aspects
{
    public struct CarColorAspect : IDAspect
    {
        public Entity Entity { get; set; }
        private readonly IMeshRenderer[] MeshRenderers => Entity.GetAccess<IMeshRenderer[]>();
        
        public readonly void SetupColor(CarColorType carColorType)
        {
            DAssert.IsTrue(carColorType != CarColorType.None);
            foreach (IMeshRenderer meshRenderer in MeshRenderers)
            {
                meshRenderer.Material.SetInt("_TargetIndex", (int)carColorType);
            }
        }
    }
}