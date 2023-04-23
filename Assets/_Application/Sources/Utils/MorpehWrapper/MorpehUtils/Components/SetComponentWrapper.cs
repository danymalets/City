using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Components
{
    public class SetComponentWrapper<T> : IComponentWrapper
        where T: struct, IComponent
    {
        private readonly T _component;

        public SetComponentWrapper(T component)
        {
            _component = component;
        }

        public void ProcessWithEntity(Entity entity) => 
            entity.Set(_component);
    }
}