using System;
using Sources.Domain.Models.Upgrades;

namespace Sources.Controllers.Bears.Attacks
{
    public class BearAttacker
    {
        public BearAttacker(
            Upgrader bearAttackUpgrader, 
            Upgrader bearMassAttackUpgrader)
        {
            BearAttackUpgrader = bearAttackUpgrader ?? 
                                 throw new ArgumentNullException(nameof(bearAttackUpgrader));
            BearMassAttackUpgrader = bearMassAttackUpgrader ??
                                     throw new ArgumentNullException(nameof(bearMassAttackUpgrader));
        }

        public Upgrader BearAttackUpgrader { get; }
        public Upgrader BearMassAttackUpgrader { get; }

        public float Damage => BearAttackUpgrader.CurrentAmount;
        public int UnitsPerAttack => (int)BearMassAttackUpgrader.CurrentAmount;
    }
}