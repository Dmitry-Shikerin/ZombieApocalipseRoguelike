using System;
using System.Collections.Generic;

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
        public const string Gameplay = "Gameplay";
        public const string Gameplay2 = "Gameplay2";
        public const string Gameplay3 = "Gameplay3";
        public const string Gameplay4 = "Gameplay4";

        public static IReadOnlyList<string> DeletedModelsIds = new List<string>()
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
        
        //todo переделать
        public static IReadOnlyList<string> ModelsIds = new List<string>()
        {
            Gameplay,
            Volume,
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
            [KillEnemyCounter] = typeof(KillEnemyCounterDto),
            [Tutorial] = typeof(TutorialDto),
            [GameData] = typeof(GameDataDto),
            [Volume] = typeof(VolumeDto),
            [Gameplay] = typeof(LevelDto),
            [Gameplay2] = typeof(LevelDto),
            [Gameplay3] = typeof(LevelDto),
            [Gameplay4] = typeof(LevelDto),
            [SawLauncherAbilityUpgrader] = typeof(UpgradeDto),
            [SawLauncherUpgrader] = typeof(UpgradeDto),
            [PlayerWallet] = typeof(PlayerWalletDto),
            [MiniGunAttackUpgrader] = typeof(UpgradeDto),
            [CharacterHealthUpgrader] = typeof(UpgradeDto),
            [BearAttackUpgrader] = typeof(UpgradeDto),
            [BearMassAttackUpgrader] = typeof(UpgradeDto),
        };
    }
}