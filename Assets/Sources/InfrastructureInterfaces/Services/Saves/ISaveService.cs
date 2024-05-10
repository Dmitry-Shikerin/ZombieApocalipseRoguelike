using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;

namespace Sources.InfrastructureInterfaces.Services.Saves
{
    public interface ISaveService : IEnterable, IExitable
    {
        void Register(EnemySpawner enemySpawner);
    }
}