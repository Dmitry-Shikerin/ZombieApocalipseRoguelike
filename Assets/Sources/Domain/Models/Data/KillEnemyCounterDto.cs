using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Models.Data
{
    public class KillEnemyCounterDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("killZombies")]
        public int KillZombies { get; set; }
    }
}