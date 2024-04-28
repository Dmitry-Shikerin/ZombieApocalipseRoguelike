using Sources.Domain.Models.Data;
using Sources.Domain.Models.Spawners;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IEnemySpawnerDtoMapper
    {
        EnemySpawnerDto MapModelToDto(EnemySpawner enemySpawner);
        EnemySpawner MapDtoToModel(EnemySpawnerDto enemySpawnerDto);
        EnemySpawnerDto MapIdToDto(string sceneId);
    }
}