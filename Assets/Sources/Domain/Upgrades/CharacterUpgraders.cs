namespace Sources.Domain.Upgrades
{
    public class CharacterUpgraders
    {
        public CharacterUpgraders(
            Upgrader sawAbilityUpgrader)
        {
            SawAbilityUpgrader = sawAbilityUpgrader;
        }

        public Upgrader SawAbilityUpgrader { get; }
    }
}