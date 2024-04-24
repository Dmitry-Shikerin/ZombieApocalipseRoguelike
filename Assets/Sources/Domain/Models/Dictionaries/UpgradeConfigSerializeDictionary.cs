using System;
using Sources.Domain.Models.Upgrades.Configs;
using Sources.Utils.Dictionaries;

namespace Sources.Domain.Models.Dictionaries
{
    [Serializable]
    public class UpgradeConfigSerializeDictionary : SerializedDictionary<string, UpgradeConfig>
    {
    }
}