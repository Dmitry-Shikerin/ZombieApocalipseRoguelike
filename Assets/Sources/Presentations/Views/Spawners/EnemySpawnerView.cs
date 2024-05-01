using System.Collections.Generic;
using Sources.Controllers.Presenters.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

        public IReadOnlyList<IEnemySpawnPoint> SpawnPoints => _spawnPoints;
    }
}