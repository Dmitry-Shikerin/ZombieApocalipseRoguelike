﻿using System;
using Sources.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Bullets;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Services.Spawners
{
    public class BulletSpawner : IBulletSpawner
    {
        private readonly IObjectPool<BulletView> _objectPool;
        private readonly IBulletViewFactory _bulletViewFactory;

        public BulletSpawner(
            IObjectPool<BulletView> objectPool,
            IBulletViewFactory bulletViewFactory)
        {
            _objectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
            _bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
        }

        //TODo пойдет ли?
        public IBulletView Spawn(IMiniGunView miniGunView) =>
            SpawnFromPool(miniGunView) ?? _bulletViewFactory.Create(miniGunView);

        private IBulletView SpawnFromPool(IMiniGunView miniGunView)
        {
            BulletView bulletView = _objectPool.Get<BulletView>();

            if (bulletView == null)
                return null;
            
            return _bulletViewFactory.Create(bulletView, miniGunView);
        }
    }
}