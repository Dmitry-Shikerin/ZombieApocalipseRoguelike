using System;
using Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using UnityEngine;

namespace Sources.Infrastructure.Services.Spawners
{
    public class FirstAidKitSpawnService : IFirstAidKitSpawnService
    {
        private readonly IObjectPool<FirstAidKitView> _objectPool;
        private readonly IFirstAidKitViewFactory _viewFactory;

        public FirstAidKitSpawnService(
            IObjectPool<FirstAidKitView> objectPool,
            IFirstAidKitViewFactory viewFactory)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }
        public IFirstAidKitView Spawn(Vector3 position)
        {
            IFirstAidKitView view = SpawnFromPool(position) ?? _viewFactory.Create(position);
            
            view.SetPosition(position);
            view.Show();
            
            return view;
        }
        
        private FirstAidKitView SpawnFromPool(Vector3 position)
        {
            FirstAidKitView firstAidKitView = _objectPool.Get<FirstAidKitView>();

            if (firstAidKitView == null)
                return null;

            return firstAidKitView;
        }
    }
}