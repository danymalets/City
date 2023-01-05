using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.View
{
    public class ApplyPositionSystem : IEcsRunSystem
    {
        private EcsFilter<Position, ViewComponent<ITransform>>.Exclude<Physical> _filter;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                Position position = _filter.Get1(i);
                ITransform transformView = _filter.Get2(i).View;

                transformView.Transform.position = position.Value;
            }
        }
    }
}