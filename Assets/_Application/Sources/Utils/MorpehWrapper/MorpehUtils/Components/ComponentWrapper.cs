using Scellecs.Morpeh;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;

namespace Sources.Utils.DMorpeh.MorpehUtils.Components
{
    public class ComponentWrapper<T> : IComponentWrapper
        where T: struct, IComponent
    {
        private readonly T _component;

        public ComponentWrapper(T component)
        {
            _component = component;
        }

        public void SetToEntity(Entity entity)
        {
            entity.Set(_component);
        }
    }
}