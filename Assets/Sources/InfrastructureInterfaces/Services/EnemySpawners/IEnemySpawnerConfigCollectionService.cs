using Sources.Domain.Models.Spawners.Configs;

namespace Sources.Infrastructure.Services.EnemySpawners
{
    public interface IEnemySpawnerConfigCollectionService
    {
        EnemySpawnerConfig Get(string id);
    }
}