using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Spawners;
using Sources.Infrastructure.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Characters;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Controllers.EnemeSpawners
{
    public class EnemySpawnerPresenter : PresenterBase
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly IEnemySpawnerView _enemySpawnerView;
        private readonly IEnemySpawnService _enemySpawnService;

        private CancellationTokenSource _cancellationTokenSource;

        public EnemySpawnerPresenter(
            EnemySpawner enemySpawner,
            IEnemySpawnerView enemySpawnerView,
            IEnemySpawnService enemySpawnService)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _enemySpawnerView = enemySpawnerView ?? throw new ArgumentNullException(nameof(enemySpawnerView));
            _enemySpawnService = enemySpawnService ?? 
                                        throw new ArgumentNullException(nameof(enemySpawnService));
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

        public async void Spawn(CancellationToken cancellationToken)
        {
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();
            
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (IEnemySpawnPointView enemySpawnPointView in _enemySpawnerView.SpawnPoints)
                    {
                        IEnemyView enemyView = _enemySpawnService.Spawn();
                        enemyView.SetPosition(enemySpawnPointView.Position);
                        enemyView.SetCharacterHealth(characterView.CharacterHealthView);
                        enemyView.SetTargetFollow(characterView.CharacterMovementView);

                        await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}