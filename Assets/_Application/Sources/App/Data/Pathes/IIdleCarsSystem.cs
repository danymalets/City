using System.Collections.Generic;
using Sources.App.Data.Points;

namespace Sources.App.Data.Pathes
{
    public interface IIdleCarsSystem
    {
        IEnumerable<ICarSpawnPoint> SpawnPoints { get; }
    }
}