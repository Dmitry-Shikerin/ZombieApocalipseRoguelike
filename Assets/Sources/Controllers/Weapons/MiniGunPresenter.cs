using System;
using Sources.Controllers.Common;
using Sources.Domain.Weapons;
using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Weapons;

namespace Sources.Controllers.Weapons
{
    public class MiniGunPresenter : PresenterBase
    {
        private readonly MiniGun _miniGun;
        private readonly IMiniGunView _miniGunView;

        public MiniGunPresenter(
            MiniGun miniGun,
            IMiniGunView miniGunView)
        {
            _miniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));
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
        }

        public void DealDamage(IEnemyHealthView enemyHealthView) =>
            enemyHealthView.TakeDamage(_miniGun.Damage);
    }
}