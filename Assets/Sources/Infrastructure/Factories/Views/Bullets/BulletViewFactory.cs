using System;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Sources.PresentationsInterfaces.Views.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Bullets
{
    public class BulletViewFactory : IBulletViewFactory
    {
        private readonly IObjectPool<BulletView> _objectPool;

        public BulletViewFactory(IObjectPool<BulletView> objectPool)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        }

        public IBulletView Create(IMiniGunView miniGunView)
        {
            BulletView bulletView = CreateView();

            return Create(bulletView, miniGunView);
        }

        public IBulletView Create(BulletView bulletView, IMiniGunView miniGunView)
        {
            bulletView.Construct(miniGunView);
            bulletView.SetParent(null);
            bulletView.SetPosition(miniGunView.BulletSpawnPoint.Transform.position);
            bulletView.SetRotation(miniGunView.BulletSpawnPoint.Transform.rotation);
            
            return bulletView;
        }

        private BulletView CreateView()
        {
            BulletView bulletView = Object.Instantiate(
                Resources.Load<BulletView>("Views/BulletView"));

            bulletView
                .AddComponent<PoolableObject>()
                .SetPool(_objectPool);

            return bulletView;
        }
    }
}