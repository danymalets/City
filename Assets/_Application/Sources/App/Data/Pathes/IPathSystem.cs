using System.Collections.Generic;

namespace Sources.App.Data.Pathes
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<IRoad> Roads { get; }
        IEnumerable<ICrossroads> Crossroads { get; }
    }
}