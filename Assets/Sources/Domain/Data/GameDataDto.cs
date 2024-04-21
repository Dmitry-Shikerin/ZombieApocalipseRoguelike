using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Data
{
    public class GameDataDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }
        
        [JsonProperty("isThereSave")]
        public bool IsThereSave { get; set; }
    }
}