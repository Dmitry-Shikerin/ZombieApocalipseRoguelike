using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.Infrastructure.Services.LevelCompleteds
{
    public interface ILevelCompletedService : IEnable, IDisable
    {
        public void Register(KillEnemyCounter killEnemyCounter, EnemySpawner enemySpawner);
    }
}