using System;
using Sources.Controllers.Presenters.Weapons;
using Sources.Domain.Models.Weapons;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Weapons
{
    public class MiniGunPresenterFactory
    {
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly IPauseService _pauseService;
        private readonly IVolumeService _volumeService;

        public MiniGunPresenterFactory(
            IBulletSpawnService bulletSpawnService,
            IPauseService pauseService,
            IVolumeService volumeService)
        {
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
        }

        public MiniGunPresenter Create(MiniGun miniGun, IMiniGunView miniGunView)
        {
            return new MiniGunPresenter(
                miniGun,
                miniGunView,
                _bulletSpawnService,
                _volumeService,
                _pauseService);
        }
    }
}