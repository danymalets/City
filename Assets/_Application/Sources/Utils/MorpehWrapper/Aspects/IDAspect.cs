using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.Aspects
{
    public interface IDAspect : IDAspectBase
    {
        FilterBuilder GetFilter(FilterBuilder filter);
    }
}