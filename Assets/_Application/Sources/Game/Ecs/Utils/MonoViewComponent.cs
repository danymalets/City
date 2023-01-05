using System;
using Leopotam.Ecs;

namespace Sources.Game.Ecs.Utils
{
    public class MonoViewComponent<TView> : MonoComponentBase where TView : IMono
    {
        public override void Setup(EcsEntity entity)
        {
            entity.Get<ViewComponent<TView>>().View = 
                this is TView view ? 
                    view : 
                    throw new InvalidCastException();
        }
    }
}