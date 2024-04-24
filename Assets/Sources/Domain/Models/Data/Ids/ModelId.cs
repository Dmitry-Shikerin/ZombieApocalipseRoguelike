using System;
using System.Collections.Generic;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Setting;
using Sources.Domain.Players;
using Sources.Domain.Setting;
using Sources.Domain.Upgrades;

namespace Sources.Domain.Models.Data.Ids
{
    public static class ModelId
    {
        //gameModels
        public const string SawLauncherAbilityUpgrader = "SawLauncherAbilityUpgrader";
        public const string SawLauncherUpgrader = "SawLauncherUpgrader";
        public const string PlayerWallet = "PlayerWallet";
        public const string MiniGunAttackUpgrader = "MiniGunAttackUpgrader";
        public const string CharacterHealthUpgrader = "CharacterHealthUpgrader";
        public const string BearAttackUpgrader = "BearAttackUpgrader";
        public const string BearMassAttackUpgrader = "BearMassAttackUpgrader";
        public const string KillEnemyCounter = "KillEnemyCounter";
        
        //commonModels
        public const string Volume = "Volume";
        public const string GameData = "GameData";
        public const string Tutorial = "Tutorial";
        public const string FirstLevel = "FirstLevel";
        public const string SecondLevel = "SecondLevel";
        public const string ThirdLevel = "ThirdLevel";
        public const string FourthLevel = "FourthLevel";
        
        //todo переделать
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
             SawLauncherAbilityUpgrader,
             SawLauncherUpgrader,
             PlayerWallet,
             MiniGunAttackUpgrader,
             CharacterHealthUpgrader,
             BearAttackUpgrader,
             BearMassAttackUpgrader,
             KillEnemyCounter,
        };

        public static IReadOnlyDictionary<string, Type> ModelTypes = new Dictionary<string, Type>()
        {
            [KillEnemyCounter] = typeof(KillEnemyCounter),
            [Tutorial] = typeof(Tutorial),
            [GameData] = typeof(GameData),
            [Volume] = typeof(Volume),
            [FirstLevel] = typeof(Level),
            [SecondLevel] = typeof(Level),
            [ThirdLevel] = typeof(Level),
            [FourthLevel] = typeof(Level),
            [SawLauncherAbilityUpgrader] = typeof(Upgrader),
            [SawLauncherUpgrader] = typeof(Upgrader),
            [PlayerWallet] = typeof(PlayerWallet),
            [MiniGunAttackUpgrader] = typeof(Upgrader),
            [CharacterHealthUpgrader] = typeof(Upgrader),
            [BearAttackUpgrader] = typeof(Upgrader),
            [BearMassAttackUpgrader] = typeof(Upgrader),
        };
    }
}