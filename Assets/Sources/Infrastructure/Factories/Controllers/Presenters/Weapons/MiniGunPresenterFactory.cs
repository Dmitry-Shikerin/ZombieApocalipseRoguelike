using System;
using Sources.Controllers.Weapons;
using Sources.Domain.Models.Weapons;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Factories.Controllers.Weapons
{
    public class MiniGunPresenterFactory
    {
        private readonly IBulletSpawnService _bulletSpawnService;

        public MiniGunPresenterFactory(IBulletSpawnService bulletSpawnService)
        {
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
        }

        public MiniGunPresenter Create(MiniGun miniGun, IMiniGunView miniGunView)
        {
            return new MiniGunPresenter(miniGun, miniGunView, _bulletSpawnService);
        }
    }
}