using System;
using Sources.Controllers.Spawners;
using Sources.Domain.Spawners;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Controllers.Spawners
{
    public class ItemSpawnerPresenterFactory
    {
        private readonly IFirstAidKitSpawnService _firstAidKitSpawnService;

        public ItemSpawnerPresenterFactory(IFirstAidKitSpawnService firstAidKitSpawnService)
        {
            _firstAidKitSpawnService = firstAidKitSpawnService ?? 
                                       throw new ArgumentNullException(nameof(firstAidKitSpawnService));
        }

        public ItemSpawnerPresenter Create(ItemSpawner itemSpawner, IItemSpawnerView itemSpawnerView)
        {
            return new ItemSpawnerPresenter(itemSpawner, itemSpawnerView, _firstAidKitSpawnService);
        }
    }
}