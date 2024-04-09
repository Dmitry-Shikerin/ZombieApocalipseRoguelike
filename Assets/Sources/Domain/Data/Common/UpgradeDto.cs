using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Data.Common
{
    public class UpgradeDto : IDto
    {
        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        
        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; }
        
        [JsonProperty("addedAmount")]
        public float AddedAmount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}