using System.Collections.Generic;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarColors
{
    public interface ICarMesh : IMonoComponent
    {
        void SetupColor(CarColorType carColorType);
        MeshRenderer[] MeshRenderers { get; }
    }
}