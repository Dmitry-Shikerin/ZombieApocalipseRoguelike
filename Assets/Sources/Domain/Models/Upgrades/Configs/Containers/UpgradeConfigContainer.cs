using System.Collections.Generic;
using UnityEngine;

namespace Sources.Domain.Models.Upgrades.Configs.Containers
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