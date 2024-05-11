using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.ControllersInterfaces.ViewModels
{
    public interface IViewModelComponent : IEnable, IDisable
    {
    }
}