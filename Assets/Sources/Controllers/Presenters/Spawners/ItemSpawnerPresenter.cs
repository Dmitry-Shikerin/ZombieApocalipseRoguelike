using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Spawners;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.Spawners;
using Random = UnityEngine.Random;

namespace Sources.Controllers.Spawners
{
    public class ItemSpawnerPresenter : PresenterBase
    {
        private readonly ItemSpawner _itemSpawner;
        private readonly IItemSpawnerView _itemSpawnerView;
        private readonly IFirstAidKitSpawnService _firstAidKitSpawnService;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(ItemSpawnerConstant.SpawnDelay);

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

        private async void Spawn(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    int index = Random.Range(0, _itemSpawnerView.SpawnPoints.Count);
                    
                    IItemSpawnPoint itemSpawnPoint = _itemSpawnerView.SpawnPoints[index];
                    IFirstAidKitView firstAidKitView = _firstAidKitSpawnService.Spawn(itemSpawnPoint.Position);
                    
                    firstAidKitView.SetHealAmount(FirstAidKitConstant.HealAmount);
                    
                    await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}