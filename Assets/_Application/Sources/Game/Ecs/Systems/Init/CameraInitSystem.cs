using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class CameraInitSystem : DInitializer
    {
        protected override void OnInitialize()
        {
            _factory.CreateCamera();
        }
    }
}