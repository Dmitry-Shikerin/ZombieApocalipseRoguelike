using System;
using Sources.Domain.Models.Upgrades;

namespace Sources.Domain.Models.Bears.Attacks
{
    public class BearAttacker
    {
        private readonly Upgrader _attackUpgrader;
        private readonly Upgrader _massAttackUpgrader;

        public BearAttacker(
            Upgrader bearAttackUpgrader,
            Upgrader bearMassAttackUpgrader)
        {
            _attackUpgrader = bearAttackUpgrader ??
                                 throw new ArgumentNullException(nameof(bearAttackUpgrader));
            _massAttackUpgrader = bearMassAttackUpgrader ??
                                     throw new ArgumentNullException(nameof(bearMassAttackUpgrader));
        }

        public float Damage => _attackUpgrader.CurrentAmount;

        public int UnitsPerAttack => (int)_massAttackUpgrader.CurrentAmount;
    }
}