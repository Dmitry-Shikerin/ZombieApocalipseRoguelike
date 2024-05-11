using System;
using System.Linq;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Spawners.Configs;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.EnemySpawners;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class EnemySpawnerDtoMapper : IEnemySpawnerDtoMapper
    {
        private readonly IEnemySpawnerConfigCollectionService _enemySpawnerConfigCollectionService;

        public EnemySpawnerDtoMapper(
            IEnemySpawnerConfigCollectionService enemySpawnerConfigCollectionService)
        {
            _enemySpawnerConfigCollectionService = 
                enemySpawnerConfigCollectionService ?? 
                throw new ArgumentNullException(nameof(enemySpawnerConfigCollectionService));
        }

        public EnemySpawnerDto MapIdToDto(string sceneId)
        {
            EnemySpawnerConfig enemySpawnerConfig = _enemySpawnerConfigCollectionService.Get(sceneId);

            return new EnemySpawnerDto()
            {
                Id = ModelId.GameplayEnemySpawner,
                EnemyInWave = enemySpawnerConfig.EnemyInWave.ToArray(),
                SpawnDelays = enemySpawnerConfig.SpawnDelays.ToArray(),
                BossesInLevel = enemySpawnerConfig.BossesInLevel,
                SpawnedEnemies = 0,
                SpawnedBosses = 0,
                CurrentWave = 0,
            };
        }

        public EnemySpawnerDto MapModelToDto(EnemySpawner enemySpawner)
        {
            return new EnemySpawnerDto()
            {
                Id = enemySpawner.Id,
                EnemyInWave = enemySpawner.EnemyInWave.ToArray(),
                SpawnDelays = enemySpawner.SpawnDelays.ToArray(),
                BossesInLevel = enemySpawner.BossesInLevel,
                SpawnedEnemies = enemySpawner.SpawnedEnemies,
                SpawnedBosses = enemySpawner.SpawnedBosses,
                CurrentWave = enemySpawner.CurrentWave,
            };
        }

        public EnemySpawner MapDtoToModel(EnemySpawnerDto enemySpawnerDto)
        {
            return new EnemySpawner(enemySpawnerDto);
        }
    }
}