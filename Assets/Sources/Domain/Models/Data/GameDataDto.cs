using Newtonsoft.Json;
using Sources.DomainInterfaces.Models.Data;

namespace Sources.Domain.Models.Data
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