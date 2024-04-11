using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Upgrades;
using Sources.DomainInterfaces.Weapons;

namespace Sources.Domain.Weapons
{
    public class MiniGun : IWeapon
    {
        public MiniGun(
            Upgrader miniGunAttackUpgrader,
            float attackSpeed)
        {
            MiniGunAttackUpgrader = miniGunAttackUpgrader;
            AttackSpeed = attackSpeed;
        }

        public event Action Attacked;

        public Upgrader MiniGunAttackUpgrader { get; }
        public float Damage => MiniGunAttackUpgrader.CurrentAmount;
        public float AttackSpeed { get; }
        public bool IsReady { get; private set; } = true;

        public async void AttackAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (IsReady == false)
                    return;

                await StartTimer(cancellationToken);

                Attacked?.Invoke();
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask StartTimer(CancellationToken cancellationToken)
        {
            IsReady = false;
            
            await UniTask.Delay(TimeSpan.FromSeconds(AttackSpeed), cancellationToken: cancellationToken);
            
            IsReady = true;
        }

    }
}