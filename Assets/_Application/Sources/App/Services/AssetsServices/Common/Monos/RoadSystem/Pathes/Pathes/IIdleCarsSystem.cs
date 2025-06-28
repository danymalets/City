using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes
{
    public interface IIdleCarsSystem
    {
        IEnumerable<ICarSpawnPoint> SpawnPoints { get; }
    }
}