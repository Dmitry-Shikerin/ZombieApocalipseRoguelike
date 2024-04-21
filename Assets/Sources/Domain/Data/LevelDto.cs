using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Data
{
    public class LevelDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}