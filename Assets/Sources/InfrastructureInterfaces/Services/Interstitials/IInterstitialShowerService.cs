using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Spawners;
using Sources.DomainInterfaces.Models.Spawners;

namespace Sources.InfrastructureInterfaces.Services.Interstitials
{
    public interface IInterstitialShowerService : IEnterable, IExitable
    {
        void Register(IEnemySpawner enemySpawner);
    }
}