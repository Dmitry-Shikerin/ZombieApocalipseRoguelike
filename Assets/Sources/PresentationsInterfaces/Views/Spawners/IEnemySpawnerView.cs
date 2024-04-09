using System.Collections.Generic;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<IEnemySpawnPoint> SpawnPoints { get; }
    }
}