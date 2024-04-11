using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.InfrastructureInterfaces.Services.Upgrades
{
    public interface IUpgradeService : IEnable, IDisable
    {
    }
}