using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Spawners;
using Sources.Utils.CustomCollections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IBossEnemySpawnService _bossEnemySpawnService;
        private readonly ICustomCollection<IEnemyView> _enemyCollection;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KillEnemyCounter killEnemyCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService,
            ICustomCollection<IEnemyView> enemyCollection)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
            _enemyCollection = enemyCollection ??
                                     throw new ArgumentNullException(nameof(enemyCollection));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Spawn(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void Spawn(CancellationToken cancellationToken)
        {
            try
            {
                while (_cancellationTokenSource.IsCancellationRequested == false)
                {
                    foreach (IEnemySpawnPoint spawnPoint in _enemySpawnerView.SpawnPoints)
                    {
                        _enemySpawner.SetCurrentWave(_killEnemyCounter.KillZombies);
                        SpawnEnemy(spawnPoint.Position, _enemySpawnerView.CharacterView);
                        SpawnBoss(spawnPoint.Position, _enemySpawnerView.CharacterView);
                        
                        await _enemySpawner.WaitWave(_killEnemyCounter, cancellationToken);
                        await UniTask.Delay(
                            TimeSpan.FromSeconds(
                                _enemySpawner.SpawnDelays[_enemySpawner.CurrentWave]),
                            cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void SpawnEnemy(Vector3 position, CharacterView characterView)
        {
            if (_enemySpawner.IsSpawnEnemy == false)
                  return;
            
            IEnemyView enemyView = _enemySpawnService.Spawn(_killEnemyCounter, position);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);

            _enemySpawner.SpawnedEnemies++;
        }

        private void SpawnBoss(Vector3 position, CharacterView characterView)
        {
            if (_enemySpawner.IsSpawnBoss == false)
                return;
            
            IBossEnemyView bossEnemyView = _bossEnemySpawnService.Spawn(_killEnemyCounter, position);
            bossEnemyView.SetCharacterHealth(characterView.CharacterHealthView);
            bossEnemyView.SetTargetFollow(characterView.CharacterMovementView);

            _enemySpawner.SpawnedBosses++;
            _cancellationTokenSource.Cancel();
        }
    }
}