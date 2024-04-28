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
using Object = UnityEngine.Object;

namespace Sources.Controllers.Presenters.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly KillEnemyCounter _killEnemyCounter;
        private readonly EnemySpawner _enemySpawner;
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
            _enemySpawnService = enemySpawnService ??
                                 throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ??
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
            _enemyCollectorService = enemyCollectorService ?? throw new ArgumentNullException(nameof(enemyCollectorService));
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

        //TODO вынести эту логику в сирвис и подменять сервис в сцен контесте
        //TODO сделать отдельный мноинсталлер для сервиса
        private async void Spawn(CancellationToken cancellationToken)
        {
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();

            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (IEnemySpawnPoint enemySpawnPointView in _enemySpawnerView.SpawnPoints)
                    {
                        SpawnEnemy(enemySpawnPointView, characterView);
                        
                        for (int i = 0; i < _enemySpawner.EnemyInWave.Count; i++)
                        {
                            if (_enemySpawner.EnemyInWave[i] >= _killEnemyCounter.KillZombies)
                            {
                                _enemySpawner.CurrentStepDelay = i;
                            }
                        }

                        if (_enemySpawner.BossCounter == 0 && 
                            _killEnemyCounter.KillZombies == 
                            _enemySpawner.SumEnemies)
                        {

                            SpawnBoss(enemySpawnPointView, characterView);
                            _enemySpawner.BossCounter++;

                            await UniTask.WaitWhile(
                                () => _enemyCollectorService.Enemies.Count > 0,
                                cancellationToken: cancellationToken);

                            // _viewFormService.Show<LevelCompletedFormView>();
                            _cancellationTokenSource.Cancel();
                            
                            continue;
                        }

                        await UniTask.Delay(TimeSpan.FromSeconds(
                            _enemySpawner.SpawnDelays[_enemySpawner.CurrentStepDelay]),
                            cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void SpawnEnemy(IEnemySpawnPoint enemySpawnPointView, CharacterView characterView)
        {
            IEnemyView enemyView = _enemySpawnService.Spawn(_killEnemyCounter);
            enemyView.SetPosition(enemySpawnPointView.Position);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);
        }

        private void SpawnBoss(IEnemySpawnPoint enemySpawnPoint, CharacterView characterView)
        {
            IBossEnemyView bossEnemyView = _bossEnemySpawnService.Spawn(_killEnemyCounter, enemySpawnPoint.Position);
            bossEnemyView.SetCharacterHealth(characterView.CharacterHealthView);
            bossEnemyView.SetTargetFollow(characterView.CharacterMovementView);
        }
    }
}