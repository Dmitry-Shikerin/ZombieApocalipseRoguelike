using System.Collections.Generic;
using Sources.Controllers.EnemeSpawners;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<EnemySpawnPointView> _spawnPoints;

        public IReadOnlyList<IEnemySpawnPointView> SpawnPoints => _spawnPoints;
    }
}