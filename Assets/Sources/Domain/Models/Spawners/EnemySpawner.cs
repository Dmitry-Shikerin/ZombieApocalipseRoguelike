using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using UnityEngine;

namespace Sources.Domain.Models.Spawners
{
    public class EnemySpawner : IEntity, IEnemySpawner
    {
        public EnemySpawner(EnemySpawnerDto enemySpawnerDto)
        {
            Id = enemySpawnerDto.Id;
            EnemyInWave = enemySpawnerDto.EnemyInWave;
            SpawnDelays = enemySpawnerDto.SpawnDelays;
            BossesInLevel = enemySpawnerDto.BossesInLevel;
            SpawnedEnemies = enemySpawnerDto.SpawnedEnemies;
            SpawnedBosses = enemySpawnerDto.SpawnedBosses;
            CurrentWave = enemySpawnerDto.CurrentWave;

            SumEnemiesInWave = FillEnemySums();
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

            SumEnemiesInWave = FillEnemySums();
        }

        public event Action CurrentWaveChanged;

        public string Id { get; }
        public Type Type => GetType();
        public IReadOnlyList<int> EnemyInWave { get; }
        public IReadOnlyList<int> SpawnDelays { get; }
        public IReadOnlyList<int> SumEnemiesInWave { get; }
        public int SumEnemies => EnemyInWave.Sum();
        public int BossesInLevel { get; }
        public int SumAllEnemies => EnemyInWave.Sum() + BossesInLevel;
        public int SpawnedBosses { get; set; }
        public int SpawnedEnemies { get; set; }
        public int CurrentWave { get; set; }
        public bool IsSpawnEnemy => SpawnedEnemies < SumEnemies;
        public bool IsSpawnBoss => SpawnedEnemies >= SumEnemies && SpawnedBosses == 0;

        public void SetCurrentWave(int killZombies)
        {
            for (int i = 0; i < SumEnemiesInWave.Count; i++)
            {
                if (killZombies == SumEnemiesInWave[i])
                {
                    if (i == SumEnemiesInWave.Count)
                        return;
                    
                    if(i + 1 <= CurrentWave)
                        return;

                    CurrentWave = i + 1;
                    CurrentWaveChanged?.Invoke();
                    Debug.Log($"CurrentWaveChanged: {CurrentWave}");
                }
            }
        }

        public async UniTask WaitWave(IKillEnemyCounter killEnemyCounter, CancellationToken cancellationToken)
        {
            if (SpawnedEnemies != SumEnemiesInWave[CurrentWave])
                return;
            
            await UniTask.WaitUntil(() =>
                        killEnemyCounter.KillZombies == SumEnemiesInWave[CurrentWave],
                    cancellationToken: cancellationToken);
        }

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