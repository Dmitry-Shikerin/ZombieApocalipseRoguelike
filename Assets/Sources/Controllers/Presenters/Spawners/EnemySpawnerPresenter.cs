using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Spawners;
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
        private readonly IEnemyCollectorService _enemyCollectorService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            KillEnemyCounter killEnemyCounter,
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService,
            IEnemyCollectorService enemyCollectorService)
        {
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _enemySpawnService = enemySpawnService ?? throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
            _enemyCollectorService = enemyCollectorService ??
                                     throw new ArgumentNullException(nameof(enemyCollectorService));
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
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();

            try
            {
                while (_cancellationTokenSource.IsCancellationRequested == false)
                {
                    foreach (IEnemySpawnPoint spawnPoint in _enemySpawnerView.SpawnPoints)
                    {
                        SetCurrentWave();
                        TrySpawnEnemy(spawnPoint, characterView);
                        TrySpawnBoss(spawnPoint, characterView);

                        await WaitWave(cancellationToken);

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

        private async UniTask WaitWave(CancellationToken cancellationToken)
        {
            foreach (int sumEnemies in _enemySpawner.SumEnemiesInWave)
            {
                if (_enemySpawner.SpawnedEnemies == sumEnemies)
                {
                    await UniTask.WaitUntil(() =>
                            _killEnemyCounter.KillZombies == sumEnemies,
                        cancellationToken: cancellationToken);
                }
            }
        }

        private void SetCurrentWave()
        {
            for (int i = 0; i < _enemySpawner.SumEnemiesInWave.Count; i++)
            {
                if (_killEnemyCounter.KillZombies >= _enemySpawner.SumEnemiesInWave[i])
                {
                    //TODO будет ли тут out of range?
                    if(i == _enemySpawner.SumEnemiesInWave.Count)
                        return;
                    
                    _enemySpawner.CurrentWave = i + 1;
                    // Debug.Log($"Kill zombies: {_killEnemyCounter.KillZombies}");
                    // Debug.Log($"Sum enemies: {_enemySpawner.SumEnemiesInWave[i]}");
                    // Debug.Log($"Current wave: {_enemySpawner.CurrentWave}");
                }
            }
        }

        private void TrySpawnEnemy(IEnemySpawnPoint spawnPoint, CharacterView characterView)
        {
            if (_enemySpawner.SpawnedEnemies < _enemySpawner.SumEnemies)
                SpawnEnemy(spawnPoint.Position, characterView);
        }

        private void TrySpawnBoss(IEnemySpawnPoint spawnPoint, CharacterView characterView)
        {
            if (_enemySpawner.SpawnedEnemies >= _enemySpawner.SumEnemies && _enemySpawner.BossCounter == 0)
            {
                SpawnBoss(spawnPoint.Position, characterView);

                _cancellationTokenSource.Cancel();
            }
        }

        private void SpawnEnemy(Vector3 position, CharacterView characterView)
        {
            IEnemyView enemyView = _enemySpawnService.Spawn(_killEnemyCounter, position);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);

            _enemySpawner.SpawnedEnemies++;
        }

        private void SpawnBoss(Vector3 position, CharacterView characterView)
        {
            IBossEnemyView bossEnemyView = _bossEnemySpawnService.Spawn(_killEnemyCounter, position);
            bossEnemyView.DisableNavmeshAgent();
            bossEnemyView.SetPosition(position);
            bossEnemyView.EnableNavmeshAgent();
            bossEnemyView.SetCharacterHealth(characterView.CharacterHealthView);
            bossEnemyView.SetTargetFollow(characterView.CharacterMovementView);

            _enemySpawner.BossCounter++;
        }
    }
}