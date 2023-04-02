using System.Collections.Generic;

namespace Sources.Data.MonoViews
{
    public interface IIdleCarsSystem
    {
        IEnumerable<IIdleCarSpawnPoint> SpawnPoints { get; }
    }
}