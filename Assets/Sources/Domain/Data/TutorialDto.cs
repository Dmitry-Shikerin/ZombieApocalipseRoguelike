using Newtonsoft.Json;

namespace Sources.Domain.Data
{
    public class TutorialDto
    {
        [JsonProperty("hasCompleted")]
        public bool HasCompleted { get; set; }
    }
}