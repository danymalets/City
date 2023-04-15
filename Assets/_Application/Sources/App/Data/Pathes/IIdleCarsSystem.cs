using System.Collections.Generic;
using Sources.Data.Points;

namespace Sources.Data.Pathes
{
    public interface IIdleCarsSystem
    {
        IEnumerable<IIdleCarSpawnPoint> SpawnPoints { get; }
    }
}