using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Spawners.Configs;
using Sources.Domain.Models.Spawners.Configs.Containers;

namespace Sources.Infrastructure.Services.EnemySpawners
{
    public class EnemySpawnerConfigCollectionService : IEnemySpawnerConfigCollectionService
    {
        private readonly Dictionary<string, EnemySpawnerConfig> _spawnerConfigs;

        public EnemySpawnerConfigCollectionService(EnemySpawnerConfigContainer enemySpawnerConfigContainer)
        {
            if(enemySpawnerConfigContainer == null)
                throw new ArgumentNullException(nameof(enemySpawnerConfigContainer));

            _spawnerConfigs = enemySpawnerConfigContainer.Configs.ToDictionary(key => key.Id);
        }

        public EnemySpawnerConfig Get(string id)
        {
            if(_spawnerConfigs.ContainsKey(id) == false)
                throw new KeyNotFoundException(nameof(id));
            
            return _spawnerConfigs[id];
        }
    }
}