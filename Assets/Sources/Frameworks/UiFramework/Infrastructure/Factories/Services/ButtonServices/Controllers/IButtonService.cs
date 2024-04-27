using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices
{
    public interface IButtonService : IEnable, IDisable, IOnClick
    {
    }
}