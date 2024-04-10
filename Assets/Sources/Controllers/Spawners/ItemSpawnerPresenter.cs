using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Spawners;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Controllers.Spawners
{
    public class ItemSpawnerPresenter : PresenterBase
    {
        private readonly ItemSpawner _itemSpawner;
        private readonly IItemSpawnerView _itemSpawnerView;
        private readonly IFirstAidKitSpawnService _firstAidKitSpawnService;

        private CancellationTokenSource _cancellationTokenSource;

        public ItemSpawnerPresenter(
            ItemSpawner itemSpawner, 
            IItemSpawnerView itemSpawnerView,
            IFirstAidKitSpawnService firstAidKitSpawnService)
        {
            _itemSpawner = itemSpawner ?? throw new ArgumentNullException(nameof(itemSpawner));
            _itemSpawnerView = itemSpawnerView ?? throw new ArgumentNullException(nameof(itemSpawnerView));
            _firstAidKitSpawnService = firstAidKitSpawnService;
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
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    foreach (IItemSpawnPoint itemSpawnPoint in _itemSpawnerView.SpawnPoints)
                    {
                        IFirstAidKitView enemyView = _firstAidKitSpawnService.Spawn(itemSpawnPoint.Position);

                        await UniTask.Delay(TimeSpan.FromSeconds(30), cancellationToken: cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}