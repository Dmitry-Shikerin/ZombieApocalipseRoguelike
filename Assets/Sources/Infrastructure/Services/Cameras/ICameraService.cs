using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.Infrastructure.Services.Cameras
{
    public interface ICameraService : IEnable, IDisable
    {
    }
}