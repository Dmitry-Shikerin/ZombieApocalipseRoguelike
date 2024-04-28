using System;
using System.Linq;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Spawners.Configs;
using Sources.Infrastructure.Services.EnemySpawners;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

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

        public EnemySpawnerDto MapIdToDto(string id)
        {
            EnemySpawnerConfig enemySpawnerConfig = _enemySpawnerConfigCollectionService.Get(id);

            return new EnemySpawnerDto()
            {
                Id = enemySpawnerConfig.SceneId,
                EnemyInWave = enemySpawnerConfig.EnemyInWave.ToArray(),
                SpawnDelays = enemySpawnerConfig.SpawnDelays.ToArray(),
            };
        }

        public EnemySpawnerDto MapModelToDto(EnemySpawner enemySpawner)
        {
            //TODO сработает ли сохранение сразу массива
            return new EnemySpawnerDto()
            {
                Id = enemySpawner.Id,
                EnemyInWave = enemySpawner.EnemyInWave.ToArray(),
                SpawnDelays = enemySpawner.SpawnDelays.ToArray(),
            };
        }

        public EnemySpawner MapDtoToModel(EnemySpawnerDto enemySpawnerDto)
        {
            return new EnemySpawner(enemySpawnerDto);
        }
    }
}