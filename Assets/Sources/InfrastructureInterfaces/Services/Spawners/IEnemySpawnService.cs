using Sources.PresentationsInterfaces.Views.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.InfrastructureInterfaces.Services.Spawners
{
    public interface IEnemySpawnService
    {
        IEnemyView Spawn();
    }
}