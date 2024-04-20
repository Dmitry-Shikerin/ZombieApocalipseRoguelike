using System;
using System.Collections.Generic;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;

namespace Sources.Domain.Data.Ids
{
    public static class ModelId
    {
        public const string SawLauncherAbilityUpgrader = "SawLauncherAbilityUpgrader";
        public const string SawLauncherUpgrader = "SawLauncherUpgrader";
        public const string PlayerWallet = "PlayerWallet";
        public const string MiniGunAttackUpgrader = "MiniGunAttackUpgrader";
        public const string CharacterHealthUpgrader = "CharacterHealthUpgrader";
        public const string BearAttackUpgrader = "BearAttackUpgrader";
        public const string BearMassAttackUpgrader = "BearMassAttackUpgrader";
        
        //todo переделать
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
             SawLauncherAbilityUpgrader,
             SawLauncherUpgrader,
             PlayerWallet,
             MiniGunAttackUpgrader,
             CharacterHealthUpgrader,
             BearAttackUpgrader,
             BearMassAttackUpgrader
        };

        public static IReadOnlyDictionary<string, Type> ModelTypes = new Dictionary<string, Type>()
        {
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