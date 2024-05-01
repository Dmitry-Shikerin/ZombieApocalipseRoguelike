using System;
using Sources.Domain.Models.Upgrades.Configs;
using Sources.Utils.Dictionaries;

namespace Sources.Frameworks.UiFramework.Domain.Dictionaries
{
    [Serializable]
    public class UpgradeConfigSerializeDictionary : SerializedDictionary<string, UpgradeConfig>
    {
    }
}