using System.Collections.Generic;
using Sources.Presentations.Views.Spawners;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IItemSpawnerView
    {
        IReadOnlyList<IItemSpawnPoint> SpawnPoints { get; }
    }
}