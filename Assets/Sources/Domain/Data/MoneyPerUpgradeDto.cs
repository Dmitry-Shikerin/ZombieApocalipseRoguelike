using Newtonsoft.Json;

namespace Sources.Domain.Data.Common
{
    public class MoneyPerUpgradeDto
    {
        [JsonProperty("moneyPerUpgradeCharisma")]
        public int MoneyPerUpgrade { get; set; }
    }
}