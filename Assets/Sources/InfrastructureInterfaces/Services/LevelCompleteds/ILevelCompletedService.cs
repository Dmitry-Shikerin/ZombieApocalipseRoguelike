using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;

namespace Sources.InfrastructureInterfaces.Services.LevelCompleteds
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        public void Register(IKillEnemyCounter killEnemyCounter, IEnemySpawner enemySpawner);
    }
}