﻿using System;
using System.Collections.Generic;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;

namespace Sources.Domain.Data.Ids
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
        
        //commonModels
        public const string Volume = "Volume";
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