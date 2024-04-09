using System.Collections.Generic;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<IEnemySpawnPointView> SpawnPoints { get; }
    }
}