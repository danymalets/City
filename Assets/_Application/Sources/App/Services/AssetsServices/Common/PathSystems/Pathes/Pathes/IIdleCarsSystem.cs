using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.IdleCarSpawns;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
{
    public interface IIdleCarsSystem
    {
        IEnumerable<ICarSpawnPoint> SpawnPoints { get; }
    }
}