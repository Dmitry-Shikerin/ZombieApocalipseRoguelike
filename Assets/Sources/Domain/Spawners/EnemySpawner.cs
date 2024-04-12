﻿using System.Collections.Generic;

namespace Sources.Domain.Spawners
{
    public class EnemySpawner
    {
        public IReadOnlyList<int> EnemyInWave { get; } = new List<int>()
        {
            1,
            1,
            1
        };
        
        public IReadOnlyList<int> SpawnDelays { get; } = new List<int>()
        {
            6,
            4,
            2
        };
        
        public float CurrentDelay { get; set; }

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