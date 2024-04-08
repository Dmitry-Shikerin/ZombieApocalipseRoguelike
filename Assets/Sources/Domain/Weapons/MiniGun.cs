using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.DomainInterfaces.Weapons;

namespace Sources.Domain.Weapons
{
    public class MiniGun : IWeapon
    {
        public MiniGun(float damage, float attackSpeed)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
        }

        public event Action Attacked;
        
        public float Damage { get; }
        public float AttackSpeed { get; }
        public bool IsReady { get; private set; } = true;

        public async void AttackAsync(CancellationToken cancellationToken)
        {
            if (IsReady == false)
                return;

            await StartTimer(cancellationToken);

            Attacked?.Invoke();
        }

        private async UniTask StartTimer(CancellationToken cancellationToken)
        {
            IsReady = false;
            
            await UniTask.Delay(TimeSpan.FromSeconds(AttackSpeed), cancellationToken: cancellationToken);
            
            IsReady = true;
        }

    }
}