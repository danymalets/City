using System.Collections.Generic;
using _Application.Sources.App.Data.Points;

namespace _Application.Sources.App.Data.Pathes
{
    public interface IIdleCarsSystem
    {
        IEnumerable<IIdleCarSpawnPoint> SpawnPoints { get; }
    }
}