using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Utils;

namespace Sources.Game.Ecs.Systems.Update.View
{
    public class ApplyRotationSystem  : IEcsRunSystem
    {
        private EcsFilter<Rotation, ViewComponent<ITransform>>.Exclude<Physical> _filter;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                Rotation rotation = _filter.Get1(i);
                ITransform transformView = _filter.Get2(i).View;

                transformView.Transform.rotation = rotation.Value;
            }
        }
    }
}