using System.Collections.Generic;

namespace Sources.Data.MonoViews
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<IRoad> Roads { get; }
        IEnumerable<ICrossroads> Crossroads { get; }
    }
}