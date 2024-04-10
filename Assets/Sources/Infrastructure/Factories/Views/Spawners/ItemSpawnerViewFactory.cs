using System;
using Sources.Controllers.Spawners;
using Sources.Domain.Spawners;
using Sources.Infrastructure.Factories.Controllers.Spawners;
using Sources.Presentations.Views.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;

namespace Sources.Infrastructure.Factories.Views.Spawners
{
    public class ItemSpawnerViewFactory
    {
        private readonly ItemSpawnerPresenterFactory _itemSpawnerPresenterFactory;

        public ItemSpawnerViewFactory(ItemSpawnerPresenterFactory itemSpawnerPresenterFactory)
        {
            _itemSpawnerPresenterFactory = itemSpawnerPresenterFactory ?? 
                                           throw new ArgumentNullException(nameof(itemSpawnerPresenterFactory));
        }

        public IItemSpawnerView Create(ItemSpawner itemSpawner, ItemSpawnerView itemSpawnerView)
        {
            ItemSpawnerPresenter itemSpawnerPresenter =
                _itemSpawnerPresenterFactory.Create(itemSpawner, itemSpawnerView);
            
            itemSpawnerView.Construct(itemSpawnerPresenter);
            
            return itemSpawnerView;
        }
    }
}