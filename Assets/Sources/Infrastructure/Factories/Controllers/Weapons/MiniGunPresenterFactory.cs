using System;
using Sources.Controllers.Weapons;
using Sources.Domain.Weapons;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Factories.Controllers.Weapons
{
    public class MiniGunPresenterFactory
    {
        private readonly IBulletSpawner _bulletSpawner;

        public MiniGunPresenterFactory(IBulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner ?? throw new ArgumentNullException(nameof(bulletSpawner));
        }

        public MiniGunPresenter Create(MiniGun miniGun, IMiniGunView miniGunView)
        {
            return new MiniGunPresenter(miniGun, miniGunView, _bulletSpawner);
        }
    }
}