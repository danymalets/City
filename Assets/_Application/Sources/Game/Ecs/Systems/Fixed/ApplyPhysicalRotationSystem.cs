using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Systems.Fixed
{
    public class ApplyPhysicalRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Rotation, ViewComponent<ITransform>, Physical> _filter;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Rotation rotation = ref _filter.Get1(i);
                ITransform transformView = _filter.Get2(i).View;

                rotation.Value = transformView.Transform.rotation;
            }
        }
    }
}