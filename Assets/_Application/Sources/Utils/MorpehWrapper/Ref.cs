using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper
{
    public struct Ref<TRef> : IComponent
        where TRef : class
    {
        public TRef Reference;
    }
}