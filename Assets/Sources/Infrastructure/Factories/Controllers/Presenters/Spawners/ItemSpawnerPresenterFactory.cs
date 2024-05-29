using System;
using Sources.Controllers.Presenters.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Spawners
{
    public class ItemSpawnerPresenterFactory
    {
        private readonly IFirstAidKitSpawnService _firstAidKitSpawnService;

        public ItemSpawnerPresenterFactory(IFirstAidKitSpawnService firstAidKitSpawnService)
        {
            _firstAidKitSpawnService = firstAidKitSpawnService ??
                                       throw new ArgumentNullException(nameof(firstAidKitSpawnService));
        }

        public ItemSpawnerPresenter Create(IItemSpawnerView itemSpawnerView) =>
            new (itemSpawnerView, _firstAidKitSpawnService);
    }
}