using System.Collections.Generic;
using Sources.Domain.Models.Upgrades.Configs.Dictionaries;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Domain.Models.Upgrades.Configs
{
    [CreateAssetMenu(
        fileName = "SawLauncherAbilityUpgradeMap", 
        menuName = "Configs/SawLauncherAbilityUpgradeMap",
        order = 51)]
    public class SawLauncherAbilityUpgradeMap : ScriptableObject
    {
        [SerializeField] private IntSerializedDictionary _map;
        
        public IReadOnlyDictionary<int, int> Map => _map;
    }
}