using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.Scenes;

namespace Sources.InfrastructureInterfaces.Factories.Controllers.Scenes
{
    public interface ISceneFactory
    {
        UniTask<IScene> Create(object payload);
    }
}