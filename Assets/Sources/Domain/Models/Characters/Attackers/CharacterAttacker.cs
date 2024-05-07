﻿using System;
using System.Threading;
using Sources.DomainInterfaces.Models.Weapons;

namespace Sources.Domain.Models.Characters.Attackers
{
    public class CharacterAttacker
    {
        public CharacterAttacker(IWeapon weapon)
        {
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public IWeapon Weapon { get; }

        public void Attack(CancellationToken cancellationToken) =>
            Weapon.AttackAsync(cancellationToken);

        public void EndAttack() =>
            Weapon.EndAttack();
    }
}