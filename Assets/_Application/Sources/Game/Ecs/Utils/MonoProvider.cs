using System;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Utils
{
    public class MonoProvider<TMono> : MonoComponentBase where TMono : IMonoComponent
    {
        public override void Setup(Entity entity)
        {
            entity.SetMono(this is TMono view ? view : throw new InvalidCastException());
        }
    }
}