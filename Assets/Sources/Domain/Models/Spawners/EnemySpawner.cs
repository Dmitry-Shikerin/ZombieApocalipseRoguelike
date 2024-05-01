using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Spawners
{
    public class EnemySpawner : IEntity
    {
        public EnemySpawner(EnemySpawnerDto enemySpawnerDto)
        {
            Id = enemySpawnerDto.Id;
            EnemyInWave = enemySpawnerDto.EnemyInWave;
            SpawnDelays = enemySpawnerDto.SpawnDelays;
            BossesInLevel = enemySpawnerDto.BossesInLevel;
        }

        public EnemySpawner(
            string id,
            IReadOnlyList<int> enemyInWave,
            IReadOnlyList<int> spawnDelays,
            int bossesInLevel)
        {
            Id = id;

            if (enemyInWave.Count != spawnDelays.Count)
                throw new ArgumentOutOfRangeException(nameof(spawnDelays));

            EnemyInWave = enemyInWave;
            SpawnDelays = spawnDelays;
            BossesInLevel = bossesInLevel;
        }

        public IReadOnlyList<int> EnemyInWave { get; }
        public IReadOnlyList<int> SpawnDelays { get; }
        public string Id { get; }
        public Type Type => GetType();
        public int BossCounter { get; set; }

        public int SumEnemies => GetSumEnemyes();
        public int SumAllEnemies => GetSumEnemyes() + BossesInLevel;

        //TODO это тоже сохранять
        public int BossesInLevel { get; }
        public int SpawnedEnemies { get; set; }
        public int CurrentWave { get; set; }

        private int GetSumEnemyes()
        {
            int sum = 0;

            foreach (int enemies in EnemyInWave)
                sum += enemies;
            
            return sum;
        }
    }
}