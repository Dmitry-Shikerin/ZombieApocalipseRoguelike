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
        private readonly IBulletSpawner _bulletSpawner;

        public MiniGunPresenter(
            MiniGun miniGun,
            IMiniGunView miniGunView,
            IBulletSpawner bulletSpawner)
        {
            _miniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));
            _bulletSpawner = bulletSpawner ?? throw new ArgumentNullException(nameof(bulletSpawner));
        }

        public override void Enable()
        {
            _miniGun.Attacked += OnAttack;
        }

        public override void Disable()
        {
            _miniGun.Attacked -= OnAttack;
        }

        //TODO как сделать грамотнее?
        private void OnAttack()
        {
            _bulletSpawner.Spawn(_miniGunView);
            Debug.Log($"MiniGun attack");
        }

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_miniGun.Damage);
    }
}