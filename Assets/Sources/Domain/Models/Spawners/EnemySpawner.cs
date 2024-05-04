using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Spawners
{
    public class EnemySpawner : IEntity
    {
        private List<int> _sumEnemiesInWave;

        public EnemySpawner(EnemySpawnerDto enemySpawnerDto)
        {
            Id = enemySpawnerDto.Id;
            EnemyInWave = enemySpawnerDto.EnemyInWave;
            SpawnDelays = enemySpawnerDto.SpawnDelays;
            BossesInLevel = enemySpawnerDto.BossesInLevel;

            _sumEnemiesInWave = FillEnemySums();
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
            
            _sumEnemiesInWave = FillEnemySums();
        }

        public IReadOnlyList<int> EnemyInWave { get; }
        public IReadOnlyList<int> SpawnDelays { get; }
        public IReadOnlyList<int> SumEnemiesInWave => _sumEnemiesInWave;
        public string Id { get; }
        public Type Type => GetType();
        public int BossCounter { get; set; }
        public int SumEnemies => GetSumEnemies();
        public int SumAllEnemies => GetSumEnemies() + BossesInLevel;


        //TODO это тоже сохранять
        public int BossesInLevel { get; }
        public int SpawnedEnemies { get; set; }
        public int CurrentWave { get; set; }


        private int GetSumEnemies()
        {
            int sum = 0;

            foreach (int enemies in EnemyInWave)
                sum += enemies;
            
            return sum;
        }

        private List<int> FillEnemySums()
        {
            List<int> sums = new List<int>();

            int sum = 0;
            
            foreach (int enemies in EnemyInWave)
            {
                sum += enemies;
                sums.Add(sum);
            }
            
            return sums;
        }
    }
}