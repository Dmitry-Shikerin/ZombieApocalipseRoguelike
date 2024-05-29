using System;
using Sources.Domain.Models.Constants;
using Sources.InfrastructureInterfaces.Factories.Views.ExplosionBodyBloodyViews;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.ExplosionBodyBloodies;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.ExplosionBodyBloodyViews
{
    public class ExplosionBodyBloodyViewFactory : IExplosionBodyBloodyViewFactory
    {
        private readonly IObjectPool<ExplosionBodyBloodyView> _objectPool;

        public ExplosionBodyBloodyViewFactory(IObjectPool<ExplosionBodyBloodyView> objectPool)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        }

        public IExplosionBodyBloodyView Create(
            ExplosionBodyBloodyView explosionBodyBloodyView,
            Vector3 position)
        {
            return explosionBodyBloodyView;
        }

        public IExplosionBodyBloodyView Create(Vector3 position)
        {
            ExplosionBodyBloodyView explosionBodyBloodyView = CreateView();

            return explosionBodyBloodyView;
        }

        private ExplosionBodyBloodyView CreateView()
        {
            ExplosionBodyBloodyView explosionBodyBloodyView =
                Object.Instantiate(
                    Resources.Load<ExplosionBodyBloodyView>(PrefabPath.ExplosionBodyBloody));

            explosionBodyBloodyView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return explosionBodyBloodyView;
        }
    }
}