using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.DomainInterfaces.Models.Spawners;

namespace Sources.InfrastructureInterfaces.Services.Saves
{
    public interface ISaveService : IEnterable, IExitable
    {
        void Register(IEnemySpawner enemySpawner);
    }
}