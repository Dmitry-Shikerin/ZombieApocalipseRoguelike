using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.Services.SceneServices
{
    public interface ISceneService : IUpdatable, IFixedUpdatable, ILateUpdatable, IDisable
    {
        
    }
}