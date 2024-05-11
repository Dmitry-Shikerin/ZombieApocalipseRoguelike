using System;
using System.Collections.Generic;
using Sources.Controllers.Presenters.Spawners;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

        public IReadOnlyList<IEnemySpawnPoint> SpawnPoints => _spawnPoints;
        public CharacterView CharacterView { get; private set; }

        public void SetCharacterView(CharacterView characterView)
        {
            CharacterView = characterView ? characterView : 
                throw new ArgumentNullException(nameof(characterView));
        }
    }
}