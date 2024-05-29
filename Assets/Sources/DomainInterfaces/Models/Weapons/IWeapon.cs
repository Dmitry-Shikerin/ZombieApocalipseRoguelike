using System;
using System.Threading;

namespace Sources.DomainInterfaces.Models.Weapons
{
    public interface IWeapon
    {
        event Action Attacked;

        float Damage { get; }

        bool IsReady { get; }

        void AttackAsync(CancellationToken cancellationToken);

        void EndAttack();
    }
}