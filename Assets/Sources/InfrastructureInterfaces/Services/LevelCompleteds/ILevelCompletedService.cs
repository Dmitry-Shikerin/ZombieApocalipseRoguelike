using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.Infrastructure.Services.LevelCompleteds
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        public void Register(IKillEnemyCounter killEnemyCounter, IEnemySpawner enemySpawner);
    }
}