using Sources.DomainInterfaces.Upgrades;

namespace Sources.Domain.Abilities
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