using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Constants;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.Spawners;
using Random = UnityEngine.Random;

namespace Sources.Controllers.Presenters.Spawners
{
    public class ItemSpawnerPresenter : PresenterBase
    {
        private readonly IItemSpawnerView _itemSpawnerView;
        private readonly IFirstAidKitSpawnService _firstAidKitSpawnService;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(ItemSpawnerConst.SpawnDelay);

        private CancellationTokenSource _cancellationTokenSource;

        public ItemSpawnerPresenter(
            IItemSpawnerView itemSpawnerView,
            IFirstAidKitSpawnService firstAidKitSpawnService)
        {
            _itemSpawnerView = itemSpawnerView ?? throw new ArgumentNullException(nameof(itemSpawnerView));
            _firstAidKitSpawnService = firstAidKitSpawnService;
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Spawn(_cancellationTokenSource.Token);
        }

        public override void Disable() =>
            _cancellationTokenSource.Cancel();

        private async void Spawn(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    int index = Random.Range(0, _itemSpawnerView.SpawnPoints.Count);
                    
                    IItemSpawnPoint itemSpawnPoint = _itemSpawnerView.SpawnPoints[index];
                    IFirstAidKitView firstAidKitView = _firstAidKitSpawnService.Spawn(itemSpawnPoint.Position);
                    firstAidKitView.SetHealAmount(FirstAidKitConst.HealAmount);
                    
                    await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}