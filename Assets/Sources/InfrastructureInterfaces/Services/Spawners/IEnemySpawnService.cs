using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IEnemySpawnService
    {
        IEnemyView Spawn();
    }
}