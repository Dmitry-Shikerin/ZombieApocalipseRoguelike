using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Models.Weapons;

namespace Sources.Domain.Models.Weapons
{
    public class MiniGun : IWeapon
    {
        private readonly Upgrader _upgrader;
        private readonly float _attackSpeed;

        private bool _isEnded;


        public MiniGun(
            Upgrader upgrader,
            float attackSpeed)
        {
            _upgrader = upgrader;
            _attackSpeed = attackSpeed;
        }

        public event Action Attacked;
        public event Action AttackEnded;

        public float Damage => _upgrader.CurrentAmount;
        public bool IsReady { get; private set; } = true;
        public bool IsShooting { get; set; }

        public async void AttackAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (IsReady == false)
                    return;

                await StartTimer(cancellationToken);

                _isEnded = false;
                Attacked?.Invoke();
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void EndAttack()
        {
            if(_isEnded)
                return;
                
            AttackEnded?.Invoke();
            _isEnded = true;
        }

        private async UniTask StartTimer(CancellationToken cancellationToken)
        {
            IsReady = false;
            
            await UniTask.Delay(TimeSpan.FromSeconds(_attackSpeed), cancellationToken: cancellationToken);
            
            IsReady = true;
        }
    }
}