using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.Aspects
{
    public interface IDAspect : IDAspectBase
    {
        Filter GetFilter(Filter filter);
    }
}