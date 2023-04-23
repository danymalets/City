using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Components
{
    public class RemoveComponentWrapper<T> : IComponentWrapper
        where T: struct, IComponent
    {
        public void ProcessWithEntity(Entity entity) => 
            entity.Remove<T>();
    }
}