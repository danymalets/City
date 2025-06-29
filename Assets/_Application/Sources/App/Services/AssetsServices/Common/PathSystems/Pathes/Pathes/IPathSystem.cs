using System.Collections.Generic;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<IRoad> Roads { get; }
        IEnumerable<ICrossroads> Crossroads { get; }
    }
}