using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.PresentationsInterfaces.Views.Enemies.Bosses;
using Sources.PresentationsInterfaces.Views.Spawners;
using Object = UnityEngine.Object;

namespace Sources.Controllers.Spawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IBossEnemySpawnService _bossEnemySpawnService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            IEnemySpawnService enemySpawnService,
            IBossEnemySpawnService bossEnemySpawnService)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _enemySpawnService = enemySpawnService ?? 
                                        throw new ArgumentNullException(nameof(enemySpawnService));
            _bossEnemySpawnService = bossEnemySpawnService ?? 
                                     throw new ArgumentNullException(nameof(bossEnemySpawnService));
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

            int bossCounter = 0;
            
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (IEnemySpawnPoint enemySpawnPointView in _enemySpawnerView.SpawnPoints)
                    {
                        if (bossCounter == 0)
                        {
                            SpawnBoss(enemySpawnPointView, characterView);
                            bossCounter++;
                            
                            await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);
                            
                            continue;
                        }
                        
                        // SpawnEnemy(enemySpawnPointView, characterView);

                        await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void SpawnEnemy(IEnemySpawnPoint enemySpawnPointView, CharacterView characterView)
        {
            IEnemyView enemyView = _enemySpawnService.Spawn();
            enemyView.SetPosition(enemySpawnPointView.Position);
            enemyView.SetCharacterHealth(characterView.CharacterHealthView);
            enemyView.SetTargetFollow(characterView.CharacterMovementView);
        }

        private void SpawnBoss(IEnemySpawnPoint enemySpawnPoint, CharacterView characterView)
        {
            IBossEnemyView bossEnemyView = _bossEnemySpawnService.Spawn(enemySpawnPoint.Position);
            bossEnemyView.SetCharacterHealth(characterView.CharacterHealthView);
            bossEnemyView.SetTargetFollow(characterView.CharacterMovementView);
        }
    }
}