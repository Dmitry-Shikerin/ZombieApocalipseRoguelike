using System.Collections.Generic;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IItemSpawnerView
    {
        IReadOnlyList<IItemSpawnPoint> SpawnPoints { get; }
    }
}