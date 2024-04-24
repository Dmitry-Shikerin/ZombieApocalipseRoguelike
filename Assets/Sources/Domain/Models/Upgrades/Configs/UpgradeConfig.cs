using System.Collections.Generic;
using UnityEngine;

namespace Sources.Domain.Models.Upgrades.Configs
{
    [CreateAssetMenu(
        fileName = "UpgradeConfig",
        menuName = "Characteristics/UpgradeConfig",
        order = 51)]
    public class UpgradeConfig : ScriptableObject
    {
        [field: SerializeField] public int MaxLevel { get; private set; }
        [field: SerializeField] public int CurrentLevel { get; private set; }
        [field: SerializeField] public float StartAmount { get; private set; }
        [field: SerializeField] public float AddedAmount { get; private set; }
        [field: SerializeField] public List<int> MoneyPerUpgrades { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string Id { get; private set; }
    }
}