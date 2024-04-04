using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.Services.SceneServices
{
    public interface ISceneService : IUpdatable, IFixedUpdatable, ILateUpdatable, IDisable
    {
        UniTask ChangeSceneAsync(string sceneName, object payload = null);
    }
}