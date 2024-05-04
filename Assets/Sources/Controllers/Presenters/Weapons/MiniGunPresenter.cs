using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Weapons;
using Sources.InfrastructureInterfaces.Services.PauseServices;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.InfrastructureInterfaces.Services.Volumes;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Controllers.Presenters.Weapons
{
    public class MiniGunPresenter : PresenterBase
    {
        private readonly MiniGun _miniGun;
        private readonly IMiniGunView _miniGunView;
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly IVolumeService _volumeService;
        private readonly IPauseService _pauseService;

        public MiniGunPresenter(
            MiniGun miniGun,
            IMiniGunView miniGunView,
            IBulletSpawnService bulletSpawnService,
            IVolumeService volumeService,
            IPauseService pauseService)
        {
            _miniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        //TODO сделать отдельную громкость для минигана
        public override void Enable()
        {
            _miniGunView.ShootAudioSource.SetLoop();
            _miniGun.Attacked += OnAttack;
            _miniGun.AttackEnded += OnAttackEnded;
            _volumeService.MiniGunVolumeChanged += OnMiniGunVolumeChanged;
            _pauseService.PauseActivated += OnPauseActivated;
            _pauseService.ContinueActivated += ContinueActivated;
        }

        public override void Disable()
        {
            _miniGun.Attacked -= OnAttack;
            _miniGun.AttackEnded -= OnAttackEnded;
            _volumeService.MiniGunVolumeChanged -= OnMiniGunVolumeChanged;
            _pauseService.PauseActivated -= OnPauseActivated;
            _pauseService.ContinueActivated -= ContinueActivated;
        }

        private void ContinueActivated()
        {
            _miniGunView.ShootAudioSource.UnPause();
            _miniGunView.EndShootAudioSource.UnPause();
        }

        private void OnPauseActivated()
        {
            _miniGunView.ShootAudioSource.Pause();
            _miniGunView.EndShootAudioSource.Pause();
        }

        private void OnMiniGunVolumeChanged()
        {
            _miniGunView.ShootAudioSource.SetVolume(_volumeService.MusicVolume);
            _miniGunView.EndShootAudioSource.SetVolume(_volumeService.MusicVolume);
        }

        private void OnAttackEnded()
        {
            if(_miniGun.IsShooting == false)
                return;
            
            _miniGun.IsShooting = false;
            _miniGunView.ShootAudioSource.Stop();
            _miniGunView.EndShootAudioSource.Play();
        }
        //TODO в сервисе для музыки сделать вейтАнтил и проверять аудиокли на ис Плеинг

        private void OnAttack()
        {
            _bulletSpawnService.Spawn(_miniGunView);
            
            if (_miniGun.IsShooting == false)
            {
                _miniGunView.EndShootAudioSource.Stop();
                _miniGunView.ShootAudioSource.Play();
                _miniGun.IsShooting = true;
            }
            
            _miniGunView.PlayFireParticles();
        }

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_miniGun.Damage);
    }
}