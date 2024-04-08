using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Data
{
    public class PlayerWalletDto : IDto
    {
        [JsonProperty("coins")]
        public int Coins { get; set; }
    }
}