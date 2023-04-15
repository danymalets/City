using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Components
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