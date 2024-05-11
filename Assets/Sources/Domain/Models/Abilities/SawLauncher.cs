using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Models.Abilities
{
    public class SawLauncher
    {
        private IUpgrader _upgrader;

        public SawLauncher(IUpgrader upgrader)
        {
            _upgrader = upgrader;
        }

        public float Damage => _upgrader.CurrentAmount;
    }
}