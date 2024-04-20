using Newtonsoft.Json;

namespace Sources.Domain.Data
{
    public class VolumeDto
    {
        [JsonProperty("step")]
        public int Step { get; set; }
    }
}