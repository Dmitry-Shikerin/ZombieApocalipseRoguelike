using System.Collections.Generic;
using Sources.Domain.Dictionaries;
using UnityEngine;

namespace Sources.Domain.Upgrades.Configs.Containers
{
    [CreateAssetMenu(
        fileName = "UpgradeConfigContainer",
        menuName = "Characteristics/UpgradeConfigContainer",
        order = 51)]
    public class UpgradeConfigContainer : ScriptableObject
    {
        [field: SerializeField] public List<UpgradeConfig> UpgradeConfigs { get; private set; }
    }
}