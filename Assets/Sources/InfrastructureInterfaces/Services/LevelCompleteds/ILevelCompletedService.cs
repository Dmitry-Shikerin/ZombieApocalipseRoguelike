using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.InfrastructureInterfaces.Services.LevelCompleteds
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        public void Register(IKillEnemyCounter killEnemyCounter, IEnemySpawner enemySpawner);
    }
}