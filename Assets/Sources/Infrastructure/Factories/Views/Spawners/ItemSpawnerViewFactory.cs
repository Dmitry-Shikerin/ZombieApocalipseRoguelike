using System;
using Sources.Controllers.Presenters.Spawners;
using Sources.Infrastructure.Factories.Controllers.Presenters.Spawners;
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

        public IItemSpawnerView Create(ItemSpawnerView itemSpawnerView)
        {
            ItemSpawnerPresenter itemSpawnerPresenter =
                _itemSpawnerPresenterFactory.Create(itemSpawnerView);

            itemSpawnerView.Construct(itemSpawnerPresenter);

            return itemSpawnerView;
        }
    }
}