using System.Collections.Generic;
using Sources.Controllers.Spawners;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class ItemSpawnerView : PresentableView<ItemSpawnerPresenter>, IItemSpawnerView
    {
        [SerializeField] private List<ItemSpawnPoint> _itemSpawnPoints;

        public IReadOnlyList<IItemSpawnPoint> SpawnPoints => _itemSpawnPoints;
    }
}