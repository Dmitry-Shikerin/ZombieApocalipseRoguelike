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
        }

        public EnemySpawner(
            string id, 
            IReadOnlyList<int> enemyInWave, 
            IReadOnlyList<int> spawnDelays)
        {
            Id = id;

            if (enemyInWave.Count != spawnDelays.Count)
                throw new ArgumentOutOfRangeException(nameof(spawnDelays));
            
            EnemyInWave = enemyInWave;
            SpawnDelays = spawnDelays;
        }

        public IReadOnlyList<int> EnemyInWave { get; }
        public IReadOnlyList<int> SpawnDelays { get; }
        public string Id { get; }
        public Type Type { get; }
        public int BossesInLevel { get; } = 1;
        public float CurrentDelay { get; set; }
        public int BossCounter { get; set; }
        public int SumEnemies => GetSumEnemyes();


        private int GetSumEnemyes()
        {
            int sum = 0;

            foreach (int enemies in EnemyInWave)
                sum += enemies;


            return sum;
        }
    }
}