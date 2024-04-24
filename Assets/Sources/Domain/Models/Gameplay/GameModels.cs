using Sources.Controllers.Bears.Attacks;
using Sources.Domain.Models.Bears;
using Sources.Domain.Models.Characters;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Weapons;

namespace Sources.Domain.Models.Gameplay
{
    public class GameModels
    {
        public Upgrader BearMassAttackUpgrader { get; }
        public Upgrader BearAttackUpgrader { get; }
        public Upgrader CharacterHealthUpgrader { get; }
        public Upgrader SawLauncherUpgrader { get; }
        public Upgrader SawLauncherAbilityUpgrader { get; }
        public Upgrader MiniGunAttackUpgrader { get; }
        public MiniGun MiniGun { get; }
        public CharacterHealth CharacterHealth { get; }
        public PlayerWallet PlayerWallet { get; }
        public Volume Volume { get; }
        public Level Level { get; }
        public Character Character { get; }
        public BearAttacker BearAttacker { get; }
        public Bear Bear { get; }
        public KillEnemyCounter KillEnemyCounter { get; }
        public EnemySpawner EnemySpawner { get; }

        public GameModels(
            Upgrader bearMassAttackUpgrader,
            Upgrader bearAttackUpgrader,
            Upgrader characterHealthUpgrader,
            Upgrader sawLauncherUpgrader,
            Upgrader sawLauncherAbilityUpgrader,
            Upgrader miniGunAttackUpgrader,
            MiniGun miniGun,
            CharacterHealth characterHealth,
            PlayerWallet playerWallet,
            Volume volume,
            Level level,
            Character character,
            BearAttacker bearAttacker,
            Bear bear,
            KillEnemyCounter killEnemyCounter,
            EnemySpawner enemySpawner)
        {
            BearMassAttackUpgrader = bearMassAttackUpgrader;
            BearAttackUpgrader = bearAttackUpgrader;
            CharacterHealthUpgrader = characterHealthUpgrader;
            SawLauncherUpgrader = sawLauncherUpgrader;
            SawLauncherAbilityUpgrader = sawLauncherAbilityUpgrader;
            MiniGunAttackUpgrader = miniGunAttackUpgrader;
            MiniGun = miniGun;
            CharacterHealth = characterHealth;
            PlayerWallet = playerWallet;
            Volume = volume;
            Level = level;
            Character = character;
            BearAttacker = bearAttacker;
            Bear = bear;
            KillEnemyCounter = killEnemyCounter;
            EnemySpawner = enemySpawner;
        }
    }
}