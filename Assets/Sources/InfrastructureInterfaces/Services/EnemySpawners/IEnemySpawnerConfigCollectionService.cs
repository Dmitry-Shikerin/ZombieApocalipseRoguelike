using Sources.Domain.Models.Spawners.Configs;

namespace Sources.InfrastructureInterfaces.Services.EnemySpawners
{
    public interface IEnemySpawnerConfigCollectionService
    {
        EnemySpawnerConfig Get(string id);
    }
}