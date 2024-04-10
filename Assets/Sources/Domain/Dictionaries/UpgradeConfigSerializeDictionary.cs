using System;
using Sources.Domain.Upgrades.Configs;
using Sources.Utils.Dictionaries;

namespace Sources.Domain.Dictionaries
{
    [Serializable]
    public class UpgradeConfigSerializeDictionary : SerializedDictionary<string, UpgradeConfig>
    {
    }
}