using Newtonsoft.Json;
using Sources.DomainInterfaces.Models.Data;

namespace Sources.Domain.Models.Data
{
    public class VolumeDto : IDto
    {
        [JsonProperty("volumeValue")]
        public float VolumeValue { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}