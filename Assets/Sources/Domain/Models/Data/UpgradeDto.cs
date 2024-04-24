using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Models.Data
{
    public class UpgradeDto : IDto
    {
        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        
        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; }
        
        [JsonProperty("maxLevel")]
        public float StartAmount { get; set; }
        
        [JsonProperty("addedAmount")]
        public float AddedAmount { get; set; }
        
        [JsonProperty("moneyPerUpgrades")]
        public MoneyPerUpgradeDto[] MoneyPerUpgrades { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}