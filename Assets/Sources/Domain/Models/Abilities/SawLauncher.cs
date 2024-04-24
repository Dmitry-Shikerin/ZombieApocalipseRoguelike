using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Models.Abilities
{
    public class SawLauncher
    {
        public IUpgrader Upgrader { get; }

        public SawLauncher(IUpgrader upgrader)
        {
            Upgrader = upgrader;
        }

        public float Damage => Upgrader.CurrentAmount;
    }
}