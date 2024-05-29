using System;
using System.Collections.Generic;

namespace Sources.DomainInterfaces.Models.Spawners
{
    public interface IEnemySpawner
    {
        event Action CurrentWaveChanged;

        public IReadOnlyList<int> EnemyInWave { get; }

        public IReadOnlyList<int> SumEnemiesInWave { get; }

        public int CurrentWave { get; }

        public int SumEnemies { get; }

        public int SumAllEnemies { get; }
    }
}