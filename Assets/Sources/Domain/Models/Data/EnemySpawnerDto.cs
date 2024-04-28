using Newtonsoft.Json;
using Sources.DomainInterfaces.Models.Data;

namespace Sources.Domain.Models.Data
{
    public class EnemySpawnerDto : IDto
    {
        //TODO будут ли ошибки если здесь будет айди названия уровня
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("bossesInLevel")]
        public int BossesInLevel { get; set; }
        
        [JsonProperty("enemyInWave")]
        public int[] EnemyInWave { get; set; }
        
        //TODO можно ли сохранять массив примитивов?
        [JsonProperty("spawnDelays")]
        public int[] SpawnDelays { get; set; }
    }
}