using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;

namespace Sources.Domain.Data
{
    public class VolumeDto : IDto
    {
        [JsonProperty("volumeValue")]
        public float VolumeValue { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}