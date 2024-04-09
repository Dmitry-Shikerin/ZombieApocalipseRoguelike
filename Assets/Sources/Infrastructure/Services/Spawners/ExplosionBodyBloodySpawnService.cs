using System;
using Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using UnityEngine;

namespace Sources.Infrastructure.Services.Spawners
{
    public class ExplosionBodyBloodySpawnService : IExplosionBodyBloodySpawnService
    {
        private readonly IObjectPool<ExplosionBodyBloodyView> _objectPool;
        private readonly IExplosionBodyBloodyViewFactory _viewFactory;

        public ExplosionBodyBloodySpawnService(
            IObjectPool<ExplosionBodyBloodyView> objectPool,
            IExplosionBodyBloodyViewFactory viewFactory)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IExplosionBodyBloodyView Spawn(Vector3 position)
        {
            return SpawnFromPool(position) ?? _viewFactory.Create(position);
        }
        
        private IExplosionBodyBloodyView SpawnFromPool(Vector3 position)
        {
            ExplosionBodyBloodyView explosionBodyBloodyView = _objectPool.Get<ExplosionBodyBloodyView>();

            if (explosionBodyBloodyView == null)
                return null;
            
            return _viewFactory.Create(explosionBodyBloodyView, position);
        }
    }
}