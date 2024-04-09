using System;
using Sources.Controllers.Common;
using Sources.Domain.Weapons;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Controllers.Weapons
{
    public class MiniGunPresenter : PresenterBase
    {
        private readonly MiniGun _miniGun;
        private readonly IMiniGunView _miniGunView;
        private readonly IBulletSpawnService _bulletSpawnService;

        public MiniGunPresenter(
            MiniGun miniGun,
            IMiniGunView miniGunView,
            IBulletSpawnService bulletSpawnService)
        {
            _miniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));
            _bulletSpawnService = bulletSpawnService ?? throw new ArgumentNullException(nameof(bulletSpawnService));
        }

        public override void Enable() =>
            _miniGun.Attacked += OnAttack;

        public override void Disable() =>
            _miniGun.Attacked -= OnAttack;

        private void OnAttack()
        {
            _bulletSpawnService.Spawn(_miniGunView);
            _miniGunView.PlayFireParticles();
        }

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_miniGun.Damage);
    }
}